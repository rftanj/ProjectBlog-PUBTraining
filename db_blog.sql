/*
SQLyog Enterprise - MySQL GUI v7.02 
MySQL - 5.5.5-10.4.17-MariaDB : Database - db_blog
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_blog` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `db_blog`;

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `__efmigrationshistory` */

insert  into `__efmigrationshistory`(`MigrationId`,`ProductVersion`) values ('20210714150326_BlogMigrate','5.0.8'),('20210715055629_HomeExample','5.0.8'),('20210715140414_RolesMigrate','5.0.8'),('20210716013503_AccessMigrate','5.0.8'),('20210717044956_BlogNewMigrate','5.0.8');

/*Table structure for table `access` */

DROP TABLE IF EXISTS `access`;

CREATE TABLE `access` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` text DEFAULT NULL,
  `Name` text DEFAULT NULL,
  `Password` text DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Access_RoleId` (`RoleId`),
  CONSTRAINT `FK_Access_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `access` */

insert  into `access`(`Id`,`Username`,`Name`,`Password`,`RoleId`) values (1,'zky','Rizky Fardiansyah','12345',1),(4,'putri','Putri Aulia','12345',2),(5,'fitri','Fitriani','12345',1);

/*Table structure for table `blog` */

DROP TABLE IF EXISTS `blog`;

CREATE TABLE `blog` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` text DEFAULT NULL,
  `Content` text DEFAULT NULL,
  `Author` text DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `Picture` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

/*Data for the table `blog` */

insert  into `blog`(`Id`,`Title`,`Content`,`Author`,`CreatedDate`,`Status`,`Picture`) values (1,'Maaf Barcelona, Mourinho Gak Butuh Pjanic','Barcelona - Barcelona lagi berusaha menjual Miralem Pjanic. Sang pemain dikabarkan sempat ditawarkan ke AS Roma, tapi ditolak Jose Mourinho mentah-mentah.\r\nBarcelona sedang mengalami masalah keuangan dan harus melakukan cuci gudang untuk mengurangi beban gaji, serta mendapat cuan. Miralem Pjanic jadi salah satu pemain yang masuk dalam daftar penjualan di musim panas ini.\r\n\r\nPjanic baru bergabung ke Barcelona pada musim panas 2020. Dia pindah ke Camp Nou dalam kesepakatan pertukaran kepada Juventus yang melibatkan Arthur Melo.\r\n\r\nSelama satu musim memperkuat Blaugrana, Pjanic nyatanya jarang jadi pilihan utama Ronald Koeman.\r\n\r\nDi sepanjang musim lalu, gelandang asal Bosnia & Herzegovina cuma tampil 30 kali di semua kompetisi dan sama sekali tak berkontribusi gol atau assist.\r\n\r\nDilansir dari Marca, Barcelona sudah mencoba menawarkan Miralem Pjanic ke beberapa klub di Italia. Sang pemain, memang mengutarakan kalau cuma mau kembali ke Italia untuk melanjutkan kariernya.\r\n\r\nApalagi, Pjanic cukup sukses selama membela Juventus pada periode 2016-2020 dengan meraih empat trofi. AS Roma pun jadi salah satu klien yang diketuk pintunya oleh Barcelona.\r\nMiralem Pjanic sendiri pernah memperkuat AS Roma pada tahun 2011 sampai 2016. Barcelona pun mematok harga yang tidak mahal, hanya 20 juta Euro atau setara Rp 342 miliar.\r\n\r\nApa daya, tawaran tersebut langsung ditolak mentah-mentah oleh pelatih baru Roma, Jose Mourinho. Mourinho belum butuh-butuh amat pemain baru.\r\n\r\nApalagi, AS Roma juga lagi menghemat pengeluaran. Opsi pembelian pemain, harus benar-benar diputuskan matang-matang.','MrFATA','2021-07-15 00:00:00',1,'Pjanic.jpeg'),(2,'Ronaldinho: Kylian Mbappe Mirip Ronaldo','Jakarta - Ronaldinho mengomentari pemain Timnas Prancis, Kylian Mbappe. Bintang Paris Saint-Germain itu disebut seperti Ronaldo.\r\nMbappe menjadi salah satu pemain muda yang menonjol dalam setengah dekade ini. Usai menjalani petualangan yang sip bersama AS Monaco, dia bersinar bersama Paris Saint-Germain.\r\n\r\nBersama PSG, Mbappe memenangi 10 trofi di ajang domestik. Untuk Liga Champions, dia baru sebatas menjadi runner-up pada 2019/2020.\r\nMbappe sudah meraih prestasi tinggi bersama Prancis. Dia menggapai trofi Piala Dunia pada 2018, saat itu dia baru berusia 19 tahun.\r\n\r\nRonaldinho : mengungkap ada kemiripan antara Mbappe dengan eks rekan setimnya di Brasil, Ronaldo.\r\nRonaldo merupakan salah satu striker terbaik yang pernah dimiliki oleh Selecao. Dia aktor utama Brasil saat menjadi juara Piala Dunia 2002.\r\n\"Dia sedikit mengingatkan saya pada Ronaldo. Saya suka dengan anak ini. Dia merupakan pemain hebat, sangat bertalenta,\" kata Ronaldinho kepada France Football.\r\n\"Dia mempunyai semua kemampuan untuk menaklukkan Ballon d\'Or. Saya suka melihat permainannya, terutama saat Neymar bermain bersamanya.\"\r\n\"Dalam hal pemain top, Paris dilayani sangat baik,\" kata dia menambahkan.\r\nSejauh ini, bermain sebanyak 171 kali bersama PSG. Dia membukukan sebanyak 132 gol untuk Les Parisiens.\r\nDi Timnas, Mbappe sudah mengoleksi sebanyak 48 caps. Ada 17 gol yang disumbangkan Mbappe, salah satunya di final Piala Dunia 2018 saat Prancis mengalahkan Kroasia.','Zky','2021-07-15 00:00:00',0,'Mbappe.jpeg'),(3,'Cara Mudah Hapus Pertemanan Di Facebook','Jakarta, CNN Indonesia -- Pengguna Facebook dapat mengatur jaringan pertemanan yang dimiliki. Anda dapat menambahkan teman baru maupun menghapus pertemanan yang sudah ada. Cara menghapus pertemanan di Facebook dapat dilakukan dengan mudah.\r\nAnda dapat menghapus pertemanan dengan akun yang tidak dikenali, akun yang sudah tidak aktif, akun yang mengganggu, atau akun yang tidak sesuai dengan nilai Anda seperti kerap membagikan kabar hoaks.\r\n\r\nSebelum memutuskan untuk unfriend atau menghapus pertemanan di Facebook, ketahui beberapa hal berikut ini:\r\nAkun yang dihapus pertemanannya tidak akan mendapatkan notifikasi bahwa mereka dihapus dari pertemanan Anda.\r\n\r\nJika menghapus pertemanan dengan seseorang, Anda juga dihapus dari daftar teman akun tersebut.\r\nAnda tidak akan lagi menerima notifikasi update dari orang tersebut.\r\nAnda masih tetap bisa melihat profilnya apabila tidak diprivasi.\r\nApabila ingin berteman kembali, dapat melakukan permintaan pertemanan baru.\r\nTerdapat beberapa langkah menghapus pertemanan sesuai dengan petunjuk Facebook yang dapat dicoba di PC ataupun ponsel.\r\n1. Buka akun Facebook melalui PC atau ponsel\r\n2. Ketik nama orang yang akan di unfriend pada kolom pencarian\r\n3. Klik dan kunjungi laman profil akun tersebut\r\n4. Klik ikon Teman di bagian kanan atas\r\n5. Pilih Hapus Pertemanan\r\n6. Lalu Konfirmasi.\r\n\r\nPerlu diketahui bahwa cara hapus teman di Facebook tidak sama dengan blokir. Meski sudah terhapus, kedua akun masih bisa mengunjungi halaman profil satu sama lain jika tidak diprivasi.\r\n\r\nSedangkan jika blokir pertemanan di Facebook, maka kedua akun tidak dapat melihat halaman akun yang lain.\r\n\r\nItulah cara menghapus pertemanan di Facebook yang dapat Anda lakukan untuk mengatur jaringan pertemanan Anda.\r\n','Fitriani','2021-07-16 00:00:00',1,'ilustrasi-facebook-2_169.jpeg'),(5,'Amazon Ambil Alih Tim Satelit Internet Milik Facebook','Amazon dikabarkan mengakuisisi tim yang menggarap satelit milik Facebook. Tim tersebut fokus pada proyek pengembangan koneksivitas internet dari satelit orbit bumi rendah (Low Earth Orbit/LEO). Tidak disebutkan berapa nilai akuisisi ini. Menurut informasi dari juru bicara Facebook, tim satelit Facebook yang berbasis di Los Angeles akan pindah ke Proyek Kuiper besutan Amazon pada bulan April mendatang. Akuisisi ini merupakan pertanda bahwa Facebook menyerah dengan proyek penyediaan koneksivitas internet ke pelosok menggunakan satelit. Ambisi Facebook menyediakan koneksi internet ke daerah pelosok sudah dimulai sejak 2014. Saat itu, Facebook menggarap proyek Aquila yang akan menyebarluaskan koneksi internet menggunakan drone. Indonesia juga sempat ditawari Facebook untuk menggunakan pesawat nirawak ini pada tahun 2016. Namun proyek ini disetop dua tahun kemudian.\r\nSalah satu alasannya adalah adanya kendala spektrum. Spektrum yang tersedia di platform tersebut tidak sesuai dengan spesifikasi broadband yang dibutuhkan. Gagal dengan Aquila, Facebook membuat proyek baru bernama Athena. Tujuannya sama, menyebarluaskan internet ke daerah pelosok, tapi, kali ini mengandalkan satelit.\r\nSama seperti Facebook, Amazon juga berambisi menghadirkan koneksi internet dengan satelit. Ambisi ini muncul sejak 2019 lalu. Perusahaan yang didirikan Jeff Bezos itu kemudian berinvestasi 10 miliar dollar AS atau sekitar Rp 145 triliun untuk meluncurkan 3.236 satelit ke LEO tahun 2029. Tujuannya pun sama, yakni menghadirkan koneksi internet ke daerah pelosok. Komisi perdagangan federal AS (FCC) telah memberi restu untuk proyek Amazon itu pada tahun lalu. Amazon berencana meluncurkan separuh satelitnya pada tahun 2026.\r\n\r\nenurut laporan The Information yang dirangkum KompasTekno dari The Verge, Jumat (16/7/2021), Amazon dikabarkan membangun sebuah lab di Redmond, Washington untuk proyek satelit ini. Saat ini, sudah ada 500 pegawai yang bekerja di sana. Taun lalu, Amazon mengungkap desain antena yang akan digunakan pelanggan layanan internet satelitnya. Belum diketahui jadwal pasti peluncuran satelit Amazon. Namun, April lalu Amazon mengonfirmasi penandatanganan perjanjian dengan operator roket United Launch Alliance (ULA) untuk sembilan peluncuran roket. Selain Amazon, SpaceX juga mengembangkan proyek yang sama bernama Starlink. Saat ini, internet satelit Starlink sudah bisa dipesan dan rencananya akan meluncur secara global pada bulan Agustus mendatang.\r\n','Fitriani','2021-07-17 20:20:42',1,'60970bfb46a28.jpg'),(6,'Daftar Negara dengan Kecepatan Internet 5G Terkencang','Situs penyedia layanan pengukuran kecepatan internet, Speedcheck, merilis laporan terbaru terkait daftar negara di dunia dengan kecepatan unduh 5G terkencang. Laporan tersebut mengungkap hasil tes kecepatan download 5G di berbagai negara, termasuk negara di wilayah Asia, Amerika, Eropa, hingga Timur Tengah. Dari laporan tersebut terungkap bahwa Korea Selatan adalah negara dengan kecepatan 5G terkencang, dengan rata-rata kecepatan unduhnya mencapai 449,31 Mbps. Hasil itu didapatkan setelah Speedcheck melakukan tes kecepatan 5G di 19 negara selama bulan Februari hingga Maret 2021\r\nKecepatan 5G di Korea Selatan itu tercatat tiga kali lebih cepat dari kecepatan 5G di Taiwan, yang menempati posisi kedua sebagai negara dengan 5G terkencang di dunia. Taiwan sendiri tercatat memiliki rata-rata kecepatan download sebesar 135,36 Mbps.\r\n\r\nSetelah Korea Selatan dan Taiwan, 8 negara dengan kecepatan 5G terkencang di dunia secara berturut-turut adalah Inggris Raya, Jepang, Jerman, Austria, Swiss, Belanda, Australia, dan Kuwait. Menariknya, dari laporan Speedcheck diketahui, Amerika Serikat tak berhasil masuk ke dalam daftar 10 besar negara dengan kecepatan 5G terkencang di dunia. Negeri Paman Sam ini hanya berhasil menempati posisi 16, dengan rata-rata kecepatan unduh yang hanya mencapai 43,34 Mbps.','Putri','2021-07-17 00:00:00',1,'2784457558.jpg');

/*Table structure for table `role` */

DROP TABLE IF EXISTS `role`;

CREATE TABLE `role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

/*Data for the table `role` */

insert  into `role`(`Id`,`Name`) values (1,'Admin'),(2,'User');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
