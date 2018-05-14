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

* A static function, unlike a regular (instance) function, is not associated with an instance of the class. ** *No instantiation of some object is required in order to use a static method.* **

* A static class is a class which can only contain static members, and therefore **cannot be instantiated.**



### Constructors

* Constructors are methods that have no return type and are called on object creation in order to initialize fields.

* **Create constructors when there is a need to initialize some object in an early state**. A typical use case is to avoid **null reference exceptions**, when calling reference types in the program.  For example, the best practice for the initialization of a *List* member of some class, is to have it implemented with a constructor in the class, instead of creating a new *List* object in the main program where a class instance is used.

** *As a best practice, anytime your class contains a list, always initialize the list.* **

* The **default** constructor is created by the C# compiler if not declared.

If not defined, the **default values** for various types are set by the compiler.

  * numbers: 0
  * bools: false
  * chars: ""
  * reference types: null


### Constructor Overloading

* Overload constructors by defining multiple signatures.

* If we provide any constructors with parameters, then the compiler **does not** create the default (parameter-less) constructor automatically.* **If we want to be able to create objects without setting values for parameters, we need to define manually the default parameter-less constructor.** *



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
