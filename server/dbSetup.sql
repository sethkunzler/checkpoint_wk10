-- Active: 1711142519797@@35.87.147.206@3306@forgiving_monk_a379d6_db
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

-- #region Account executables

SELECT * FROM accounts;

-- #endregion 

CREATE TABLE recipes(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(50) NOT NULL COMMENT 'Recipe Title',
  instructions VARCHAR(1000) NOT NULL,
  img VARCHAR(500) NOT NULL,
  category SET("breakfast", "lunch", "dinner", "meal", "entrees", "dessert", "appetizer", "snack", "salads", "soup", "pasta", "sandwich", "cheese", "coffee", "fish", "beef", "burger", "sausage", "french", "german", "russian", "mexican", "italian", "chinese", "japanese", "thai") NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
);

-- #region Recipe executables 

DROP TABLE recipes;


SELECT * FROM recipes;

-- #endregion 

CREATE TABLE ingredients(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL COMMENT 'Ingredient Name',
  quantity VARCHAR(255) NOT NULL COMMENT 'Amount of Ingredient to be used',
  recipeId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
);

-- #region ingredients executables

DROP TABLE ingredients; 

-- #endregion

CREATE TABLE favorites(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  recipeId INT NOT NULL,
  accountId VARCHAR(255) NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  UNIQUE(recipeId, accountId)
);

-- #region "favorites" executables
DROP TABLE favorites;
-- #endregion 