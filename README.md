PROJECT NAME: Furr-Babies Pet Supplies Store

Project Description
The store api is a RESTful API that helps customers purchase products from your business.
Designed with functionality that would make virtual shopping much simpler! Customer features include: account creation, order placements, and order history.
It also comes with admin functionality that let's store owners replenish inventory and view the specific store's order history!


Technologies Used
C#
T-SQL
ADO.NET
Xunit
Moq
Serilog
Azure
Azure DevOps
ASP.NET webapi

Features
List of features ready and TODOs for future development
-Create Customer account
-Search for Customer information
-Verify Customer/Manager credentials
-Display order details
-Place order to store location
-View customer order history
-View store order history
-View location inventory
-Customer can purchase mutiple products
-Manager can replinish inventory

To-do list:
-Add the front-end using angular
-Add update order
-Add delete order
-Add more products


Getting Started
Deployed Application Link Below:
(https://github.com/220118-Reston-NET/Chad-Solomon-P1.git) 


(Sample Rest API Request)
https://furr-babbies-pet-supply.azurewebsites.net/api/StoreFront/GetInventoryByStoreID?id=1

![storeinventory](https://user-images.githubusercontent.com/96600982/159782968-b283ede1-da90-4d86-a317-0c34f9aaecf3.png)

![GetCustomerInfo](https://user-images.githubusercontent.com/96600982/159783179-eb9db18d-7987-4bc6-bad4-9aeada54080b.png)





Usage
Once you have navigated to the URL Above you will just need to adjust the enpoints to the page or function you would like to view.
Below are a list of End Points to enter into the URL and what they are for.

-Create Customer Profile = https://furr-babbies-pet-supply.azurewebsites.net/api/Customer/AddCustomer?CustID=1&Name=Roxy&Address=547 Rock Lane&Email=roxy@dogmail.com&Password=RockOne
-Get All Customer Information = https://furr-babbies-pet-supply.azurewebsites.net/api/Customer/GetAllCustomers
-Search Customer Order History = https://furr-babbies-pet-supply.azurewebsites.net/api/Customer/CustomerOrderHistoryFilter?p_custID=3&p_filter=TotalPrice
-Update Customer Information = https://furr-babbies-pet-supply.azurewebsites.net/api/Customer/UpdateCustomer?_custID&CustID&Name=Sam&Address=741 Good Boy Place&Email=sampson@dogmail.com&Password=GoodBoy
-Post Order = https://furr-babbies-pet-supply.azurewebsites.net/api/Customer/PlaceOrder?_orderLocation=1&_custID=24
-Get Order Details = https://furr-babbies-pet-supply.azurewebsites.net/api/Customer/OrderDetails?p_orderID=40
-Get Store Inventory by Id = https://furr-babbies-pet-supply.azurewebsites.net/api/StoreFront/GetInventoryByStoreID?id=1
-Get Store Order History = https://furr-babbies-pet-supply.azurewebsites.net/api/StoreFront/StoreOrderHistoryFilter?p_storeID=2&p_filter=TotalPrice



License
This project uses the following license: <MIT>.
