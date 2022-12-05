USE `rockstars_health_check`;

SET FOREIGN_KEY_CHECKS = 0;

TRUNCATE `manager`;
TRUNCATE `template`;
TRUNCATE `question`;
TRUNCATE `response`;
TRUNCATE `answer`;
TRUNCATE `health_check`;

SET FOREIGN_KEY_CHECKS = 1;