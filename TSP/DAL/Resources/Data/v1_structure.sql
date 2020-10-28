################################################
#--- Developed by: Lucas Dario ----------------#
#--- https://www.linkedin.com/in/lucas-dario --#
################################################

CREATE USER 'tsp'@'localhost' IDENTIFIED BY 'tsp@4321';
CREATE DATABASE tsp;
USE tsp;
GRANT ALL PRIVILEGES ON tsp.* TO 'tsp'@'localhost';

CREATE TABLE IF NOT EXISTS category(
	cate_id INT AUTO_INCREMENT PRIMARY KEY,
    cate_name VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS product(
	prod_id INT AUTO_INCREMENT PRIMARY KEY,
    prod_name VARCHAR(255) NOT NULL,
    prod_description VARCHAR(255) NOT NULL,
    prod_price DOUBLE(10,5) NOT NULL
);

CREATE TABLE IF NOT EXISTS productcategory(
	prca_id INT AUTO_INCREMENT PRIMARY KEY,
    prca_category_fk INT NOT NULL,
    prca_product_fk INT NOT NULL,
    FOREIGN KEY (prca_category_fk) REFERENCES category(cate_id),
    FOREIGN KEY (prca_product_fk) REFERENCES product(prod_id)   
);

#############################################################################
DELIMITER $$
CREATE PROCEDURE `SP_SaveCategory`
(
 IN cate_name_ VARCHAR(255)
)
BEGIN
        INSERT INTO category (cate_name) 
               VALUES (cate_name_);
END$$
DELIMITER ;
#############################################################################
DELIMITER $$
CREATE PROCEDURE `SP_ListAllCategory`
()
BEGIN
        SELECT * FROM category;
END$$
DELIMITER ;
#############################################################################
DELIMITER $$
CREATE PROCEDURE `SP_SaveProduct`
(
 IN prod_name_ VARCHAR(255),
 IN prod_description_ VARCHAR(255),
 IN prod_price_ DOUBLE(10,5)
)
BEGIN
        INSERT INTO product (prod_name, prod_description, prod_price) 
               VALUES (prod_name_, prod_description_, prod_price_);
		SELECT LAST_INSERT_ID();
END$$
DELIMITER ;
#############################################################################
DELIMITER $$
CREATE PROCEDURE `SP_SaveCategoryAndProduct`
(
 IN category_id_ INT,
 IN product_id_ INT
)
BEGIN
        INSERT INTO productcategory (prca_category_fk, prca_product_fk) 
               VALUES (category_id_,product_id_);
END$$
DELIMITER ;
#############################################################################
DELIMITER $$
CREATE PROCEDURE `SP_ListAllCategoryAndProduct`
()
BEGIN
	SELECT pc.prca_id, p.prod_name, p.prod_description, p.prod_price, c.cate_name FROM productcategory pc 
		INNER JOIN product p ON pc.prca_product_fk = p.prod_id
			INNER JOIN category c ON pc.prca_category_fk = c.cate_id;
END$$
DELIMITER ;
#############################################################################
DELIMITER $$
CREATE PROCEDURE `SP_DeleteProduct`
(
 IN prca_id_ INT
)
BEGIN
	DELETE FROM productcategory WHERE prca_id = prca_id_;
END$$
DELIMITER ;
#############################################################################










###APOIO
SELECT * FROM category;
SELECT * FROM product;
SELECT * FROM productcategory;

drop table productcategory;
drop table product;
drop table category;
