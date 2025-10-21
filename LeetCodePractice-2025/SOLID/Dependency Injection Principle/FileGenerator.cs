using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.SOLID.Dependency_Injection_Principle
{
    public class FileGenerator
    {
        private readonly ILogger _logger;

        //File Generator is not dependent on just FileLogger, it can accept any type of logger
        public FileGenerator(ILogger logger)
        { 
            _logger = logger;
        }

        public void GenerateFile()
        {
            Console.WriteLine("Generate File");
        }

        public void Initializer()
        {
            //Can also use any other type of logger i.e. Database Logger, API Logger
            ILogger logger = new FileLogger();

            //Or use database logger
            //ILogger logger = new DatabaseLogger();

            var filegenerator = new FileGenerator(logger);
            filegenerator.GenerateFile();
        }
    
    }

    //There can be many types of logger implementing ILogger Interface so the Main class (FileGenerator)
    //Doesn't depend on a single type of logger, but can flexibily accept any type of logger (File, DB, etc)
    public interface ILogger
    {
        public void LogInfo(string info);
    }

    public class FileLogger : ILogger
    {
        public void LogInfo(string info)
        {
            Console.WriteLine(info);
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void LogInfo(string info)
        { 
            Console.WriteLine("Initiate database connection");
            Console.WriteLine("Put log data into database");
        }
    }
}
