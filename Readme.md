/*
 
This is a checkout system developed by Ian Richards and was built using a variant of the harry potter kata

The solution is a simple based chackout system that allows a user to scan in an arbitary amount of items 
and get the running total. As each item is added the total is updated and discounts are checked and applied if
required. 

There is a simple discount service that allows for the discounts to be extended without having to refactor the basket service.

There werew a number of assumptions made prior to starting this project
    No subtotal was asked for and has not been provided
    No discount amount was requested and has not been provided
    Only a total price and total price inclusive of discount was requested which have been provided

This project makes use of NUnit and Moq for testing the units

If I were to refactor this code to deliver furture requirements I would extend the discount service to 
allow discounts to be added to the service via a function and not directly into the constructor 
I would also have them stored in some persistent storage and read from there maybe using mongodb or dynamodb

I would refactor the calculation functions into some other service that deals with these types of calculations and account for tax using some sort of tax service
I also feel that the function that handles the discounts might not be valid where it is but as this is my first checkout 
system and I'm not fully sure just yet where to take it I have left it in situ for now.

I also think the calculate function is a little over complex is it is working out the amount of discounts to apply per set as well as calculating the discounted cost

*/