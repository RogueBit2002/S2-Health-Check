USE `rockstars_health_check`;

DROP TABLE IF EXISTS `template`;

CREATE TABLE `template` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `name` NVARCHAR(64) NOT NULL UNIQUE,
    PRIMARY KEY (`id`)
);