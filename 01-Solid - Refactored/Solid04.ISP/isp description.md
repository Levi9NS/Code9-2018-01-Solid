# Interface segragation principle

![](https://image.ibb.co/grN29H/oop_principles_14_638.jpg)
(source: https://toidicodedao.com/2016/06/09/series-solid-cho-thanh-nien-code-cung-interface-segregation-principle/)

> Clients should not be forced to depend on methods they don't use.
> Instead of one fat interface many small interfaces are preferred
> based on groups of methods, each one serving one sub module

ISP principle can be closely related to LSP, interfaces should be small,
which means classes that implement interfaces will not have to
throw unsupported/not-implemented exceptions.