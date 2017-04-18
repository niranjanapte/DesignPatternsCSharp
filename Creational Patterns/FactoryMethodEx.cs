using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FactoryMethodPattern
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
        public int GetTotalAmount()
        {
            return (int)(Amount + (Amount * 0.12));     
        }
    }
    public class Grade2Customer : IBaseCustomer
    {
        public string CustomerName{get;set;}
        public int Amount{get;set;}
        public int GetTotalAmount()
        {
            return (int)(Amount + (Amount * 0.30));     
        }
    }
    
   //Create a Base Factory for creating contracts for other factories:
 
    public interface ICustomerBaseFactory
    {
        IBaseCustomer GetCustomer(int CustomerType);
    }
    
    
    public class CustomerFactory : ICustomerBaseFactory
    {
          public IBaseCustomer GetCustomer(int  CustomerType)
          {
                   switch(CustomerType)
                   {
                             case 1:
                                      return  new Grade1Customer();
                             case 2:
                                      return new Grade2Customer();
                             default:
                                      return null;
                   }
          }
    }

    
    
    public class Program
    {
        public static void Main(string[] args)
        {
           ICustomerBaseFactory objFactory = new CustomerFactory();
          IBaseCustomer objCustomer = objFactory.GetCustomer(1);
 
            
          objCustomer.CustomerName = "Amit";
            
          objCustomer.Amount = 30000;
 
          Console.WriteLine("Welcome " + objCustomer.CustomerName+ ", Your total unpaid amount is " +   
                         objCustomer.GetTotalAmount().ToString());
        }
    }
}
