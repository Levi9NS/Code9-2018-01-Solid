# Single responsibility principle

![swiss knife](https://images-na.ssl-images-amazon.com/images/I/71FHJU17djL._SL1204_.jpg)

> One class should do only one thing and do it well
> One class should have only one responsibility

How to recognize SRP problems: 
 - Methods are too long
 - Classes are god classes (classes that do everything)

OrderProcessor.ProcessOrder is failing SRP because it has multiple responsibilities:
 - Calculates price
 - Calculates discount
 - Charges credit card (and does charge cancellation)
 - Saves order to DB
 - Sends email

Pitfalls and :
 - Over(ab)using SRP can lead to code fragmentation (you can recognize this
   problem when one class a lot of dependencies)
 - Large number of small classes are often harder to understand, compared
   to single "god" class