USE `rockstars_health_check`;

DROP TABLE IF EXISTS `answer`;

CREATE TABLE `answer` (
    `response_id` INT unsigned NOT NULL,
	`question_id` INT unsigned NOT NULL,
    `value` TINYINT NOT NULL UNIQUE,
    FOREIGN KEY (`response_id`) REFERENCES `response`(`id`),
	FOREIGN KEY (`question_id`) REFERENCES `question`(`id`)
);