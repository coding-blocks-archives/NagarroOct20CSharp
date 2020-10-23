using System;

namespace OOPS
{
    class OOPSDemo
    {
        static void main(string[] args)
        {
            Student s = new Student();
            Console.WriteLine(s.age);

            Student s1 = new Student();
            s1.name = "A";
            s1.age = 10;

            Student s2 = new Student();
            s2.name = "B";
            s2.age = 20;

            // Test2(s1, s2);

            Console.WriteLine(s1.name + " " + s1.age);
            Console.WriteLine(s2.name + " " + s2.age);

            string myname = "C";
            int myage = 30;

            //Test3(s1, s2.name, s2.age, myname, myage);

            Console.WriteLine(s1.name + " " + s1.age);
            Console.WriteLine(s2.name + " " + s2.age);
            Console.WriteLine(myname + " " + myage);

            s1.IntroduceYourself();
            s2.IntroduceYourself();

            s1.SayHi("Aman");

        
            Parent obj = new Parent();
            obj.Fun();

            // operator overloading
            Student o =  s1 + s2;
            o.IntroduceYourself();

        }

        static void Test3(Student s, string name, int age , string myname, int myage)
        {
            s.name = "_";
            s.age = 0;
            name = "_";
            age = 0;
            myname = "_";
            myage = 0;
         }

        static void Test2(Student s3, Student s4)
        {
            s3 = new Student();
            string tempn = s3.name;
            s3.name = s4.name;
            s4.name = tempn;

            s4 = new Student();
            int tempa = s3.age;
            s3.age = s4.age;
            s4.age = tempa;
        }

        static void Test1(Student s3, Student s4)
        {
            Student temp = s3;
            s3 = s4;
            s4 = temp; 
        }


    }

    class Student
    {
        public string name;
        public int age;

        public void IntroduceYourself()
        {
            Console.WriteLine(name + " is " + age + " years old.");
        }

        public void SayHi(string name)
        {
            Console.WriteLine(this.name + " says hi to " + name);
        }

        public static Student operator + (Student s1, Student s2)
        {
            Student s = new Student();
            s.name = s1.name + s2.name;
            s.age = s1.age + s2.age;

            return s;
        }

    }

    class Parent
    {
        public void Fun()
        {
            Console.WriteLine("In parent fun");
        }

    }

    class Child : Parent
    {
        public void Fun1()
        {
            Console.WriteLine("In child fun 1");
        }
    }
}