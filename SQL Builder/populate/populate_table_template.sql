USE `rockstars_health_check`;

INSERT INTO `template`(`name`) VALUES("Default Template");

INSERT INTO `question`(`template_id`, `header`, `description`)
    VALUES(
        (SELECT `id` FROM `template` WHERE `name`="Default Template"),
        "Question 1", "This is the first question."
    );
INSERT INTO `question`(`template_id`, `header`, `description`)
	VALUES(
		(SELECT `id` FROM `template` WHERE `name`="Default Template"),
		"Question 2", "This is the second question."
	);