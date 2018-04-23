# Open closed principle

![](https://image.ibb.co/nrKCrx/image_axd_picture_Open_Closed_Principle_thumb.jpg)

> Software entities (clases, modules, ...) should be open for extension,
  but not for modification

- New features should not require modification to existing
  code
- New behavior can be added in the future

Code that follows OCP is the way to go when implementing
pluggable architecture (for example in Visual Studio which 
has a marketplace full of extensions and plugins, or Google Chrome,
Firefox, etc...)