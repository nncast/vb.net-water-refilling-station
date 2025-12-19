/*
SQLyog Ultimate - MySQL GUI v8.22 
MySQL - 5.5.5-10.4.32-MariaDB : Database - dbmwrs
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`dbmwrs` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `dbmwrs`;

/*Table structure for table `tblactivitylogs` */

DROP TABLE IF EXISTS `tblactivitylogs`;

CREATE TABLE `tblactivitylogs` (
  `logid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL,
  `module` varchar(100) DEFAULT NULL,
  `action` varchar(50) DEFAULT NULL,
  `recordid` int(11) DEFAULT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`logid`),
  KEY `userid` (`userid`),
  CONSTRAINT `fk_activitylogs_user` FOREIGN KEY (`userid`) REFERENCES `tblusers` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblactivitylogs` */

/*Table structure for table `tblbarangays` */

DROP TABLE IF EXISTS `tblbarangays`;

CREATE TABLE `tblbarangays` (
  `barangayid` int(11) NOT NULL AUTO_INCREMENT,
  `barangayname` varchar(100) NOT NULL,
  PRIMARY KEY (`barangayid`),
  UNIQUE KEY `barangayname` (`barangayname`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblbarangays` */

insert  into `tblbarangays`(`barangayid`,`barangayname`) values (1,'Callao'),(2,'San Pablo');

/*Table structure for table `tblcustomerbalance` */

DROP TABLE IF EXISTS `tblcustomerbalance`;

CREATE TABLE `tblcustomerbalance` (
  `custid` int(11) NOT NULL,
  `balance` decimal(10,2) DEFAULT 0.00,
  `lastupdate` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`custid`),
  CONSTRAINT `fk_customerbalance_customer` FOREIGN KEY (`custid`) REFERENCES `tblcustomers` (`custid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblcustomerbalance` */

/*Table structure for table `tblcustomers` */

DROP TABLE IF EXISTS `tblcustomers`;

CREATE TABLE `tblcustomers` (
  `custid` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(150) NOT NULL,
  `address` varchar(150) DEFAULT NULL,
  `contact` varchar(50) DEFAULT NULL,
  `notes` text DEFAULT NULL,
  `barangayid` int(11) DEFAULT NULL,
  `purokid` int(11) DEFAULT NULL,
  PRIMARY KEY (`custid`),
  KEY `barangayid` (`barangayid`),
  KEY `purokid` (`purokid`),
  CONSTRAINT `tblcustomers_ibfk_1` FOREIGN KEY (`barangayid`) REFERENCES `tblbarangays` (`barangayid`),
  CONSTRAINT `tblcustomers_ibfk_2` FOREIGN KEY (`purokid`) REFERENCES `tblpuroks` (`purokid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblcustomers` */

/*Table structure for table `tblcustomertransactions` */

DROP TABLE IF EXISTS `tblcustomertransactions`;

CREATE TABLE `tblcustomertransactions` (
  `txnid` int(11) NOT NULL AUTO_INCREMENT,
  `custid` int(11) NOT NULL,
  `saleid` int(11) DEFAULT NULL,
  `amount` decimal(10,2) NOT NULL,
  `type` enum('Sale','Payment') NOT NULL,
  `date` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`txnid`),
  KEY `custid` (`custid`),
  CONSTRAINT `fk_custtransactions_customer` FOREIGN KEY (`custid`) REFERENCES `tblcustomers` (`custid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblcustomertransactions` */

/*Table structure for table `tbldelivery` */

DROP TABLE IF EXISTS `tbldelivery`;

CREATE TABLE `tbldelivery` (
  `deliveryid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL,
  `deliverydate` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`deliveryid`),
  KEY `userid` (`userid`),
  CONSTRAINT `fk_delivery_user` FOREIGN KEY (`userid`) REFERENCES `tblusers` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbldelivery` */

/*Table structure for table `tbldeliveryorders` */

DROP TABLE IF EXISTS `tbldeliveryorders`;

CREATE TABLE `tbldeliveryorders` (
  `deliveryid` int(11) NOT NULL,
  `orderid` int(11) NOT NULL,
  PRIMARY KEY (`deliveryid`,`orderid`),
  KEY `orderid` (`orderid`),
  CONSTRAINT `fk_deliveryorders_delivery` FOREIGN KEY (`deliveryid`) REFERENCES `tbldelivery` (`deliveryid`),
  CONSTRAINT `fk_deliveryorders_order` FOREIGN KEY (`orderid`) REFERENCES `tblorders` (`orderid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbldeliveryorders` */

/*Table structure for table `tblinventorytransactions` */

DROP TABLE IF EXISTS `tblinventorytransactions`;

CREATE TABLE `tblinventorytransactions` (
  `transid` int(11) NOT NULL AUTO_INCREMENT,
  `productid` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `transtype` enum('Stock In','Stock Out') NOT NULL,
  `qty` int(11) NOT NULL,
  `transdate` timestamp NOT NULL DEFAULT current_timestamp(),
  `remarks` text DEFAULT NULL,
  PRIMARY KEY (`transid`),
  KEY `productid` (`productid`),
  KEY `userid` (`userid`),
  CONSTRAINT `fk_inventory_product` FOREIGN KEY (`productid`) REFERENCES `tblproducts` (`productid`),
  CONSTRAINT `fk_inventory_user` FOREIGN KEY (`userid`) REFERENCES `tblusers` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblinventorytransactions` */

/*Table structure for table `tblloginlogs` */

DROP TABLE IF EXISTS `tblloginlogs`;

CREATE TABLE `tblloginlogs` (
  `logid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL,
  `logintime` timestamp NOT NULL DEFAULT current_timestamp(),
  `logouttime` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`logid`),
  KEY `userid` (`userid`),
  CONSTRAINT `fk_loginlogs_user` FOREIGN KEY (`userid`) REFERENCES `tblusers` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblloginlogs` */

/*Table structure for table `tblorderitems` */

DROP TABLE IF EXISTS `tblorderitems`;

CREATE TABLE `tblorderitems` (
  `orderitemid` int(11) NOT NULL AUTO_INCREMENT,
  `orderid` int(11) NOT NULL,
  `productid` int(11) DEFAULT NULL,
  `serviceid` int(11) DEFAULT NULL,
  `qty` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `itemtype` enum('Product','Service') NOT NULL,
  PRIMARY KEY (`orderitemid`),
  KEY `orderid` (`orderid`),
  KEY `productid` (`productid`),
  KEY `serviceid` (`serviceid`),
  CONSTRAINT `fk_orderitems_order` FOREIGN KEY (`orderid`) REFERENCES `tblorders` (`orderid`) ON DELETE CASCADE,
  CONSTRAINT `fk_orderitems_product` FOREIGN KEY (`productid`) REFERENCES `tblproducts` (`productid`),
  CONSTRAINT `fk_orderitems_service` FOREIGN KEY (`serviceid`) REFERENCES `tblservices` (`serviceid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblorderitems` */

/*Table structure for table `tblorders` */

DROP TABLE IF EXISTS `tblorders`;

CREATE TABLE `tblorders` (
  `orderid` int(11) NOT NULL AUTO_INCREMENT,
  `custid` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `ordertype` enum('Delivery','Pickup') NOT NULL,
  `orderdate` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` enum('Pending','Ready To Deliver','Out For Delivery','Completed','Cancelled') DEFAULT 'Pending',
  PRIMARY KEY (`orderid`),
  KEY `custid` (`custid`),
  KEY `userid` (`userid`),
  CONSTRAINT `fk_orders_customer` FOREIGN KEY (`custid`) REFERENCES `tblcustomers` (`custid`),
  CONSTRAINT `fk_orders_user` FOREIGN KEY (`userid`) REFERENCES `tblusers` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblorders` */

/*Table structure for table `tblpayments` */

DROP TABLE IF EXISTS `tblpayments`;

CREATE TABLE `tblpayments` (
  `paymentid` int(11) NOT NULL AUTO_INCREMENT,
  `saleid` int(11) NOT NULL,
  `amountpaid` decimal(10,2) NOT NULL,
  `paymentdate` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`paymentid`),
  KEY `saleid` (`saleid`),
  CONSTRAINT `fk_payments_sale` FOREIGN KEY (`saleid`) REFERENCES `tblsales` (`saleid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblpayments` */

/*Table structure for table `tblproductcategories` */

DROP TABLE IF EXISTS `tblproductcategories`;

CREATE TABLE `tblproductcategories` (
  `categoryid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`categoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblproductcategories` */

/*Table structure for table `tblproducts` */

DROP TABLE IF EXISTS `tblproducts`;

CREATE TABLE `tblproducts` (
  `productid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `categoryid` int(11) DEFAULT NULL,
  `unitprice` decimal(10,2) NOT NULL,
  `unitid` int(11) DEFAULT NULL,
  `stockqty` int(11) NOT NULL DEFAULT 0,
  `reorderlevel` int(11) NOT NULL DEFAULT 0,
  `status` enum('Active','Inactive') DEFAULT 'Active',
  PRIMARY KEY (`productid`),
  KEY `categoryid` (`categoryid`),
  KEY `unitid` (`unitid`),
  CONSTRAINT `fk_tblproducts_category` FOREIGN KEY (`categoryid`) REFERENCES `tblproductcategories` (`categoryid`),
  CONSTRAINT `fk_tblproducts_unitid` FOREIGN KEY (`unitid`) REFERENCES `tblproductunit` (`unitid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblproducts` */

/*Table structure for table `tblproductunit` */

DROP TABLE IF EXISTS `tblproductunit`;

CREATE TABLE `tblproductunit` (
  `unitid` int(11) NOT NULL AUTO_INCREMENT,
  `unittype` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`unitid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblproductunit` */

insert  into `tblproductunit`(`unitid`,`unittype`) values (1,'Piece');

/*Table structure for table `tblpuroks` */

DROP TABLE IF EXISTS `tblpuroks`;

CREATE TABLE `tblpuroks` (
  `purokid` int(11) NOT NULL AUTO_INCREMENT,
  `barangayid` int(11) NOT NULL,
  `purokname` varchar(100) NOT NULL,
  PRIMARY KEY (`purokid`),
  UNIQUE KEY `barangayid` (`barangayid`,`purokname`),
  CONSTRAINT `tblpuroks_ibfk_1` FOREIGN KEY (`barangayid`) REFERENCES `tblbarangays` (`barangayid`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblpuroks` */

insert  into `tblpuroks`(`purokid`,`barangayid`,`purokname`) values (1,1,'1'),(2,1,'2'),(3,1,'3'),(4,1,'4'),(5,1,'5'),(6,1,'6'),(7,2,'1'),(8,2,'2'),(9,2,'3'),(10,2,'4'),(11,2,'5'),(12,2,'6');

/*Table structure for table `tblsales` */

DROP TABLE IF EXISTS `tblsales`;

CREATE TABLE `tblsales` (
  `saleid` int(11) NOT NULL AUTO_INCREMENT,
  `orderid` int(11) NOT NULL,
  `custid` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `totalamount` decimal(10,2) NOT NULL,
  `paymentstatus` enum('Full','Partial','Unpaid') NOT NULL,
  `saledate` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`saleid`),
  KEY `orderid` (`orderid`),
  KEY `custid` (`custid`),
  KEY `userid` (`userid`),
  CONSTRAINT `fk_sales_customer` FOREIGN KEY (`custid`) REFERENCES `tblcustomers` (`custid`),
  CONSTRAINT `fk_sales_order` FOREIGN KEY (`orderid`) REFERENCES `tblorders` (`orderid`),
  CONSTRAINT `fk_sales_user` FOREIGN KEY (`userid`) REFERENCES `tblusers` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblsales` */

/*Table structure for table `tblservices` */

DROP TABLE IF EXISTS `tblservices`;

CREATE TABLE `tblservices` (
  `serviceid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `status` enum('Active','Inactive') DEFAULT 'Active',
  PRIMARY KEY (`serviceid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblservices` */

insert  into `tblservices`(`serviceid`,`name`,`price`,`status`) values (1,'Delivery','30.00','Active'),(2,'Refill','35.00','Active');

/*Table structure for table `tblusers` */

DROP TABLE IF EXISTS `tblusers`;

CREATE TABLE `tblusers` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `fname` varchar(50) DEFAULT NULL,
  `lname` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` enum('Admin','Employee') NOT NULL,
  `status` enum('Active','Inactive') DEFAULT 'Active',
  PRIMARY KEY (`userid`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblusers` */

insert  into `tblusers`(`userid`,`fname`,`lname`,`username`,`password`,`role`,`status`) values (1,'Admin','Admin','admin','admin','Admin','Active');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
