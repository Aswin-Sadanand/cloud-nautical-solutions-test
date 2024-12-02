INSERT INTO CUSTOMERS (CustomerId, Firstname, Lastname, Email, HouseNo, Street, Town, PostCode)
VALUES 
('C34454', 'Bob', 'Marshal', 'bob@aol.com', '1A', 'Uppingham Gate', 'Uppingham', 'LE15 9NY'),
('R34788', 'Jack', 'Ross', 'jack@yahoo.com', '4B', 'Strabrokeway', 'Wortley', 'LS12 4NB'),
('A99001', 'Chris', 'Gregory', 'chris@gmail.com', '7A', 'Marsh Lane', 'Leeds', 'LS9 7NE'),
('X45001', 'Ken', 'Martin', 'ken@aol.com', '32B', 'Harehills', 'York', 'LE15 9NY');

go
INSERT INTO PRODUCTS (PRODUCTNAME, COLOUR, SIZE)
VALUES 
('Tennis Ball', 'Yellow', 'S'),
('Tennis Net', 'White', 'XL'),
('Tennis Racket', 'White', 'L'),
('Tennis Gear', 'White', 'XL');
GO
GO

GO
INSERT INTO ORDERS (CUSTOMERID, ORDERDATE, DELIVERYEXPECTED, CONTAINSGIFT)
VALUES 
('R34788', '2023-05-03', '2023-05-10', 0),
('C34454', '2023-06-07', '2023-06-15', 0),
('A99001', '2023-07-10', '2023-07-25', 1),
('R34788', '2023-09-20', '2023-09-30', 0),
('R34788', '2023-10-28', '2023-11-21', 1);
GO
INSERT INTO ORDERITEMS (ORDERID, PRODUCTID, QUANTITY, PRICE)
VALUES 
(1, 5, 3, 45),
(1, 5, 1, 120),
(2, 6, 1, 150),
(2, 7, 1, 150),
(3, 8, 5, 65),
(3, 5, 1, 120),
(4, 6, 2, 30),
(5, 7, 1, 75);
GO
go


GO

select * from customers
select * from products
select * from orders
select * from ORDERITEMS
