USE `rockstars_health_check`;

DROP TABLE IF EXISTS `health_check`;

CREATE TABLE `health_check` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
	`owner_id` INT unsigned NOT NULL,
    `hash` VARCHAR(32) NOT NULL UNIQUE,
	`template_id` INT unsigned NOT NULL,
	`name` NVARCHAR(64) NOT NULL, 
    PRIMARY KEY (`id`),
	FOREIGN KEY (`owner_id`) REFERENCES `manager`(`id`),
	FOREIGN KEY (`template_id`) REFERENCES `template`(`id`)
);