using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.CSharp
{
    public class CSharp
    {
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

        enum Days { Sun, Mon, Tues, Thurs, Fri, Sat}

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


        //class myClass
        //{
        //    public int MyProperty { get; set; }
        //    public int MyProperty1 { get; set; }
        //}

        public void Practice()
        {
            //Create var when the type is obvious from the right side.
            //Var can also be created for LINQ query results and in the foreach(var item in items)..
            //Var doesn't give any advantage for memory
            var list = new List<int>();

            Console.WriteLine($"Name: {firstName} {lastName}");

            //----- Delegates calling ------
            
            MathOperation addNumberDelegate = new MathOperation(AddNumbersFromDelegate);
            PrintMessage printMessageDelegate = new PrintMessage(PrintMethod);

            LogMessage logger = LogToConsole;
            logger += LogToFile;
            logger += LogToDatabase;

            //Calls all three methods
            logger("hello world");

        }
    }
}
