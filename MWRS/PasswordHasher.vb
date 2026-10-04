Imports System.Security.Cryptography
Imports System.Text

' Salted PBKDF2-SHA256 password hashing. Stored values look like
' PBKDF2$<iterations>$<salt base64>$<hash base64>, so the plain password is
' never saved and cannot be read back from the database.
Module PasswordHasher
    Public Const MinPasswordLength As Integer = 8
    Private Const Iterations As Integer = 100000
    Private Const SaltSize As Integer = 16
    Private Const HashSize As Integer = 32

    Public Function HashPassword(password As String) As String
        Dim salt(SaltSize - 1) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
        End Using

        Using kdf As New Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256)
            Return "PBKDF2$" & Iterations & "$" & Convert.ToBase64String(salt) & "$" & Convert.ToBase64String(kdf.GetBytes(HashSize))
        End Using
    End Function

    ' Checks a typed password against a stored value. Accounts saved before
    ' hashing was added still hold the plain password; those still work and
    ' should be re-saved with HashPassword right after a successful login.
    Public Function VerifyPassword(password As String, stored As String) As Boolean
        If password Is Nothing OrElse String.IsNullOrEmpty(stored) Then Return False

        If NeedsRehash(stored) Then
            Return FixedTimeEquals(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(stored))
        End If

        Dim parts() As String = stored.Split("$"c)
        Dim count As Integer
        If parts.Length <> 4 OrElse Not Integer.TryParse(parts(1), count) OrElse count <= 0 Then Return False

        Dim salt() As Byte
        Dim expected() As Byte
        Try
            salt = Convert.FromBase64String(parts(2))
            expected = Convert.FromBase64String(parts(3))
        Catch ex As FormatException
            Return False
        End Try

        Using kdf As New Rfc2898DeriveBytes(password, salt, count, HashAlgorithmName.SHA256)
            Return FixedTimeEquals(kdf.GetBytes(expected.Length), expected)
        End Using
    End Function

    ' True when the stored value is still a plain-text password.
    Public Function NeedsRehash(stored As String) As Boolean
        Return stored Is Nothing OrElse Not stored.StartsWith("PBKDF2$", StringComparison.Ordinal)
    End Function

    ' Random password for new accounts: 10 characters without look-alikes (0/O, 1/l/I).
    Public Function GenerateTemporaryPassword() As String
        Const chars As String = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789"
        Dim bytes(9) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(bytes)
        End Using

        Dim sb As New StringBuilder()
        For Each b As Byte In bytes
            sb.Append(chars(b Mod chars.Length))
        Next
        Return sb.ToString()
    End Function

    ' Compares in constant time so the check doesn't leak how many characters matched.
    Private Function FixedTimeEquals(a() As Byte, b() As Byte) As Boolean
        Dim diff As Integer = a.Length Xor b.Length
        For i As Integer = 0 To Math.Min(a.Length, b.Length) - 1
            diff = diff Or (CInt(a(i)) Xor CInt(b(i)))
        Next
        Return diff = 0
    End Function
End Module
