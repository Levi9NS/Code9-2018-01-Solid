# Dependency inversion principle

![](https://image.ibb.co/eT6ZW7/dependency_inversion_principle.jpg)

> High-level classes (modules) should not depend on low-level classes (modules).
> Both should depend on abstractions. Abstractions should not 
> depend on details. Details should depend on abstractions.

Low level classes are those which implement basic and primary operations (send email, send request for CC payment, ...)

High level classes are those which encapsulate complex logic and rely on the low level classes (process order, cancel order, ...)