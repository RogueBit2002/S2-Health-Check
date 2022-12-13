USE `rockstars_health_check`;

INSERT INTO `template`(`name`) VALUES("Default Template");

INSERT INTO `question`(`template_id`, `header`, `description`)
    VALUES(
        (SELECT `id` FROM `template` WHERE `name`="Default Template"),
        "Cooperation", "How would you rate the teamwork?"
    );
INSERT INTO `question`(`template_id`, `header`, `description`)
	VALUES(
		(SELECT `id` FROM `template` WHERE `name`="Default Template"),
		"Vibe", "How would you rate the atmosphere?"
	);