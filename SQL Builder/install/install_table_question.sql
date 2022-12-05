USE `rockstars_health_check`;

DROP TABLE IF EXISTS `question`;

CREATE TABLE `question` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
	`template_id` INT unsigned NOT NULL,
    `header` NVARCHAR(64) NOT NULL UNIQUE,
    `description` NVARCHAR(512) NOT NULL,
    PRIMARY KEY (`id`),
	FOREIGN KEY (`template_id`) REFERENCES `template`(`id`)
);