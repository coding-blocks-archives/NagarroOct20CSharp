using System;

namespace Polymorphism
{

    class PolymorphismDemo
    {

        static void main(string[] args)
        {
            Console.WriteLine(Addition(2, 3));
            Console.WriteLine(Addition(2, 3, 4));

            Vehicle v = new Car();
            Console.WriteLine(v.Wheels());
            v.Breaks();
        }

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static int Addition(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    abstract class Vehicle
    {
        public abstract int Wheels();

        public virtual void Breaks()
        {
            Console.WriteLine("Breaks");
        }

       
    }

    class Car : Vehicle
    {
        public override int Wheels()
        {
            return 4;
        }

        public override void Breaks()
        {
            Console.WriteLine("Automatic Breaks");
        }

    }

}