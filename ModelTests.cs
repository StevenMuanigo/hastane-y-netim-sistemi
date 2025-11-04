using System;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Tests
{
    public class ModelTests
    {
        public static void RunAllTests()
        {
            Console.WriteLine("Running Model Tests...");
            Console.WriteLine("=====================");
            
            TestPatientModel();
            TestDoctorModel();
            TestAppointmentModel();
            TestPrescriptionModel();
            TestMedicineModel();
            TestStaffModel();
            TestInvoiceModel();
            
            Console.WriteLine("\nAll tests completed!");
        }
        
        private static void TestPatientModel()
        {
            Console.WriteLine("\n1. Testing Patient Model...");
            
            var patient = new Patient("John", "Doe", "12345678901", new DateTime(1990, 5, 15), 
                                    "5551234567", "john.doe@email.com", "123 Main St");
            
            Console.WriteLine($"Patient: {patient.GetFullName()}");
            Console.WriteLine($"Age: {patient.GetAge()}");
            Console.WriteLine($"TC: {patient.TCNumber}");
            
            // Test default constructor
            var patient2 = new Patient();
            patient2.FirstName = "Jane";
            patient2.LastName = "Smith";
            patient2.DateOfBirth = new DateTime(1985, 10, 20);
            
            Console.WriteLine($"Patient2: {patient2.GetFullName()}, Age: {patient2.GetAge()}");
        }
        
        private static void TestDoctorModel()
        {
            Console.WriteLine("\n2. Testing Doctor Model...");
            
            var doctor = new Doctor("Dr. Smith", "Johnson", "Cardiology", "12345678902", 
                                  "5551234568", "smith.johnson@hospital.com", 200.0m);
            
            Console.WriteLine($"Doctor: {doctor.GetFullName()}");
            Console.WriteLine($"Specialty: {doctor.Specialty}");
            Console.WriteLine($"Fee: ${doctor.ConsultationFee}");
        }
        
        private static void TestAppointmentModel()
        {
            Console.WriteLine("\n3. Testing Appointment Model...");
            
            var appointment = new Appointment(1, 1, DateTime.Now.AddDays(1), 
                                           new TimeSpan(14, 30, 0), "Regular checkup");
            
            Console.WriteLine($"Appointment: {appointment.GetFormattedDateTime()}");
            Console.WriteLine($"Status: {appointment.Status}");
            
            // Test cancellation
            appointment.Cancel();
            Console.WriteLine($"After cancellation: {appointment.Status}");
        }
        
        private static void TestPrescriptionModel()
        {
            Console.WriteLine("\n4. Testing Prescription Model...");
            
            var prescription = new Prescription(1, 1, "Common cold", "Rest and fluids");
            
            // Add prescription items
            var item1 = new PrescriptionItem(1, 1, "Paracetamol", "500mg", "Twice daily", 10, 5.50m, "After meals");
            var item2 = new PrescriptionItem(1, 2, "Vitamin C", "1000mg", "Once daily", 5, 8.25m, "Morning");
            
            prescription.PrescriptionItems.Add(item1);
            prescription.PrescriptionItems.Add(item2);
            
            Console.WriteLine($"Prescription total: ${prescription.GetTotalCost():F2}");
        }
        
        private static void TestMedicineModel()
        {
            Console.WriteLine("\n5. Testing Medicine Model...");
            
            var medicine = new Medicine("Aspirin", "Pain reliever", "PharmaCorp", 
                                     7.50m, 50, DateTime.Now.AddYears(2), true);
            
            Console.WriteLine($"Medicine: {medicine.Name}");
            Console.WriteLine($"Price: ${medicine.UnitPrice}");
            Console.WriteLine($"Stock: {medicine.StockQuantity}");
            Console.WriteLine($"In stock: {medicine.IsInStock(10)}");
            
            // Test stock reduction
            medicine.ReduceStock(5);
            Console.WriteLine($"Stock after reduction: {medicine.StockQuantity}");
            
            // Test stock increase
            medicine.IncreaseStock(10);
            Console.WriteLine($"Stock after increase: {medicine.StockQuantity}");
        }
        
        private static void TestStaffModel()
        {
            Console.WriteLine("\n6. Testing Staff Model...");
            
            var staff = new Staff("Alice", "Brown", "12345678903", "Nurse", 
                                "5551234569", "alice.brown@hospital.com", 4500.0m);
            
            Console.WriteLine($"Staff: {staff.GetFullName()}");
            Console.WriteLine($"Role: {staff.Role}");
            Console.WriteLine($"Is Nurse: {staff.IsNurse()}");
            Console.WriteLine($"Is Doctor: {staff.IsDoctor()}");
        }
        
        private static void TestInvoiceModel()
        {
            Console.WriteLine("\n7. Testing Invoice Model...");
            
            var invoice = new Invoice(1, 500.00m, "State Insurance", 300.00m);
            
            Console.WriteLine($"Service Amount: ${invoice.ServiceAmount:F2}");
            Console.WriteLine($"Total Amount: ${invoice.TotalAmount:F2}");
            Console.WriteLine($"Remaining Amount: ${invoice.RemainingAmount:F2}");
            Console.WriteLine($"Payment Status: {invoice.PaymentStatus}");
            
            // Test payment
            invoice.AddPayment(100.00m);
            Console.WriteLine($"After payment - Paid: ${invoice.PaidAmount:F2}, Remaining: ${invoice.RemainingAmount:F2}");
            Console.WriteLine($"Payment Status: {invoice.PaymentStatus}");
        }
    }
}
