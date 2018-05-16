## [C# Intermediate: Classes, Interfaces and OOP](https://www.udemy.com/csharp-intermediate-classes-interfaces-and-oop/)

by [Mosh Hamedani](https://programmingwithmosh.com/)





## 01 CLASSES


### Typical layered architecture for software applications

The architecture for a typical application consists at least of three layers.

* Presentation (View)

* Business Logic / Domain Layer (Model Classes)

* Data Access / Persistence (Repository)



### Classes

Custom type that contains two parts.

* Data (Fields)

* Behavior (Methods)

Classes are blueprints.

Fields and methods are the class **members**.


### Objects

**Instances** of classes, reside in the memory.


### Declarations

* Fields: Access modifiers - data type - identifier

* Methods: Access modifier - data return type - identifier(prameters) { code accessing class members }


### Types of class members

* **Instance members**: accessible from objects

* **Static members**: accessible from the class, represent singleton concepts


### Usage of static

* Static fields are singletons - allow **only one instance** of themselves to be created - and give simple, easy access to said instance.

* A static function, unlike a regular (instance) function, is not associated with an instance of the class. ***No instantiation of some object is required in order to use a static method.***

* A static class is a class which can only contain static members, and therefore **cannot be instantiated.**



### Constructors

* Constructors are methods that have no return type and are called on object creation in order to initialize fields.

* **Create constructors when there is a need to initialize some object in an early state**. A typical use case is to avoid **null reference exceptions**, when calling reference types in the program.  For example, the best practice for the initialization of a *List* member of some class, is to have it implemented with a constructor in the class, instead of creating a new *List* object in the main program where a class instance is used.

***As a best practice, anytime your class contains a list, always initialize the list.***

* The **default** constructor is created by the C# compiler if not declared.

If not defined, the **default values** for various types are set by the compiler.

  * numbers: 0
  * bools: false
  * chars: ""
  * reference types: null


### Constructor Overloading

* Overload constructors by defining multiple signatures.

* If we provide any constructors with parameters, then the compiler **does not** create the default (parameter-less) constructor automatically. ***If we want to be able to create objects without setting values for parameters, we need to define manually the default parameter-less constructor.***



### The *this* keyword

* The **this** keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.

* **Static member functions**, because they exist at the class level and not as part of an object, **do not have a *this* pointer.** It is an error to refer to *this* in a static method.

* We may use the *this* keyword in the declarations of multiple constructors to avoid code duplication. This practice may produce cluttered code if not used with caution.

```
public class Customer
{
  public int Id;
  public string Name;
  public List<Order> Orders;

  // Default or parameterless constructor
  public Customer()
  {
    // Orders has to be initialized here, otherwise it will be a null reference.
    // As a best practice, anytime your class contains a list, always initialize the list.
    Orders = new List<Order>();
  }


  // redundant constructors below, not really required, hard to maintain
  // added tot display the usage of : this()

  public Customer(int id)
  : this() // Calls the default constructor
  {
    this.Id = id;
  }

  public Customer(int id, string name)
  : this(id) // Calls the previous constructor
  {
    this.Name = name;
  }
}
```


### Object initializers

* We may use object initialization syntax when we initialize objects in order to avoid code with multiple constructors which is hard to maintain.

```
var person = new Person { FirstName = "Jason", LastName = "Donovan" };
```



### Method Overloading

* The signature of a method contains the number, type and order of its parameters.

* Overloading a method means having a method with the same name but with different signatures. This makes it easier for the callers of the method to choose the more
suitable signature depending on the type of data they have to pass to the method.

* The **params** modifier gives a method the ability to receive a varying number of parameters.

```
public class Calculator
{
  public int Add(params int[] numbers) {}
}
…
var result1 = calculator.Add(1, 2, 3, 4);
var result2 = calculator.Add(7, 8);
```

* The above functionality may also be achieved with this syntax:

```
var result1 = calculator.Add(new int[] {1, 2, 3, 4});
```
but the usage of the *params* modifier in the declaration makes it simpler.



### Fields

* Fields are class-level variables.

* A field can be initialized in two ways: In a constructor, or **directly upon declaration**. The benefit of initializing a field during declaration is that if your class has one or more constructors, you’ll make sure that the field will always be initialized irrespective of which constructor is going to be called.

```
public class Customer
{
  public List<Order> Orders = new List<Order>();
}
```

* We use the **readonly** modifier to improve the robustness of our code. When a field is declared with readonly, it needs to be initialized either during declaration or in a constructor. The value cannot be changed. This prevents you from accidentally overwriting the value of a field, which can result in an unexpected state.

In the above example, if we accidentally re-initialize this field somewhere else in the class, all the *Order* objects stored in the list will be lost. So we should declare it as readonly:

```
public class Customer
{
  public readonly List<Order> Orders = new List<Order>();
}
```


### Access Modifiers

**public, private, protected, internal, protected internal**

* A class member declared with **public** is accessible everywhere.
* A class member declared with **private** is accessible only from inside the class.


### Encapsulation

* Objects should hide their implementation detail (**how** they are set up in order to do stuff) and reveal their behavior and actions (**what** they can do) .

* Hide fields by defining them as private.

* Reveal the object's behavior by providing public getters and setters, where we can add logic for handling the field access.


### Properties

* A **property** is a kind of class member that is used for providing access to fields of a class.

* As a best practice, we must declare fields as private and create public properties to provide access to them.

* A property encapsulates a get and a set method:

```
public class Customer
{
  private string _name;

  public string Name
  {
    get { return _name; }
    set { _name = value; }
  }
}
```

* Inside the get/set methods we can have some logic.

* If you don’t need to write any specific logic in the get or set method, it’s more efficient to create an auto-implemented property. An auto-implemented property encapsulates a private field behind the scene. So you don’t need to manually create one. The compiler creates one for you:

```
public class Customer
{
  public string Name { get; set; }
}
```

### Indexers

* An **Indexer** is a special kind of property that allows accessing elements of a list by an index.

* If a class has the semantics of a list, or collection, we can define an indexer property for it. This way it’s easier to get or set items in the collection.

```
public class CustomCookie
{
  private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

  public string this[string key]
  {    
      get { return _dictionary[key]; }
      set { _dictionary[key] = value; }
  }
}
```
Set the value for the *name* key:
```
var myCookie = new CustomCookie();
myCookie["name"] = "John Smith";
```





## 02 ASSOCIATION BETWEEN CLASSES


### Class Coupling

* A measure of how interconnected classes and subsystems are.

* The more coupled the classes, the harder it is to change them. A change in one class may affect many other classes.

* Loosely coupled software, as opposed to tightly coupled software, is easier to change.

* Two types of relationships between classes: Inheritance and Composition.


### Inheritance

* A kind of relationship between two classes that allows one to inherit code from the other.

The **Child / Derived** class inherits / derives from the **Parent / Base / Super** class.

* Referred to as **Is-A** relationship: A Car is a Vehicle

* Benefits: code re-use and polymorphic behavior.

```
public class Car : Vehicle
{
}
```

### Composition

* A kind of relationship that allows one class to contain another.

* Referred to as **Has-A** relationship: A Car has an Engine

* Benefits: Code re-use, flexibility and a means to loose-coupling

The **related** class is simply a private field in the **composite** class.
In the constructor of the composite class we get as a parameter a related-class-type object which we then use to initialize the private field.

```
public class DbMigrator
{
  // We re-use the code in the logger class without
  // the need to repeat that logic here in DbMigrator
  private Logger _logger;

  public DbMigrator(Logger logger)
  {
    _logger = logger;
  }
}
```

### Favor Composition over Inheritance

* Problems with inheritance:

  • Easily abused by amateur designers / developers

  • Leads to large complex hierarchies

  • Such hierarchies are very fragile and a change may affect many classes

  • Results in tight coupling

* Benefits of composition:

  • Flexible

  • Leads to loose coupling

* Having said all that, it doesn’t mean inheritance should be avoided at all times. In fact, it’s great to use inheritance when dealing with very stable classes on top of small hierarchies. As the hierarchy grows (or variations of classes increase), the hierarchy, however, becomes fragile. And that’s where composition can give you a better design.




## 03 INHERITANCE


### Access Modifiers

* Your classes should be like a black box. They should have limited visibility from the outside. The implementation, the detail, should be hidden. We use access modifiers (mostly private) to achieve this. This is referred to as **Information Hiding** (and sometimes **Encapsulation**) in object-oriented programming.

  - **Public**: A member declared as public is accessible everywhere.
  - **Private**: A member declared as private is accessible only from the class.
  - **Protected**: A member declared as protected is accessibly only from the class and its derived classes. Protected breaks encapsulation (because the implementation details of a class will leak into its derived classes) and is better to be avoided.
  - **Internal**: A member declared as internal is accessibly only from the same assembly.
  - **Protected Internal**: A member declared as protected internal is accessible only from the same assembly or any derived classes. (Sounds weird? Forget it! It’s not really used.)


### Constructors and Inheritance

* Constructors are not inherited and need to explicitly defined in derived class.

* When creating an object of a type that is part of an inheritance hierarchy, base class constructors are always executed first.

* We can use the **base** keyword to pass control to a base class constructor.

```
public class Car : Vehicle
{
  public Car(string registration) : base(registration)
  {
    //initialize fields specific to the Car class
  }
}
```



### Upcasting and Downcasting

- **Upcasting**: conversion from a derived class to a base class

- **Downcasting**: conversion from a base class to a derived class

- All objects can be implicitly converted to a base class reference.

```
// Upcasting
Shape shape = circle;
```
Here the *circle* object is implicitly converted from the derived Circle class to the base Shape class. Casting is not required.
**All the properties of the created *shape* object already existed in the *circle* object.**


- Downcasting requires a cast, so that the derived class properties are available to the created object.

```
// Downcasting
Circle circle = (Circle)shape;
```
Here the *shape* object is converted from the base Shape class to the derived Circle class (**which may have extra properties**). Casting is required.


- Casting can throw an exception if the conversion is not successful. We can use the **as** keyword to prevent this. If conversion is not successful, null is returned.

```
Circle circle = shape as Circle;
if (circle != null) …
```

- We can also use the **is** keyword:

```
if (shape is Circle)
{
  var circle = (Circle) shape;
  …
}
```


### Boxing and Unboxing

- C# types are divided into two categories: value types and reference types.

- Value types (eg int, char, bool, all primitive types and struct) are stored in the stack.
They have a short life time and as soon as they go out of scope are removed from memory.

- Reference types (eg all classes) are stored in the heap.

- Every object can be implicitly cast to a base class reference.

- The object class is the parent of all classes in .NET Framework.

- So a value type instance (eg int) can be implicitly cast to an object reference.

- **Boxing** happens when a value type instance is converted to an object reference.

- **Unboxing** is the opposite: when an object reference is converted to a value type.

- Both boxing and unboxing come with a performance penalty. This is not noticeable when dealing with small number of objects. But if you’re dealing with several
thousands or tens of thousands of objects, it’s better to avoid it.

```
// Boxing
object obj = 1;
// Unboxing
int i = (int)obj;
```




## 04 POLYMORPHISM


### Method Overriding

- Method overriding means changing the implementation of an inherited method.

- If we declare a method as **virtual** in the base class, we can **override** it in a derived class.

```
public class Shape
{
  public virtual Draw()
  {
    // Default implementation for all derived classes
  }
}

public class Circle : Shape
{
  public override Draw()
  {
    // Changed implementation
  }
}
```

- This technique allows us to achieve polymorphism. Polymorphism is a great object-oriented technique that allows us to get rid of long procedural switch statements (or conditionals).

&nbsp;
### ■ Note: We can override either *virtual* or *abstract* methods.
&nbsp;



### Abstract Classes and Members

- **Abstract** modifier states that a class or a member misses implementation. We use abstract members when it doesn’t make sense to implement them in a base class. For example, the concept of drawing a shape is too abstract. We don’t know how to draw a shape. This needs to be implemented in the derived classes.

- When a class member is declared as abstract, that class needs to be declared as abstract as well. That means that class is not complete.

- In derived classes, we need to **override** the abstract members in the base class.

```
public abstract class Shape
{
  // This method doesn’t have a body.
  public abstract Draw();
}

public class Circle : Shape
{
  public override Draw()
  {
    // Changed implementation
  }
}
```

- In a derived class, we need to override all abstract members of the base class, otherwise that derived class is going to be abstract too.

- Abstract classes cannot be instantiated.



### Sealed Classes and Members

- If applied to a class, prevents derivation from that class.

- If applied to a method, prevents overriding of that method in a derived class.

- The string class is declared as sealed, and that’s why we cannot inherit from it.

```
public sealed class String
{
}
```



## 05 INTERFACES


### Introduction

- An interface is a language construct that is similar to a class (in terms of syntax) but is fundamentally different.

- An interface is simply a declaration of the capabilities (or services) that a class should provide.

```
public interface ITaxCalculator
{
  int Calculate();
}
```

- This interface states a class that wants to play the role of a tax calculator, should provide a method called Calculate() that takes no parameters and returns an int. The implementation of this class might look like this:

```
public class TaxCalculator : ITaxCalculator
{
  public void Calculate() { … }
}
```

- So, an interface is purely a declaration. Members of an interface do not have implementation.

- An interface can only declare methods and properties, but not fields (because fields are about implementation detail).

- Members of an interface do not have access modifiers.

- Interfaces help building loosely coupled applications. We reduce the coupling between two classes by putting an interface between them. This way, if one of these classes changes, it will have no impact on the class that is dependent on that (as long as the interface is kept the same).


### Interfaces and Testability

- Unit testing is part of the automated practice which helps improve the quality of our code. With automated testing, we write code to test our own code. This helps catching bugs early on as we change the code.

- In order to unit test a class, we need to isolate it. This means: we need to assume that every other class in our application is working properly and see if the class under test is working as expected.

- A class that has tight dependencies to other classes cannot be isolated.

- To solve this problem, we use an interface. Here is an example:

```
public class OrderProcessor
{
  private IShippingCalculator _calculator;
  public Customer(IShippingCalculator calculator)
  {
    _calculator = calculator;
  }
  …
}
```

OrderProcessor is not dependent on the ShippingCalculator class. It’s only dependent on an interface (IShippingCalculator). If we change the code inside the ShippingCalculator (eg add a new method or change the method implementations) it will have no impact on OrderProcessor (as long as the interface is kept the same).


### Interfaces and Extensibility

- We can use interfaces to change our application’s behaviour by “extending” its code (rather than changing the existing code).

- If a class is dependent on an interface, we can supply a different implementation of that interface at runtime. This way, the behavior of the application changes without any impact on that class.

- For example, let’s assume our DbMigrator class is dependent on an ILogger interface. At runtime, we can supply a ConsoleLogger to log the messages on the console. Later, we may decide to log the messages in a file (or a database). We can simply create a new class that implements the ILogger interface and inject it into DbMigrator.


### Interfaces and Inheritance

- One of the common misconceptions about interfaces is that they are used to implement multiple inheritance in C#. This is fundamentally wrong, yet many books
and videos make such a false claim.

- With inheritance, we write code once and re-use it without the need to type all that code again.

- With interfaces, we simply declare the members the implementing class should contain. Then we need to type all that declaration along with the actual implementation in that class. So, code is not inherited, and even the declaration of the members has to be repeated in the implementation of the interface in the class!

* Code reusability is not related to the concept of interfaces. Interfaces are instead contracts that classes conform to.

* The misconception is due to the similar syntax with the colon usage in the class declaration, either for inheritance from a base class `: SomeBaseClass`, or for implementing an interface ` : ISomeInterface`. But **it is fundamentally wrong** to say that a class **inherits from** an interface. A class **implements** one or more interfaces.


### Interfaces and open/closed principle

* In object-oriented programming, the **open/closed principle (OCP)** states that *"software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification"* that is, such an entity can allow its behavior to be extended without modifying its source code.

* The use of interfaces in a program promotes the implementation of the open/closed principle.


### Interfaces and Polymorphism

* Interfaces can be used in order to provide polymorphic behavior to a program.

* Different classes may implement the same interface method. Then different versions of this method can be called at runtime. These versions match the various method implementations described in the class bodies of the different objects that call the method.  
