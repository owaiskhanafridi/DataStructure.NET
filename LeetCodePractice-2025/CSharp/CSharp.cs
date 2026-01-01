using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.CSharp
{
    public class CSharp
    {

        //Static field initializations execute first, before the calling of static constructor.
        public static int constructorCheck = 0;

        //The instance constructor is called everytime the instance of the class is created
        public CSharp()
        {
            constructorCheck = 100;
        }

        // Static constructor is the first to be called after the creation of first instance of the class
        // Since static constructors run only once, they're good for expensive operations
        // Only static members can be called in static constructor because
        // the non static members are not initialized when the static constructor is executing
        static CSharp()
        {
            firstName = "";
        }

        //Access Modifiers
        public static string firstName = "John";
        private static string lastName = "Williams";
        protected string designation = "Software Engineer";
        internal int age = 25;

        //Const vs ReadOnly 
        const string compnay = "DGS";
        readonly string role = "Engineer";

        //Value Type
        byte valueByte = 123;              // Range: 0 to 255 (8-bit unsigned integer)
        short valueShort = 567;            // Range: -32,768 to 32,767 (16-bit signed integer)
        int valueInt = 56;                 // Range: -2,147,483,648 to 2,147,483,647 (32-bit signed integer)
        long valueLong = 100;              // Range: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 (64-bit signed integer)
        float valueFloat = 20;             // Range: ±1.5 × 10⁻⁴⁵ to ±3.4 × 10³⁸ (~6-9 significant digits precision)
        double valueDouble = 9.8;          // Range: ±5.0 × 10⁻³²⁴ to ±1.7 × 10³⁰⁸ (~15-17 significant digits precision)
        decimal valueDecimal = 450000;     // Range: ±1.0 × 10⁻²⁸ to ±7.9 × 10²⁸ (28-29 significant digits precision)

        char valueChar = 'a';              // Range: U+0000 to U+FFFF (Unicode character, 16-bit)
        bool valueBoolean = true;          // Range: true or false (1-bit, but uses 1 byte in memory)

        enum Days { Sun, Mon, Tues, Thurs, Fri, Sat }

        struct Point
        {
            public int X;
            public int Y;
        }

        //nullable value
        int? nullableInt = null;

        //Reference type
        int[] arr = new int[2];
        string valueString = "Test Value";

        //Delegates
        public delegate int MathOperation(int x, int y);
        public delegate void PrintMessage(string message);
        public delegate void LogMessage(string message);
        public delegate int Operation(int x, int y);

        public int AddNumbersFromDelegate(int a, int b)
            => a + b;
        public void PrintMethod(string message)
            => Console.WriteLine(message);

        public static void LogToConsole(string msg)
            => Console.WriteLine($"[Log to Console]: {msg}");
        public static void LogToFile(string msg)
            => Console.WriteLine($"[Log to log.txt file]: {msg}");
        public static void LogToDatabase(string msg)
            => Console.WriteLine($"[Save to Database]: {msg}");

        public int AddOperation(int a, int b)
            => a + b;
        public int MultiplyOperation(int a, int b)
            => a * b;
        public int SubtractOperation(int a, int b)
            => a - b;

        public int PerformOperation(int a, int b, Operation operation)
        => operation(a, b);
        
        //class myClass
        //{
        //    public int MyProperty { get; set; }
        //    public int MyProperty1 { get; set; }
        //}


        record User(string Name, decimal Salary, int Id = 1);
        public async Task Practice()
        {
            //Create var when the type is obvious from the right side.
            //Var can also be created for LINQ query results and in the foreach(var item in items)..
            //Var doesn't give any advantage for memory
            var list = new List<int>();

            Console.WriteLine($"Name: {firstName} {lastName}");

            //----- Delegates calling ------

            //Delegate assignment
            var addNumberDelegate = new MathOperation(AddNumbersFromDelegate);
            var printMessageDelegate = new PrintMessage(PrintMethod);

            //Calling delegate variable
            addNumberDelegate(1, 2);
            printMessageDelegate("Hello");

            //Call Perform Operation method with passing any method (satisfying delegate signature)
            int addResult = PerformOperation(10, 4, AddOperation);
            int multiplyResult = PerformOperation(10, 4, MultiplyOperation);
            int substractResult = PerformOperation(10, 4, SubtractOperation);


            LogMessage logger = LogToConsole;
            logger += LogToFile;
            logger += LogToDatabase;

            //Calls all three methods
            logger("hello world");

            //------ Class, Abstract Class and Interfaces -------
            RegularClass rc = new();
            rc.AddTwoNumbers(1, 6);
            rc.SayHello("William");

            Asian asian = new();
            asian.Talk();
            asian.Eat();

            var cow = new Cow();
            cow.Breathe();
            cow.Mooooan();

            //boxing ( value type --> object (implicit type casting) )
            int x = 10;
            object o = x;

            //unboxing ( object --> value type (explicit type casting) )
            int y = (int)o;

            // Check size of each variable
            EmployeeClass emp = new()
            {
                Id = 1,
                Name = "David",
                Age = 25,
                Salary = 150000
            };

            EmployeeStruct empStruct = new()
            {
                Id = 1,
                Name = "David",
                Age = 25,
                Salary = 150000
            };

            //int size = Marshal.SizeOf(typeof(empStruct));
            //Console.WriteLine($"class size: { Marshal.SizeOf(typeof(EmployeeClass)) }");


            // Using with to extend/update properties or a record
            var u1 = new User("Edward", 25000);
            var u2 = u1 with { Salary = 96000, Id = 3 };

            //spread operator (extends more numbers to existing array)
            int[] numbers = { 1, 2, 3, 4 };
            int[] updatedNumbers = [.. numbers, 5, 6];

            // ref needs to be assigned a value before passing it in the method
            int refValue = 0;
            RefExample(ref refValue);

            // out deosn't need to be assigned a value before passing it to the method
            int outValue;
            OutExample(out outValue);

            //Using Example
            // Automatically disposes the resource
            using (var stream = new FileStream("file.txt", FileMode.Open))
            {
                //Read from stream
                byte[] buffer = new byte[1024];

                await stream.ReadAsync(buffer, 0, buffer.Length);
            } // stream.Dispose() is automatically called here
        }

        public void RefExample(ref int a)
            => a = 10;
        public void OutExample(out int b)
            => b = 20;
    }

    public class EmployeeClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public decimal Salary { get; set; }
    }

    public struct EmployeeStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public decimal Salary { get; set; }

    }

    interface IExampleInterface
    {
        void PrintSomething(string message);
        void AddTwoNumbers(int num1, int num2);
        void SayHello(string name);
    }

    class RegularClass : IExampleInterface
    {
        public void AddTwoNumbers(int num1, int num2)
        {
            Console.WriteLine($"The sum is {(num1 + num2).ToString()}");
        }

        public void PrintSomething(string message)
        {
            Console.WriteLine("Something");
        }

        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }
    }

    class Human
    {
        public void Talk() => Console.WriteLine("Human can talk");
        public void Walk() => Console.WriteLine("Human can walk");
        public virtual void Eat() => Console.WriteLine("Human can Eat");

    }

    class Asian : Human
    {
        //To override, the parent class method should have virtual keyword in it. Otherwise it will throw error
        public override void Eat()
        {
            Console.WriteLine("Asian eats many variety of food");
        }
    }

    abstract class Animal
    {
        // Force subclasses to implement their own version
        public abstract void Eat();
        // Force subclasses to implement their own version
        public abstract void Walk();
        // Subclass only inherits non-abstract methods
        public void Breathe()
            => Console.WriteLine("All Animal Breathe");

    }


    class Cow : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Cow Eats grass");
        }

        public override void Walk()
        {
            Console.WriteLine("Cow walk slowly");
        }

        public void Mooooan()
            => Console.WriteLine("Cow Mooooooanss");
    }


}
