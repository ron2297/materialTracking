# Material Tracking Software

______

## Software Engineering - CS 349
### Ron Washington III, Edwin St. Hilaire, Jesse Nhan, Lan Le, Bryan Tran
> Over the course of Fall Semester 2017, we developed an web application that would be beneficial to a company. The purpose of this project is to develop a software package that will use information from the company’s database that will then organize and state needed equipment, distribution, etc. 
______

The software consists of four distinct modules:

### Request Module 
> For choosing materials to purchase, searching for vendors, and placing orders.
* There will be the request form that the users interact with. In the form, the user can either fill in new items or items have been requested before. Then the user has to specify the quantity of each product they want to purchase and the price per capita. 

### Purchasing Module 
> For vendor to accept requests and placing orders for the materials. ( capability to purchase)
* Explain appearance / usage:  In the landing page, there will be a table showing all request regardless of status and filter for those having “Request Pending” status. If the product is “ Request Pending”, the user can select it for processing. 
* There is a distinct page to streamline the purchasing process. The user will be able to select/ edit the quantity of the product  with price per capita and the vendor. Once the purchasing process is submitted. The status of the product will be changed to “ Awaiting PO” . If a product is having an “Awaiting PO” status, the user will be able to:
  *See a distinct list of vendors for the selected Request.
  * Apply a PO number for each Vendor (PO numbers come from another system, so there is nothing to confirm, just accept the number).
  * Once all PO numbers are entered, the user will save the request and the status will go into “Pending Delivery”.  
  * Saving a PO will also generate an Order ID number that encompasses all orders.  The status of the Order and each PO in the order will be “Open”

### Receiving Module 
> For customers to receive the order.
* When the product is received, the user will be able to search the item based on its order number and change its status to “ Received” and assign the “Unloading Zone”. The user will also be able to enter and maintain the list of Loading Zones. Unloading Zones and Storage areas.
* When the product is moved into the Storage area, its status will be changed to “In inventory”
 
### Shipping Module 
* If the product has the “In inventory” status, the user navigate it to the shipping process. There is a distinct page to streamline the shipping process. In the process the user will be able to select, items or assemblies for shipment,  the destination and Loading Zone. After the form is submitted, the status will be changed to “Pending Shipment”. When the items are picked up for Shipment, then the status will change to “Shipped”.
* The user will be able to maintain a list of Destination location and Shipping Company 
