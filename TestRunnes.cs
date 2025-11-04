using System;
using HospitalManagementSystem.Tests;

namespace HospitalManagementSystem
{
    class TestRunner
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Hospital Management System - Test Runner");
            Console.WriteLine("=========================================");
            
            try
            {
                ModelTests.RunAllTests();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running tests: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
