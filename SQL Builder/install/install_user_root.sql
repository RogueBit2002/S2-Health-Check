DROP USER IF EXISTS 'rhc_admin'@'localhost';

CREATE USER 'rhc_admin'@'localhost' IDENTIFIED WITH mysql_native_password BY 'r00t';

GRANT ALL PRIVILEGES ON `rockstars_health_check`.* TO 'rhc_admin'@'localhost';