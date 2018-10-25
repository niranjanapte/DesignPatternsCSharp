
//Factory Method - Define an interface for creating an object,
//but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.
using System;  
  
namespace FactoryDesignPattern  
{  
    public interface ISupplier  
    {  
        string CarColor  
        {  
            get;  
        }  
        void GetCarModel();  
    }  
    class Ford : ISupplier  
    {  
        public string CarColor  
        {  
            get { return "White"; }  
        }  
  
        public void GetCarModel()  
        {  
            Console.WriteLine("Ford Car Model is Ford 2018 ZDI");  
        }  
    }  
    class Mercedes : ISupplier  
    {  
        public string CarColor  
        {  
            get { return "Gray"; }  
        }  
        public void GetCarModel()  
        {  
            Console.WriteLine("Mercedes Car Model is Mercedes E-Class 2018");  
        }  
    }  
  
    class Kia : ISupplier  
    {  
        public string CarColor  
        {  
            get { return "Black"; }  
        }  
        public void GetCarModel()  
        {  
            Console.WriteLine("Kia Car Model is Kia SUV 2017");  
        }  
    }  
    class Suzuki : ICarSupplier  
    {  
        public string CarColor  
        {  
            get { return "Silver"; }  
        }  
        public void GetCarModel()  
        {  
            Console.WriteLine("Suzuki Car Model is Suzuki Nexa Baleno 2018");  
        }  
    }  
  
    static class CarFactory  
    {  
        public static ISupplier GetCarInstance(int Id)  
        {  
            switch (Id)  
            {  
                case 0:  
                    return new Ford();  
                case 1:  
                    return new Mercedes();  
                case 2:  
                    return new Kia();  
                case 3:  
                    return new Suzuki();  
                default:  
                    return null;  
            }  
        }  
    }  
    class ClientProgram  
    {  
        static void Main(string[] args)  
        {  
              
            ICarSupplier objCarSupplier = CarFactory.GetCarInstance(3);  
            objCarSupplier.GetCarModel();  
            Console.WriteLine("And Coloar is " + objCarSupplier.CarColor);  
  
            Console.ReadLine();  
        }  
  
    }  
}  
