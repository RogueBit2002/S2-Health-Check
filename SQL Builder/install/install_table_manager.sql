USE `rockstars_health_check`;

DROP TABLE IF EXISTS `manager`;

CREATE TABLE `manager` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `email` NVARCHAR(64) NOT NULL UNIQUE,
    `password` NVARCHAR(64) NOT NULL,
    PRIMARY KEY (`id`)
);