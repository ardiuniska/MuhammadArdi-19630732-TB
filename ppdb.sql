-- MariaDB dump 10.19  Distrib 10.4.22-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: ppdb
-- ------------------------------------------------------
-- Server version	10.4.22-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admin` (
  `IDADMIN` char(20) NOT NULL,
  `NAMA` varchar(20) DEFAULT NULL,
  `PASSWORD` varchar(20) DEFAULT NULL,
  `STATUS` char(30) DEFAULT NULL,
  PRIMARY KEY (`IDADMIN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES ('1001','HASBI','HASBI','ADMIN');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fasilitas`
--

DROP TABLE IF EXISTS `fasilitas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fasilitas` (
  `IDFASILITAS` char(40) NOT NULL DEFAULT '',
  `NAMA` char(150) DEFAULT NULL,
  `TGLINPUT` date DEFAULT NULL,
  `TGLBELI` char(40) DEFAULT NULL,
  `JUMLAH` char(40) DEFAULT NULL,
  `HBELI` int(40) DEFAULT NULL,
  `UNTUK` char(150) DEFAULT NULL,
  `KETERANGAN` char(150) DEFAULT NULL,
  `USER_INPUT` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`IDFASILITAS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fasilitas`
--

LOCK TABLES `fasilitas` WRITE;
/*!40000 ALTER TABLE `fasilitas` DISABLE KEYS */;
INSERT INTO `fasilitas` VALUES ('FS001','KOMPUTER','2007-10-30','8 NOVEMBER 2007','10',2500000,'KLS001','BEKAS','HASBI');
/*!40000 ALTER TABLE `fasilitas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guru`
--

DROP TABLE IF EXISTS `guru`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `guru` (
  `IDGURU` char(40) NOT NULL DEFAULT '',
  `NAMA` varchar(150) DEFAULT NULL,
  `NIP` char(50) DEFAULT NULL,
  `TGLAJAR` date DEFAULT NULL,
  `ALAMAT` varchar(150) DEFAULT NULL,
  `NIK` char(50) DEFAULT NULL,
  `KETGURU` char(150) DEFAULT NULL,
  PRIMARY KEY (`IDGURU`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guru`
--

LOCK TABLES `guru` WRITE;
/*!40000 ALTER TABLE `guru` DISABLE KEYS */;
INSERT INTO `guru` VALUES ('PG001','HASBI ARIFIN','101','2007-10-30','HANDEL BARU','6203062212000001','GURU MTK');
/*!40000 ALTER TABLE `guru` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jurusan`
--

DROP TABLE IF EXISTS `jurusan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `jurusan` (
  `IDJURUSAN` char(40) NOT NULL DEFAULT '',
  `NAMA` char(100) DEFAULT NULL,
  `TGLBUAT` date DEFAULT NULL,
  `USER_INPUT` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IDJURUSAN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jurusan`
--

LOCK TABLES `jurusan` WRITE;
/*!40000 ALTER TABLE `jurusan` DISABLE KEYS */;
INSERT INTO `jurusan` VALUES ('JS001','TEKNIK INFORMATIKA','2007-10-30','HASBI'),('JS002','MULTIMEDIA','2007-10-30','HASBI'),('JS003','PERKEBUNAN','2007-10-30','HASBI');
/*!40000 ALTER TABLE `jurusan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kelas`
--

DROP TABLE IF EXISTS `kelas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kelas` (
  `IDKELAS` char(20) NOT NULL DEFAULT '',
  `NOKELAS` int(20) unsigned DEFAULT NULL,
  `KAPASITAS` int(10) DEFAULT NULL,
  `KETERANGAN` char(100) DEFAULT NULL,
  PRIMARY KEY (`IDKELAS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kelas`
--

LOCK TABLES `kelas` WRITE;
/*!40000 ALTER TABLE `kelas` DISABLE KEYS */;
INSERT INTO `kelas` VALUES ('KLS001',101,3,'KELAS BISA DI TEMPATI'),('KLS002',102,29,'MASIH DI RENOPASNI');
/*!40000 ALTER TABLE `kelas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pendaftaran`
--

DROP TABLE IF EXISTS `pendaftaran`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pendaftaran` (
  `NDAFTAR` char(40) NOT NULL DEFAULT '',
  `NAMA` varchar(150) DEFAULT NULL,
  `JK` char(30) DEFAULT NULL,
  `NISN` char(50) DEFAULT NULL,
  `TL` char(100) DEFAULT NULL,
  `TGL` char(40) DEFAULT NULL,
  `NIK` char(30) DEFAULT NULL,
  `AGAMA` char(30) DEFAULT NULL,
  `KKHUSUS` char(100) DEFAULT NULL,
  `ALAMAT` char(150) DEFAULT NULL,
  `RT` char(20) DEFAULT NULL,
  `RW` char(20) DEFAULT NULL,
  `DUSUN` char(50) DEFAULT NULL,
  `KELUARAHAN` char(50) DEFAULT NULL,
  `KECAMATAN` char(50) DEFAULT NULL,
  `KDPOS` char(20) DEFAULT NULL,
  `JTINGGAL` char(100) DEFAULT NULL,
  `TRANSPORTASI` char(100) DEFAULT NULL,
  `TELEPON` char(30) DEFAULT NULL,
  `HP` char(30) DEFAULT NULL,
  `E_MAIL` char(50) DEFAULT NULL,
  `NO_PESERTA_UN` char(30) DEFAULT NULL,
  `TKIP` varchar(20) DEFAULT NULL,
  `NOKIP` int(50) DEFAULT NULL,
  `AYAH` varchar(50) DEFAULT NULL,
  `THLAHIRA` char(20) DEFAULT NULL,
  `JPA` char(50) DEFAULT NULL,
  `PEKERJAANA` char(50) DEFAULT NULL,
  `PENGHASILANA` int(50) DEFAULT NULL,
  `KKHUSUSA` char(50) DEFAULT NULL,
  `IBU` varchar(50) DEFAULT NULL,
  `THLAHIRI` char(20) DEFAULT NULL,
  `JPI` char(50) DEFAULT NULL,
  `PEKERJAANI` char(50) DEFAULT NULL,
  `PENGHASILANI` int(50) DEFAULT NULL,
  `KKHUSUSI` char(50) DEFAULT NULL,
  `BB` char(20) DEFAULT NULL,
  `TB` char(20) DEFAULT NULL,
  `JRKS` char(30) DEFAULT NULL,
  `WTKS` char(30) DEFAULT NULL,
  `SAUDARA` int(10) DEFAULT NULL,
  PRIMARY KEY (`NDAFTAR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pendaftaran`
--

LOCK TABLES `pendaftaran` WRITE;
/*!40000 ALTER TABLE `pendaftaran` DISABLE KEYS */;
INSERT INTO `pendaftaran` VALUES ('1001','HASBI ARIFIN','LAKI-LAKI','10001','NARAHAN','22 DESEMBER 2000','6203052212000001','ISLAM','NORMAL','JL HANDEL BARU','105','03','HANDEL BARU','ROHAM RAYA','WANARAYA','70560','ORANG TUA','SEPEDA MOTOR','087819924345','087819924345','HASBIARIFIN22@GMAIL.COM','10001','TIDAK',0,'NANANG','1789','SLTA/SEDERAJAT','PETANI',10000000,'NORMAL','MAESANAH','1742','SLTA/SEDERAJAT','IBU RUMAH TANGGA',5000000,'NORMAL','65','175','2 KM','15 MENIT',2);
/*!40000 ALTER TABLE `pendaftaran` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sekolah`
--

DROP TABLE IF EXISTS `sekolah`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sekolah` (
  `ID` int(10) NOT NULL,
  `NAMASEKOLAH` char(150) DEFAULT NULL,
  `ALAMAT` char(150) DEFAULT NULL,
  `ALENGKAP` char(150) DEFAULT NULL,
  `KEPSEK` varchar(100) DEFAULT NULL,
  `NIP` char(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sekolah`
--

LOCK TABLES `sekolah` WRITE;
/*!40000 ALTER TABLE `sekolah` DISABLE KEYS */;
INSERT INTO `sekolah` VALUES (10001,'MTS SABILAL MUHTADIN','SEI LEBU RT 013','SEI LEBU,KALIMANTAN TENGAH','HASBI ARIFIN','10001');
/*!40000 ALTER TABLE `sekolah` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-07 10:15:27
