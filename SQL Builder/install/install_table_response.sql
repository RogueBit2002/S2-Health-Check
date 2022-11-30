USE `rockstars_health_check`;

DROP TABLE IF EXISTS `response`;

CREATE TABLE `response` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `email` NVARCHAR(64) NOT NULL UNIQUE,
	`health_check_id` INT unsigned NOT NULL,
    PRIMARY KEY (`id`),
	FOREIGN KEY (`health_check_id`) REFERENCES `health_check`(`id`)
);