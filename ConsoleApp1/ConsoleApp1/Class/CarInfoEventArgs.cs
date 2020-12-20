using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
    /*
        *The delegate EventHandler<TEventArgs> is defined as follows:       
           public delegate void EventHandler<TEventArgs>(object sender,
           TEventArgs e)
           where TEventArgs : EventArgs
     */
    public class CarInfoEventArgs:EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }
        public string Car { get;}
    }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;
        public  void NewCar(string car)
        {
            Console.WriteLine($"CarDeal, new car {car}");
            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
            
        }
    }


}
