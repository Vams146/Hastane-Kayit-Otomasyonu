-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: hastane2
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `branslar`
--

DROP TABLE IF EXISTS `branslar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `branslar` (
  `idbranslar` int NOT NULL AUTO_INCREMENT,
  `bransadi` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idbranslar`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branslar`
--

LOCK TABLES `branslar` WRITE;
/*!40000 ALTER TABLE `branslar` DISABLE KEYS */;
INSERT INTO `branslar` VALUES (1,'Anestezi'),(2,'Beyin Cerrahı'),(3,'Çocuk Hastalıkları'),(4,'Çocuk Nörolojisi'),(5,'Dermatoloji'),(6,'Endokrinoloji'),(7,'Enfeksiyon Hastalıkları'),(8,'Fizik Tedavi'),(9,'Genel Cerrahi'),(10,'Göğüs Hastalıkları'),(11,'Göz Hastalıkları'),(12,'Hematoloji'),(13,'İç Hastalıklar'),(14,'Kadın Hastalıkları ve Doğum'),(15,'Kalp Damar ve Cerrahisi'),(16,'Kemik Yoğunluğu Ölçümü'),(17,'Kulak Burun Boğaz'),(18,'Nöroloji'),(19,'Ortopedi ve Travmatoloji'),(20,'Plastik ve Estetik'),(21,'Pskiyatri'),(22,'Radyasyon');
/*!40000 ALTER TABLE `branslar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guvenlik`
--

DROP TABLE IF EXISTS `guvenlik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `guvenlik` (
  `idguvenlik` int NOT NULL AUTO_INCREMENT,
  `guv_soru` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idguvenlik`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guvenlik`
--

LOCK TABLES `guvenlik` WRITE;
/*!40000 ALTER TABLE `guvenlik` DISABLE KEYS */;
INSERT INTO `guvenlik` VALUES (1,'İlkokul numaranız?'),(2,'İlkokul öğretmeninizin adı?'),(3,'Tuttuğunuz takım?');
/*!40000 ALTER TABLE `guvenlik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hastalar`
--

DROP TABLE IF EXISTS `hastalar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hastalar` (
  `idhastalar` int NOT NULL AUTO_INCREMENT,
  `tckimlik` varchar(11) DEFAULT NULL,
  `ad` varchar(45) DEFAULT NULL,
  `soyad` varchar(45) DEFAULT NULL,
  `mail` varchar(100) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `cinsiyet` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`idhastalar`),
  UNIQUE KEY `tckimlik` (`tckimlik`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hastalar`
--

LOCK TABLES `hastalar` WRITE;
/*!40000 ALTER TABLE `hastalar` DISABLE KEYS */;
INSERT INTO `hastalar` VALUES (1,'3232','fsf','sf','fsfsf@gmail.com','(044) 427-42','Erkek'),(3,'62434354362','fd','dsds','sff@gmai.com','(434) 353-5353','Erkek');
/*!40000 ALTER TABLE `hastalar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klinik`
--

DROP TABLE IF EXISTS `klinik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `klinik` (
  `idklinik` int NOT NULL AUTO_INCREMENT,
  `klinikadi` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idklinik`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klinik`
--

LOCK TABLES `klinik` WRITE;
/*!40000 ALTER TABLE `klinik` DISABLE KEYS */;
INSERT INTO `klinik` VALUES (1,'Anestezi'),(2,'Beyin Cerrahi'),(3,'Çocuk Hastalıkları'),(4,'Çocuk Nörolojisi'),(5,'Dermatoloji'),(6,'Endokrinoloji'),(7,'Enfeksiyon Hastalıkları'),(8,'Fizik Tedavi'),(9,'Genel Cerrahi'),(10,'Göğüs Hastalıklariı'),(11,'Göz Hastalıkları'),(12,'Hermatoloji'),(13,'İç Hastalıklar'),(14,'Kadın Hastalıklları ve Doğum'),(15,'Kalp Damar ve Cerrahisi'),(16,'Kemik Yoğunluğu Ölçümü'),(17,'Kulak Burun Boğaz'),(18,'Nöroloji'),(19,'Ortopedi ve Travmatoloji'),(20,'Plastik ve Estetik'),(21,'Psikiyatri'),(22,'Radyasyon');
/*!40000 ALTER TABLE `klinik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personel`
--

DROP TABLE IF EXISTS `personel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personel` (
  `idpersonel` int NOT NULL AUTO_INCREMENT,
  `per_ad` varchar(45) DEFAULT NULL,
  `per_soyad` varchar(45) DEFAULT NULL,
  `brans` varchar(45) DEFAULT NULL,
  `klinik` varchar(45) DEFAULT NULL,
  `per_tc` varchar(11) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `gorevtarihi` date DEFAULT NULL,
  `personelresmi` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`idpersonel`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personel`
--

LOCK TABLES `personel` WRITE;
/*!40000 ALTER TABLE `personel` DISABLE KEYS */;
INSERT INTO `personel` VALUES (2,'sfsdf','fsf','Beyin Cerrahı','Beyin Cerrahı','32323','3232','2024-05-14',NULL),(3,'Yılmaz','Vural','Pskiyatri','Pskiyatri','13243353212','(542) 454-2554','2024-05-09','C:\\Users\\ogr2.LAB08.000\\Downloads\\indir.jpg'),(4,'Palyaço','Palyaço','Çocuk Hastalıkları','Çocuk Hastalıkları','41343546436','(646) 636-6533','2024-05-09','C:\\Users\\Public\\ikon\\ani41.gif'),(5,'Hamide','Kızdıran','Dermatoloji','Dermatoloji','24315554524','(523) 524-6366','2024-05-09','C:\\Users\\Public\\kadın personel.png');
/*!40000 ALTER TABLE `personel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `uyelik`
--

DROP TABLE IF EXISTS `uyelik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `uyelik` (
  `iduyelik` int NOT NULL AUTO_INCREMENT,
  `uye_ad` varchar(45) DEFAULT NULL,
  `uye_soyad` varchar(45) DEFAULT NULL,
  `sifre` varchar(45) DEFAULT NULL,
  `guv_soru` varchar(100) DEFAULT NULL,
  `cevap` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`iduyelik`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uyelik`
--

LOCK TABLES `uyelik` WRITE;
/*!40000 ALTER TABLE `uyelik` DISABLE KEYS */;
INSERT INTO `uyelik` VALUES (1,'dsfdf','fd','fdf','İlkokul numaranız?','46','fdff');
/*!40000 ALTER TABLE `uyelik` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-01 17:49:14
