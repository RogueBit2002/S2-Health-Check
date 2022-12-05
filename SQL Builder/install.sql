DROP DATABASE IF EXISTS `rockstars_health_check`;

CREATE DATABASE `rockstars_health_check`;

source install/install_table_manager.sql;
source install/install_table_template.sql;
source install/install_table_question.sql;

source install/install_table_health_check.sql;
source install/install_table_response.sql;
source install/install_table_answer.sql;

source install/install_user_root.sql;