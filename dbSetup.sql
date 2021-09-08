CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE contractor(  
    id int NOT NULL primary key AUTO_INCREMENT,
    name varchar(255) NOT NULL
  ) default charset utf8 comment '';
CREATE TABLE job(  
    id int NOT NULL primary key AUTO_INCREMENT,
    name varchar(255) NOT NULL,
    companyId INT NOT NULL comment 'Company ID for company',
    FOREIGN KEY (companyId) REFERENCES company(id) ON DELETE CASCADE,
    contractorId INT NOT NULL comment 'Contractor ID for company',
    FOREIGN KEY (contractorId) REFERENCES contractor(id) ON DELETE CASCADE
  ) default charset utf8 comment '';
CREATE TABLE company(  
    id int NOT NULL primary key AUTO_INCREMENT,
    name varchar(255) NOT NULL
) default charset utf8 comment '';