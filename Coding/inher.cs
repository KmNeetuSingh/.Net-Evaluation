using System;

namespace MLInheritance
{
    // Scenario 1: Banking System
    public class CBank
    {
        public virtual double Rate() => 0.01; // Central Bank Rate
    }

    public class NBank : CBank
    {
        public override double Rate() => 0.02; // National Bank Rate
    }

    public class LBank : NBank
    {
        public override double Rate() => 0.03; // Local Bank Rate
    }

    // Scenario 2: Vehicle System
    public class Vehicle
    {
        public virtual void Drive() => Console.WriteLine("Driving a generic vehicle.");
    }

    public class EVehicle : Vehicle
    {
        public override void Drive() => Console.WriteLine("Driving an electric vehicle.");
    }

    public class GVehicle : Vehicle
    {
        public override void Drive() => Console.WriteLine("Driving a gas-powered vehicle.");
    }

    public class SDCar : EVehicle
    {
        public override void Drive() => Console.WriteLine("Driving a self-driving car.");
    }

    public class HCar : GVehicle
    {
        public override void Drive() => Console.WriteLine("Driving a hybrid car.");
    }

    // Scenario 3: Employee System
    public class Emp
    {
        public virtual double Bonus(double sal) => sal * 0.1; // Employee Bonus
    }

    public class Mgr : Emp
    {
        public override double Bonus(double sal) => sal * 0.15; // Manager Bonus
    }

    public class Dir : Emp
    {
        public override double Bonus(double sal) => sal * 0.2; // Director Bonus
    }

    // Scenario 4: Messaging System
    public class Msg
    {
        public virtual void Send(string txt) => Console.WriteLine($"Sending: {txt}");
    }

    public class EMsg : Msg
    {
        public override void Send(string txt)
        {
            string encTxt = $"ENCRYPTED({txt})";
            Console.WriteLine($"Sending encrypted: {encTxt}");
        }
    }

    public class NMsg : Msg
    {
        public override void Send(string txt) => Console.WriteLine($"Sending plain: {txt}");
    }

    // Scenario 5: E-Commerce System
    public class Prod
    {
        public virtual double Discount(double price) => price * 0.05; // Default Discount
    }

    public class Elec : Prod
    {
        public override double Discount(double price) => price * 0.1; // Electronics Discount
    }

    public class Cloth : Prod
    {
        public override double Discount(double price) => price * 0.15; // Clothing Discount
    }

    public class Lap : Elec
    {
        public override double Discount(double price) => price * 0.12; // Laptop Discount
    }

    public class TShirt : Cloth
    {
        public override double Discount(double price) => price * 0.2; // T-Shirt Discount
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Scenario 1: Banking
            CBank cb = new CBank();
            NBank nb = new NBank();
            LBank lb = new LBank();
            Console.WriteLine($"CB Rate: {cb.Rate()}");
            Console.WriteLine($"NB Rate: {nb.Rate()}");
            Console.WriteLine($"LB Rate: {lb.Rate()}");

            // Scenario 2: Vehicles
            Vehicle v = new Vehicle();
            EVehicle ev = new EVehicle();
            GVehicle gv = new GVehicle();
            SDCar sdc = new SDCar();
            HCar hc = new HCar();
            v.Drive();
            ev.Drive();
            gv.Drive();
            sdc.Drive();
            hc.Drive();

            // Scenario 3: Employees
            Emp e = new Emp();
            Mgr m = new Mgr();
            Dir d = new Dir();
            Console.WriteLine($"Emp Bonus: {e.Bonus(50000)}");
            Console.WriteLine($"Mgr Bonus: {m.Bonus(50000)}");
            Console.WriteLine($"Dir Bonus: {d.Bonus(50000)}");

            // Scenario 4: Messaging
            Msg msg = new Msg();
            EMsg emsg = new EMsg();
            NMsg nmsg = new NMsg();
            msg.Send("Hello!");
            emsg.Send("Hello!");
            nmsg.Send("Hello!");

            // Scenario 5: E-Commerce
            Prod p = new Prod();
            Elec eProd = new Elec();
            Cloth cProd = new Cloth();
            Lap lProd = new Lap();
            TShirt tProd = new TShirt();
            Console.WriteLine($"Prod Discount: {p.Discount(100)}");
            Console.WriteLine($"Elec Discount: {eProd.Discount(100)}");
            Console.WriteLine($"Cloth Discount: {cProd.Discount(100)}");
            Console.WriteLine($"Lap Discount: {lProd.Discount(100)}");
            Console.WriteLine($"TShirt Discount: {tProd.Discount(100)}");
        }
    }
}