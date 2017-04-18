using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AbstractFactoryPattern
{
    //Create a base for concrete products
    public interface IBaseCustomer 
    { 
          int Amount {get; set; } 
          string CustomerName {get; set; } 
          int GetTotalAmount(); 
    } 
    //Derive concrete classes from the above interface
    public class Grade1Customer : IBaseCustomer
    {
        public string CustomerName{get;set;}
        public int Amount{get;set;}
        public int DiscountAmount{get;set;}
        public int GetTotalAmount()
        {
            return (int)(Amount + (Amount * 0.12)-DiscountAmount);     
        }
    }
    public class Grade2Customer : IBaseCustomer
    {
        public string CustomerName{get;set;}
        public int Amount{get;set;}
        public int DiscountAmount{get;set;}
        public int GetTotalAmount()
        {
            return (int)(Amount + (Amount * 0.30)-DiscountAmount);     
        }
    }
    
    public  class CustomerFactory{
        
    public static  CustomerFactory GetCustomerFactory(string Country)
    {       
          switch(Country)
          {
                   case "Country1":
                   {
                             return new Country1Factory();
                   }
                   case "Country2":
                   {
                             return new Country2Factory();
                   }
                   default:
                   {
                             return new CustomerFactory();//Returning itself for Default
                   }
          }                          
    }
        
        public virtual IBaseCustomer GetCustomer(string CustomerType)
        {
          switch(CustomerType)
          {
                   case "1":
                             Grade1Customer c1 = new Grade1Customer();
                             c1.DiscountAmount = 0;
                             return c1;
                   case "2":
                             Grade2Customer c2 = new Grade2Customer();
                             c2.DiscountAmount = 0;
                             return c2;
                   default:
                             return null;
          }
        }
        
        
}
    public class Country1Factory : CustomerFactory
    {
        public override IBaseCustomer GetCustomer(string CustomerType)
        {
          switch(CustomerType)
          {
                   case "1":
                             Grade1Customer c1 = new Grade1Customer();
                             c1.DiscountAmount = 200;
                             return c1;
                   case "2":
                             Grade2Customer c2 = new Grade2Customer();
                             c2.DiscountAmount = 0;
                             return c2;
                   default:
                             return null;
          }
        }
    }
    
    public class Country2Factory : CustomerFactory
    {
        public override IBaseCustomer GetCustomer(string CustomerType)
        {
          switch(CustomerType)
          {
                   case "1":
                             Grade1Customer c1 = new Grade1Customer();
                             c1.DiscountAmount = 0;
                             return c1;
                   case "2":
                             Grade2Customer c2 = new Grade2Customer();
                             c2.DiscountAmount = 100;
                             return c2;
                   default:
                             return null;
          }
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
           CustomerFactory objFactory = CustomerFactory.GetCustomerFactory("Country1");
            IBaseCustomer objCustomer = objFactory.GetCustomer("1");
             objCustomer.CustomerName = "Amit";   
             objCustomer.Amount = 30000;
             Console.WriteLine("Welcome " + objCustomer.CustomerName + ", Your total unpaid amount is " + objCustomer.GetTotalAmount().ToString());
        }
    }
    
    /* Definition
       An Abstract Factory is the extension of the Factory method pattern and provides an abstraction one level higher than the factory method pattern.
       In short the Abstract Factory creates an object of some other factories which at the end creates an object of concrete classes.
       Or we can say the Abstract Factory encapsulates individual factories having a single theme.
       Like a Factory method it falls under the creational pattern.
       According to the Gang of Four: It provides an Interface for creating families of related or dependent objects 
       without specifying their concrete classes.
    
    */
}
