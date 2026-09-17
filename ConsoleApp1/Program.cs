    using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
   

    internal class Program
    {
        public abstract class SmartDevice
        {
            public abstract string Name { get; set; }
            public abstract bool IsOn { get; set; }
            public void TurnOn()
            {
                IsOn = true;
                Console.WriteLine($"{Name} он крч ON.");
            }

            public void TurnOff()
            {
                IsOn = false;
                Console.WriteLine($"{Name} он крч OFF.");
            }
            public abstract void GetStatus();
            
            
        }

        public class SmartLamp : SmartDevice
        {
            public override string Name { get; set; }
            public override bool IsOn { get ; set ; }
            public override void GetStatus()
            {
                Console.WriteLine($"{Name}: " +
         (IsOn ? "Включена" : "Выключена"));
            }

            
        }

    interface IBatteryPowered
        {
            int BatteryCharge { get; set; }
            void Charge();


        }

        public class RobotVacuum : SmartDevice, IBatteryPowered
        {
            public override string Name { get; set; }
            public override bool IsOn { get; set; }
            public int BatteryCharge { get; set; }
            public override void GetStatus()
            {
                Console.WriteLine($"{Name}: " +
        (IsOn ? "Включен" : "Выключен") +
        $", заряд: {BatteryCharge}%");
            }

            public void Charge()
            {
                BatteryCharge = 100;
                Console.WriteLine("Пылесос заряжается");
            }

        }

        public class SmartLock : SmartDevice, IBatteryPowered
        {
            public override string Name { get; set; }
            public override bool IsOn { get; set; }
            public int BatteryCharge { get; set; }
            public override void GetStatus()
            {
                Console.WriteLine($"{Name}: " +
        (IsOn ? "Включен" : "Выключен") +
        $", заряд: {BatteryCharge}%");
            }

            public void Charge()
            {
                BatteryCharge = 100;
                Console.WriteLine("Замок заряжается");
            }

        }





        static void Main(string[] args)
        {
            SmartLamp lamp = new SmartLamp();

            RobotVacuum vacuum = new RobotVacuum();

            SmartLock lockDevice = new SmartLock();


            
            lamp.Name = "Лампа";
            lamp.IsOn = false;

            vacuum.Name = "Пылесос";
            vacuum.IsOn = false;
            vacuum.BatteryCharge = 50;

            lockDevice.Name = "Замок";
            lockDevice.IsOn = false;
            lockDevice.BatteryCharge = 20;

            List<SmartDevice> smart = new List<SmartDevice>();

            smart.Add(lamp);
            smart.Add(vacuum);
            smart.Add(lockDevice);

            List<IBatteryPowered> batteries =
                new List<IBatteryPowered>();

            batteries.Add(vacuum);
            batteries.Add(lockDevice);

            
            foreach (SmartDevice device in smart)
            {
                device.GetStatus();
            }
            lamp.TurnOn();
            lockDevice.TurnOn();
            foreach (IBatteryPowered battery in batteries)
            {
                battery.Charge();
            }
            foreach (SmartDevice device in smart)
            {
                device.GetStatus();
            }
        }
    }
    
}
