using System;
 

  /// <summary>
  /// MainApp startup class for Structural
  /// Singleton Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Constructor is protected -- cannot use new
      Singleton s1 = Singleton.Instance();
      Singleton s2 = Singleton.Instance();
 
      // Test for same instance
      if (s1 == s2)
      {
        Console.WriteLine("Objects are the same instance");
      }
 
      // Wait for user
      Console.Read();
    }
  }
 
  /// <summary>
  /// The 'Singleton' class
  /// </summary>
  class Singleton
  {
    private static Singleton _instance;
 
    // Constructor is 'protected'
    protected Singleton()
    {
    }
 
    public static Singleton Instance()
    {
      // Uses lazy initialization.
      // Note: this is not thread safe.
      if (_instance == null)
      {
        _instance = new Singleton();
      }
 
      return _instance;
    }
  }
/* Difference between static class and singleton pattern?
A singleton allows access to a single created instance - that instance (or rather, a reference to that instance) can be passed as a parameter to other methods, and treated as a normal object.
A static class allows only static methods.

1. Singleton objects are stored in Heap, but static objects are stored in stack.
2. We can clone (if the designer did not disallow it) the singleton object, but we can not clone the static class object .
3. Singleton classes follow the OOP (object oriented principles), static classes do not.
4. We can implement an interface with a Singleton class, but a class's static methods (or e.g. a C# static class) cannot.

The Singleton pattern has several advantages over static classes. 
1. A singleton can extend classes and implement interfaces, while a static class cannot (it can extend classes, but it does not inherit their instance members). 
2. A singleton can be initialized lazily or asynchronously while a static class is generally initialized 
   when it is first loaded, leading to potential class loader issues. 
   
A static class is one that has only static methods, for which a better word would be "functions". 
The design style embodied in a static class is purely procedural.

Singleton, on the other hand, is a pattern specific to OO design.
It is an instance of an object (with all the possibilities inherent in that, such as polymorphism), 
with a creation procedure which ensures that there is only one instance ever of that particular role over its entire lifetime.   
  However the most important advantage, 
is that singletons can be handled polymorphically without forcing their users to assume that there is only one instance.

static classes should not do anything need state, it is useful for putting bunch of functions together i.e Math (or Utils in projects). 
So the class name just give us a clue where we can find the functions and there's nothing more.

Singleton pattern use it to manage something at a single point. It's more flexible than static classes and can maintain state.
It can implement interfaces, inherit from other classes and allow inheritance.

If there are bunch of functions should be kept together, then static is the choice. 
Anything else which needs single access to some resources, could be implemented singleton.
*/
