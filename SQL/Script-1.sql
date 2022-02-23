
create table Customer(
custID int identity(1,1) primary key,
custName varchar(50),
custAddress varchar(50),
custEmail varchar(50),
);

create table Product(
prodID int identity(1,1) primary key,
prodName varchar(10),
prodDescription varchar(60),
prodPrice smallmoney,
);

alter table Product 
alter column prodPrice int



select * from Product


create table Orders(
orderID int identity(1,1) primary key,
orderLocation int,
orderPrice smallmoney
);

alter table Orders 
add products varchar(200);

update Orders 
set products = 'Leash'
where orderID = 1;

insert into Orders 
values (1,65.0000, 'Ldog')

create table LineItems(
prodID int foreign key references Product(prodID),
orderID int foreign key references Orders(OrderID),
Quantity int
);



drop table LineItems

insert into LineItems 
values (3,1,1);


alter table Orders
add orderName varchar(20)

create table StoreFront(
storeID int identity(1,1) primary key,
storeName varchar(30),
storeAddress varchar(60)
);
select * from StoreFront where storeID = 2

insert into StoreFront 
values ('Furr Babies - Bebop', '123 Bebop Place, Maryville, Tennessee 37816'),('Furr Babies - Swordfish', '432 Swordfish Lane, Dallas, Texas 78953'),('Furr Babies - Hammerhead', '947 Hammerhead Street, Kalamazoo, Michigan 45678')

create table Customer_Order(
custID int foreign key references Customer(custID),
orderID int foreign key references Orders(orderID),
quantity int
);

insert into Customer_Order
values (1,1,2);

create table Store_Order(
storeID int foreign key references StoreFront(storeID),
orderID int foreign key references Orders(orderID)
);

insert into Store_Order 
values (1,1)

create table StoreInventory(
storeID int foreign key references StoreFront(storeID),
prodID int foreign key references Product(prodID)
)
alter table StoreInventory 
add Quantity int

update StoreInventory 
set Quantity = Quantity + 10
where prodID = 1

insert into StoreInventory
values (1,1,100), (1,2,100), (1,3,100), (1,4,75), (1,5,75), (1,6,75), (1,7,50),(1,8,50),(1,9,50),(1,10,50),(1,11,50),(1,12,50),(1,13,50),
(2,1,100), (2,2,100), (2,3,100), (2,4,75), (2,5,75), (2,6,75), (2,7,50),(2,8,50),(2,9,50),(2,10,50),(2,11,50),(2,12,50),(2,13,50),
(3,1,100), (3,2,100), (3,3,100), (3,4,75), (3,5,75), (3,6,75), (3,7,50),(3,8,50),(3,9,50),(3,10,50),(3,11,50),(3,12,50),(3,13,50)


insert into Customer
values ('Rhea', '123 Fetch Alot Lane', 'rhea@dogmail.com')

--select max(e.empId) from Employee e How to retrieve last entry in a table since our ID are going to be 1st = lowest number and last = highest number.

--Inner joining Product, StoreFront, StoreInventory 
select sf.storeName, p.prodName, p.prodID, p.prodDescription, si.Quantity from StoreFront sf 
inner join StoreInventory si on sf.storeID = si.storeID 
inner join Product p on p.prodID = si.prodID
where sf.storeID = 1



--where sf.storeName = 'Furr Babies - Bebop'
--inner join p.prodName = si.Quantity
select * from StoreFront

--Joining Customer, Orders, Customer_Order tables
select c.custName, o.orderID, o.orderLocation, o.products, o.orderPrice from Customer c 
inner join Customer_Order co on c.custID = co.custID 
inner join Orders o on o.orderID = co.orderID

--Joining Order, LineItems, and Products TABLES 
select p.prodID, p.prodName, li.Quantity, o.orderID from Product p
inner join LineItems li on p.prodID = li.prodID
inner join Orders o on o.orderID = li.orderID

--Joining Order, Order_Store, and StoreFront TABLES 
select sf.storeID, o.orderID from StoreFront sf 
inner join Store_Order so on sf.storeID = so.storeID 
inner join Orders o on o.orderID = so.orderID

select p.prodPrice, li.Quantity from Product p
inner join LineItems li on p.prodID = li.prodID 
where p.prodID = 3

select p.prodID, p.prodName, p.prodDescription, p.prodPrice  
from Product p, StoreInventory s 
where p.prodID = s.prodID and s.storeID = 1

select * from Customer
select * from StoreInventory si 
update StoreInventory 
set Quantity = Quantity -1
where storeID = 1
and prodID = 1

select * from Orders
insert into Orders 
values (1, 100,1)
select * from LineItems
insert into LineItems 
values (1,6,2)

select * from Orders
where custID = 1
select * from Store_Order

insert into Store_Order 
values (3,12), (1,13),(2,14),(2,15),(1,16),(1,17),(2,18),(2,19),(2,20),(2,21),(3,22),(2,23),(1,24),(3,25),(2,26)
select * from Store_Order 
where storeID = 2

