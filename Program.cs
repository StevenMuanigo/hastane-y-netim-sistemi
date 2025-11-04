using System;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🏥 Hospital Management System");
            Console.WriteLine("============================");
            
            // Initialize the hospital management system
            var hospitalSystem = new HospitalManagementSystem();
            
            // Run the system
            hospitalSystem.Run();
            
            Console.WriteLine("System shutdown complete.");
        }
    }
}
