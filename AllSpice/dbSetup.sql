-- Active: 1688678157120@@SG-lacy-trader-563-7673-mysql-master.servers.mongodirector.com@3306@VinceDb
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(250) NOT NULL,
  instructions VARCHAR(300) NOT NULL,
  img VARCHAR(500) NOT NULL,
  category VARCHAR(225) NOT NULL DEFAULT "misc", 
  description VARCHAR (225) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

-- //ANCHOR - vvv ingredients table using creatorId

-- CREATE TABLE IF NOT EXISTS ingredients(
--   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
--   name VARCHAR(300) NOT NULL,
--   quantity VARCHAR(225) NOT NULL,
--   recipeId INT NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
--   FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
-- ) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(300) NOT NULL,
  quantity VARCHAR(225) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS favorites(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  recipeId INT NOT NULL,
  accountId VARCHAR(255) NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

