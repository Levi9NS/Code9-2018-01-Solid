# Liskov Substitution Principle 

![](https://image.ibb.co/g6Ax9H/what_if_i_told_you_that_a_square_is_not_a_rectangle.jpg)

> LSB  says that given a specific base class, any class that inherits 
> from it, can be a substitute for the base class.

> Functions that use references to base classes must be able to use 
> objects of derived classes without knowing it.


- Child classes should not throw exceptions that are not expected to
be thrown from parent class
- Child classes should not add new validations for parameters 
- Child classes should implement all methods and properties of the
parent class/interface
- Child classes should not change basic behavior of parent class
