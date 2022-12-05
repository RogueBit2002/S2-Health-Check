USE `rockstars_health_check`;

INSERT INTO `template`(`name`) VALUES("Basic Template");

INSERT INTO `question`(`template_id`, `header`, `description`)
    VALUES(
        (SELECT `id` FROM `template` WHERE `name`="Basic Template"),
        "Question 1", "This is the first question"
    );