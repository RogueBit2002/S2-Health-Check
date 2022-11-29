DROP DATABASE IF EXISTS `rockstars_health_check`;

CREATE DATABASE `rockstars_health_check`;

source install/install_table_manager.sql;
source install/install_table_health_check.sql;
source install/install_user_root.sql;




USE `rockstars_health_check`;

DROP TABLE IF EXISTS `question`;

CREATE TABLE `question` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `text` VARCHAR(32) NOT NULL UNIQUE,
    PRIMARY KEY (`id`)
);

INSERT INTO `question`(`text`) VALUES
	("Is Fontys kut?");