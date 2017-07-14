-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 11, 2014 at 11:59 AM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `project_database`
--
CREATE DATABASE IF NOT EXISTS `project_database` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `project_database`;

-- --------------------------------------------------------

--
-- Table structure for table `userfile`
--

CREATE TABLE IF NOT EXISTS `userfile` (
  `email` varchar(100) NOT NULL,
  `filename` varchar(200) NOT NULL,
  `filepath` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `unique_id` varchar(23) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `username` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `encrypted_password` varchar(80) NOT NULL,
  `salt` varchar(10) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `public_key` varchar(800) NOT NULL,
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=59 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`uid`, `unique_id`, `firstname`, `lastname`, `username`, `email`, `encrypted_password`, `salt`, `created_at`, `public_key`) VALUES
(46, '536bf5713165a7.77699944', 'Nikunj', 'Parasar', 'nikunj', 'n.p@g.com', 'b6vtWOyAQAaInLemvjq3MqnZHggzYzQ1MDAzNmY4', '3c450036f8', '2014-05-09 02:51:53', 'RSA Public Key\n            modulus: c9817a0fc321ce8efa178c6b011a147ff9d6d9f64212ae038ff1cb260ff57a864fe483fe4ea443fec4e61914c0d43caabaf7c49a0c48cb753a3723afe46dd0932b656d886752622b4af1e96188672193603aa17acb1b1a0dcd19b47e0252e8e254ffca65014f1112a94af87b3bec36b1539a0f92c36512a9db84b7acdf2fabf5cfd5b8b55a2b60813f87e70e84178d9c772552550a706381cdf1cc3424ac62841e9835955a091597cceeccafa10e8c4746a73114b3cde1577c2640c10a26faa4724812f0f5133ae78938faf5d9f73bccc3bc3cc889680f903785372ffd70798a1adb2feacb5f2f584808485a7fcc7a54157dce4edce6d0427f278b734e664283\n    public exponent: 10001\n'),
(53, '536cf2b6dd8492.12114606', 'bhavya', 'dalwari', 'bhavya', 'b@g.com', 'CPFSQ/iLm/SqgIkyd0JrOQRfe6U4MTViZGY5Mzkw', '815bdf9390', '2014-05-09 20:52:30', 'RSA Public Key\n            modulus: c453f98f522cd36a6a549cbccb61a6d018ca55601f4e1ce18aaf49735c21be27e9c5b6af18c346c387bab41d00d824edda9d15f17adf9be2289f231dad7da3c9\n    public exponent: 10001\n'),
(54, '536cf38292a1d4.96963829', 'parth', 'kaparia', 'parth', 'k@g.com', 'DKE7elwWT0WTGawtwurlos5KuG02NDNlMDE0NDNi', '643e01443b', '2014-05-09 20:55:54', 'RSA Public Key\n            modulus: a56f78a049521a646693c9a7327787b3fb9d31ad75f3a5857a94172e5e37da47e6ce5cd5d568d46c86e1558f3b474f979f28b236b41616b5a7697259e2365d4b\n    public exponent: 10001\n'),
(55, '536da9e91f57e6.72177742', 'abcd', 'ef', 'lkjhg', 'n@g.com', 'yCUsQDqQJXxPeg/LSQRmcy5aSTIzNWE0NWIzY2Y5', '35a45b3cf9', '2014-05-10 09:54:09', 'RSA Public Key\n            modulus: db34fe985e4612fa4d3b67541e0fb5e0fb51f57cf1e3bdc1a67c212af829ae44ebf14f7b08b1c0a4cb5ec8aa22589891\n    public exponent: 10001\n'),
(56, '536dc1fb120d42.36925004', 'nirav', 'parekh', 'nirav', 'ni@g.com', '26Ve/Xd7TMKAiaTAPF7gZcIYBz5iZWZhMmIxOTgy', 'befa2b1982', '2014-05-10 11:36:51', 'RSA Public Key\n            modulus: afe470b56c419194c502bd0d6d60440a0b606e68d18b00df6acaaf43fa8231c4190177045a785a15066601decbf1597f\n    public exponent: 10001\n'),
(57, '536dced69809a9.82765461', 'alay', 'vakil', 'alaya', 'al@g.com', 'FgSVYh4AUiYuvMnj3DPKGyJdrlAzZGQ4MzEzODM1', '3dd8313835', '2014-05-10 12:31:42', 'RSA Public Key\n            modulus: e16b0c76b835c6aed2b490714dba004b875db462038a3073a132d022855215f1b447821135762cc40e4c43bd71a3e11b\n    public exponent: 10001\n'),
(58, '536dcf23ec4026.33142898', 'meet', 'dabhi', 'meeta', 'm@g.com', '3KHc87UpfdodZNfLGmSrzrUQ9zw0MjVjZDMyMTQ0', '425cd32144', '2014-05-10 12:32:59', 'RSA Public Key\n            modulus: bbee0ca1b7f185d776530cd1f8c88a1d\n    public exponent: 10001\n');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
