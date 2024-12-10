
GO
ALTER PROCEDURE [GetRecentOrdersByCustomer]    
    @CustomerId NVARCHAR(50),    
    @Email NVARCHAR(100)    
AS    
BEGIN    
    IF NOT EXISTS (SELECT Count(1) FROM CUSTOMERS WHERE CUSTOMERID = @CustomerId AND EMAIL = @Email)    
    BEGIN    
           SELECT 
            'Customer not found or invalid credentials' AS errorMessage,    
            JSON_QUERY('[]') AS orderDetails    
        FOR JSON PATH, WITHOUT_ARRAY_WRAPPER;    
        RETURN;    
    END    
    SELECT 
        '' AS errorMessage, 
        
    (SELECT     
        C.FIRSTNAME AS 'customer.firstName',    
        C.LASTNAME AS 'customer.lastName',      
        O.ORDERID AS 'order.orderNumber',    
        O.ORDERDATE AS 'order.orderDate',    
        O.DELIVERYEXPECTED AS 'order.deliveryExpected',      
        (SELECT     
            CASE WHEN O.CONTAINSGIFT=1 THEN 'GIFT' ELSE P.PRODUCTNAME END AS 'product',    
            OI.QUANTITY AS 'quantity',    
            OI.PRICE AS 'priceEach'    
         FROM ORDERITEMS OI    
         INNER JOIN PRODUCTS P ON OI.PRODUCTID = P.PRODUCTID    
         WHERE OI.ORDERID = O.ORDERID    
         FOR JSON PATH) AS 'order.orderItems'    
    FROM ORDERS O    
    INNER JOIN CUSTOMERS C ON O.CUSTOMERID = C.CUSTOMERID    
    WHERE O.CUSTOMERID = @CustomerId    
      AND C.EMAIL = @Email  
     ORDER BY O.ORDERDATE DESC
     OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY  
    FOR JSON PATH) AS orderDetails    
    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER; 
END

GO