USE `rockstars_health_check`;

INSERT INTO `health_check`(`owner_id`, `template_id`, `hash`, `name`) VALUES
	((SELECT `id` FROM `manager` WHERE `email` = "laurens@kruis.name" LIMIT 1),
	1,
	"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
	"My First Health Check"
	);
