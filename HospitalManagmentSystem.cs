using System;
using System.Collections.Generic;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem
{
    public class HospitalManagementSystem
    {
        // Data storage
        private List<Patient> patients;
        private List<Doctor> doctors;
        private List<Appointment> appointments;
        private List<Prescription> prescriptions;
        private List<Medicine> medicines;
        private List<Staff> staffMembers;
        private List<Invoice> invoices;
        
        public HospitalManagementSystem()
        {
            patients = new List<Patient>();
            doctors = new List<Doctor>();
            appointments = new List<Appointment>();
            prescriptions = new List<Prescription>();
            medicines = new List<Medicine>();
            staffMembers = new List<Staff>();
            invoices = new List<Invoice>();
            
            // Initialize with sample data
            InitializeSampleData();
        }
        
        private void InitializeSampleData()
        {
            // Add sample doctors
            doctors.Add(new Doctor("Ahmet", "Yılmaz", "Cardiology", "12345678901", "5551234567", "ahmet.yilmaz@hospital.com", 150.0m));
            doctors.Add(new Doctor("Ayşe", "Kaya", "Pediatrics", "12345678902", "5551234568", "ayse.kaya@hospital.com", 120.0m));
            doctors.Add(new Doctor("Mehmet", "Demir", "Orthopedics", "12345678903", "5551234569", "mehmet.demir@hospital.com", 140.0m));
            
            // Add sample patients
            patients.Add(new Patient("Fatma", "Şahin", "12345678904", new DateTime(1985, 5, 15), "5551234570", "fatma.sahin@email.com", "İstanbul"));
            patients.Add(new Patient("Mustafa", "Çelik", "12345678905", new DateTime(1990, 8, 22), "5551234571", "mustafa.celik@email.com", "Ankara"));
            patients.Add(new Patient("Elif", "Öztürk", "12345678906", new DateTime(2015, 3, 10), "5551234572", "elif.ozturk@email.com", "İzmir"));
            
            // Add sample medicines
            medicines.Add(new Medicine("Paracetamol", "Pain reliever", "PharmaCo", 5.50m, 100, DateTime.Now.AddYears(2), false));
            medicines.Add(new Medicine("Amoxicillin", "Antibiotic", "MediCorp", 12.75m, 50, DateTime.Now.AddYears(1), true));
            medicines.Add(new Medicine("Loratadine", "Antihistamine", "HealthPlus", 8.25m, 75, DateTime.Now.AddYears(3), false));
            
            // Add sample staff
            staffMembers.Add(new Staff("Ali", "Koç", "12345678907", "Secretary", "5551234573", "ali.koc@hospital.com", 4500.0m));
            staffMembers.Add(new Staff("Zeynep", "Arslan", "12345678908", "Nurse", "5551234574", "zeynep.arslan@hospital.com", 5500.0m));
            staffMembers.Add(new Staff("Hakan", "Taş", "12345678909", "Admin", "5551234575", "hakan.tas@hospital.com", 7000.0m));
        }
        
        public void Run()
        {
            bool running = true;
            
            while (running)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        PatientRegistrationMenu();
                        break;
                    case "2":
                        AppointmentMenu();
                        break;
                    case "3":
                        DoctorPanelMenu();
                        break;
                    case "4":
                        PrescriptionMenu();
                        break;
                    case "5":
                        StaffManagementMenu();
                        break;
                    case "6":
                        BillingMenu();
                        break;
                    case "7":
                        ReportingMenu();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                
                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        
        private void ShowMainMenu()
        {
            Console.WriteLine("\n🏥 Hospital Management System");
            Console.WriteLine("============================");
            Console.WriteLine("1. Patient Registration");
            Console.WriteLine("2. Appointment System");
            Console.WriteLine("3. Doctor Panel");
            Console.WriteLine("4. Prescription & Medicine");
            Console.WriteLine("5. Staff Management");
            Console.WriteLine("6. Billing & Payment");
            Console.WriteLine("7. Reporting & Logging");
            Console.WriteLine("0. Exit");
            Console.Write("Please select an option: ");
        }
        
        // Patient Registration Methods
        private void PatientRegistrationMenu()
        {
            Console.WriteLine("\n📋 Patient Registration");
            Console.WriteLine("======================");
            Console.WriteLine("1. Register New Patient");
            Console.WriteLine("2. View All Patients");
            Console.WriteLine("3. Search Patient");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    RegisterNewPatient();
                    break;
                case "2":
                    ViewAllPatients();
                    break;
                case "3":
                    SearchPatient();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void RegisterNewPatient()
        {
            Console.WriteLine("\n📝 Register New Patient");
            Console.WriteLine("======================");
            
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            
            Console.Write("TC Number: ");
            string tcNumber = Console.ReadLine();
            
            Console.Write("Date of Birth (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                Console.Write("Phone Number: ");
                string phone = Console.ReadLine();
                
                Console.Write("Email: ");
                string email = Console.ReadLine();
                
                Console.Write("Address: ");
                string address = Console.ReadLine();
                
                var patient = new Patient(firstName, lastName, tcNumber, dob, phone, email, address);
                patient.Id = patients.Count + 1;
                patients.Add(patient);
                
                Console.WriteLine($"Patient {patient.GetFullName()} registered successfully with ID: {patient.Id}");
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }
        
        private void ViewAllPatients()
        {
            Console.WriteLine("\n👥 All Patients");
            Console.WriteLine("================");
            
            if (patients.Count == 0)
            {
                Console.WriteLine("No patients registered.");
                return;
            }
            
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Id}. {patient}");
            }
        }
        
        private void SearchPatient()
        {
            Console.WriteLine("\n🔍 Search Patient");
            Console.WriteLine("=================");
            Console.Write("Enter patient name or TC number: ");
            string searchTerm = Console.ReadLine();
            
            var foundPatients = patients.FindAll(p => 
                p.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.TCNumber.Contains(searchTerm));
            
            if (foundPatients.Count == 0)
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                Console.WriteLine($"Found {foundPatients.Count} patient(s):");
                foreach (var patient in foundPatients)
                {
                    Console.WriteLine($"{patient.Id}. {patient}");
                }
            }
        }
        
        // Appointment Methods
        private void AppointmentMenu()
        {
            Console.WriteLine("\n📅 Appointment System");
            Console.WriteLine("====================");
            Console.WriteLine("1. Schedule New Appointment");
            Console.WriteLine("2. View All Appointments");
            Console.WriteLine("3. Cancel Appointment");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ScheduleAppointment();
                    break;
                case "2":
                    ViewAllAppointments();
                    break;
                case "3":
                    CancelAppointment();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void ScheduleAppointment()
        {
            Console.WriteLine("\n📅 Schedule New Appointment");
            Console.WriteLine("===========================");
            
            // Show available doctors
            Console.WriteLine("Available Doctors:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Id}. {doctor}");
            }
            
            Console.Write("Select Doctor ID: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                var doctor = doctors.Find(d => d.Id == doctorId);
                if (doctor == null)
                {
                    Console.WriteLine("Doctor not found.");
                    return;
                }
                
                // Show available patients
                Console.WriteLine("Available Patients:");
                foreach (var patient in patients)
                {
                    Console.WriteLine($"{patient.Id}. {patient}");
                }
                
                Console.Write("Select Patient ID: ");
                if (int.TryParse(Console.ReadLine(), out int patientId))
                {
                    var patient = patients.Find(p => p.Id == patientId);
                    if (patient == null)
                    {
                        Console.WriteLine("Patient not found.");
                        return;
                    }
                    
                    Console.Write("Appointment Date (yyyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDate))
                    {
                        Console.Write("Appointment Time (hh:mm): ");
                        if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan appointmentTime))
                        {
                            Console.Write("Reason for appointment: ");
                            string reason = Console.ReadLine();
                            
                            var appointment = new Appointment(patientId, doctorId, appointmentDate, appointmentTime, reason);
                            appointment.Id = appointments.Count + 1;
                            appointment.Patient = patient;
                            appointment.Doctor = doctor;
                            appointments.Add(appointment);
                            
                            Console.WriteLine($"Appointment scheduled successfully for {patient.GetFullName()} with {doctor.GetFullName()} on {appointment.GetFormattedDateTime()}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid time format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid patient ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid doctor ID.");
            }
        }
        
        private void ViewAllAppointments()
        {
            Console.WriteLine("\n📅 All Appointments");
            Console.WriteLine("===================");
            
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments scheduled.");
                return;
            }
            
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"{appointment.Id}. {appointment}");
            }
        }
        
        private void CancelAppointment()
        {
            Console.WriteLine("\n❌ Cancel Appointment");
            Console.WriteLine("====================");
            
            ViewAllAppointments();
            
            Console.Write("Enter Appointment ID to cancel: ");
            if (int.TryParse(Console.ReadLine(), out int appointmentId))
            {
                var appointment = appointments.Find(a => a.Id == appointmentId);
                if (appointment == null)
                {
                    Console.WriteLine("Appointment not found.");
                    return;
                }
                
                if (appointment.IsCancelled())
                {
                    Console.WriteLine("Appointment is already cancelled.");
                    return;
                }
                
                appointment.Cancel();
                Console.WriteLine($"Appointment #{appointment.Id} has been cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid appointment ID.");
            }
        }
        
        // Doctor Panel Methods
        private void DoctorPanelMenu()
        {
            Console.WriteLine("\n👨‍⚕️ Doctor Panel");
            Console.WriteLine("=================");
            Console.WriteLine("1. View Doctor's Patient List");
            Console.WriteLine("2. Add Medical Notes");
            Console.WriteLine("3. Write Prescription");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ViewDoctorPatientList();
                    break;
                case "2":
                    // Add medical notes functionality
                    Console.WriteLine("Medical notes feature coming soon...");
                    break;
                case "3":
                    WritePrescription();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void ViewDoctorPatientList()
        {
            Console.WriteLine("\n📋 Doctor's Patient List");
            Console.WriteLine("========================");
            
            // Show available doctors
            Console.WriteLine("Available Doctors:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Id}. {doctor}");
            }
            
            Console.Write("Select Doctor ID: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                var doctor = doctors.Find(d => d.Id == doctorId);
                if (doctor == null)
                {
                    Console.WriteLine("Doctor not found.");
                    return;
                }
                
                // Find appointments for this doctor
                var doctorAppointments = appointments.FindAll(a => a.DoctorId == doctorId && !a.IsCancelled());
                
                if (doctorAppointments.Count == 0)
                {
                    Console.WriteLine($"No patients scheduled for Dr. {doctor.GetFullName()}.");
                    return;
                }
                
                Console.WriteLine($"\nPatients for Dr. {doctor.GetFullName()}:");
                foreach (var appointment in doctorAppointments)
                {
                    Console.WriteLine($"- {appointment.Patient?.GetFullName()} on {appointment.GetFormattedDateTime()}");
                }
            }
            else
            {
                Console.WriteLine("Invalid doctor ID.");
            }
        }
        
        // Prescription Methods
        private void PrescriptionMenu()
        {
            Console.WriteLine("\n💊 Prescription & Medicine");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Write Prescription");
            Console.WriteLine("2. View Prescriptions");
            Console.WriteLine("3. Medicine Stock Management");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WritePrescription();
                    break;
                case "2":
                    ViewPrescriptions();
                    break;
                case "3":
                    MedicineStockManagement();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void WritePrescription()
        {
            Console.WriteLine("\n📝 Write Prescription");
            Console.WriteLine("=====================");
            
            // Show available doctors
            Console.WriteLine("Available Doctors:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Id}. {doctor}");
            }
            
            Console.Write("Select Doctor ID: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                var doctor = doctors.Find(d => d.Id == doctorId);
                if (doctor == null)
                {
                    Console.WriteLine("Doctor not found.");
                    return;
                }
                
                // Show available patients
                Console.WriteLine("Available Patients:");
                foreach (var patient in patients)
                {
                    Console.WriteLine($"{patient.Id}. {patient}");
                }
                
                Console.Write("Select Patient ID: ");
                if (int.TryParse(Console.ReadLine(), out int patientId))
                {
                    var patient = patients.Find(p => p.Id == patientId);
                    if (patient == null)
                    {
                        Console.WriteLine("Patient not found.");
                        return;
                    }
                    
                    Console.Write("Diagnosis: ");
                    string diagnosis = Console.ReadLine();
                    
                    Console.Write("Notes: ");
                    string notes = Console.ReadLine();
                    
                    var prescription = new Prescription(patientId, doctorId, diagnosis, notes);
                    prescription.Id = prescriptions.Count + 1;
                    prescription.Patient = patient;
                    prescription.Doctor = doctor;
                    prescriptions.Add(prescription);
                    
                    Console.WriteLine($"Prescription #{prescription.Id} created for {patient.GetFullName()} by Dr. {doctor.GetFullName()}");
                    
                    // Add prescription items
                    AddPrescriptionItems(prescription);
                }
                else
                {
                    Console.WriteLine("Invalid patient ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid doctor ID.");
            }
        }
        
        private void AddPrescriptionItems(Prescription prescription)
        {
            bool addingItems = true;
            
            while (addingItems)
            {
                Console.WriteLine("\n➕ Add Medicine to Prescription");
                Console.WriteLine("===============================");
                
                // Show available medicines
                Console.WriteLine("Available Medicines:");
                foreach (var medicine in medicines)
                {
                    Console.WriteLine($"{medicine.Id}. {medicine}");
                }
                
                Console.Write("Select Medicine ID (0 to finish): ");
                if (int.TryParse(Console.ReadLine(), out int medicineId))
                {
                    if (medicineId == 0)
                    {
                        addingItems = false;
                        continue;
                    }
                    
                    var medicine = medicines.Find(m => m.Id == medicineId);
                    if (medicine == null)
                    {
                        Console.WriteLine("Medicine not found.");
                        continue;
                    }
                    
                    Console.Write("Dosage: ");
                    string dosage = Console.ReadLine();
                    
                    Console.Write("Frequency: ");
                    string frequency = Console.ReadLine();
                    
                    Console.Write("Quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        Console.Write("Instructions: ");
                        string instructions = Console.ReadLine();
                        
                        var prescriptionItem = new PrescriptionItem(
                            prescription.Id, medicineId, medicine.Name, dosage, frequency, 
                            quantity, medicine.UnitPrice, instructions);
                        
                        prescriptionItem.Id = prescription.PrescriptionItems.Count + 1;
                        prescription.PrescriptionItems.Add(prescriptionItem);
                        
                        Console.WriteLine($"Added {medicine.Name} to prescription.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid medicine ID.");
                }
            }
            
            Console.WriteLine($"\nPrescription total: ${prescription.GetTotalCost():F2}");
        }
        
        private void ViewPrescriptions()
        {
            Console.WriteLine("\n📋 All Prescriptions");
            Console.WriteLine("====================");
            
            if (prescriptions.Count == 0)
            {
                Console.WriteLine("No prescriptions found.");
                return;
            }
            
            foreach (var prescription in prescriptions)
            {
                Console.WriteLine($"\n{prescription}");
                Console.WriteLine($"Diagnosis: {prescription.Diagnosis}");
                Console.WriteLine($"Notes: {prescription.Notes}");
                
                if (prescription.PrescriptionItems.Count > 0)
                {
                    Console.WriteLine("Medicines:");
                    foreach (var item in prescription.PrescriptionItems)
                    {
                        Console.WriteLine($"  - {item}");
                    }
                }
            }
        }
        
        private void MedicineStockManagement()
        {
            Console.WriteLine("\n📦 Medicine Stock Management");
            Console.WriteLine("============================");
            Console.WriteLine("1. View All Medicines");
            Console.WriteLine("2. Check Stock Levels");
            Console.WriteLine("3. Update Stock");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ViewAllMedicines();
                    break;
                case "2":
                    CheckStockLevels();
                    break;
                case "3":
                    UpdateStock();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void ViewAllMedicines()
        {
            Console.WriteLine("\n💊 All Medicines");
            Console.WriteLine("================");
            
            if (medicines.Count == 0)
            {
                Console.WriteLine("No medicines in inventory.");
                return;
            }
            
            foreach (var medicine in medicines)
            {
                string status = medicine.IsExpired() ? " [EXPIRED]" : "";
                Console.WriteLine($"{medicine.Id}. {medicine}{status}");
            }
        }
        
        private void CheckStockLevels()
        {
            Console.WriteLine("\n📊 Stock Levels");
            Console.WriteLine("===============");
            
            int lowStockThreshold = 10;
            var lowStockMedicines = medicines.FindAll(m => m.StockQuantity <= lowStockThreshold && !m.IsExpired());
            
            if (lowStockMedicines.Count == 0)
            {
                Console.WriteLine("All medicines are well-stocked.");
            }
            else
            {
                Console.WriteLine("Low stock medicines:");
                foreach (var medicine in lowStockMedicines)
                {
                    Console.WriteLine($"- {medicine.Name}: {medicine.StockQuantity} units remaining");
                }
            }
        }
        
        private void UpdateStock()
        {
            Console.WriteLine("\n📦 Update Stock");
            Console.WriteLine("===============");
            
            ViewAllMedicines();
            
            Console.Write("Enter Medicine ID: ");
            if (int.TryParse(Console.ReadLine(), out int medicineId))
            {
                var medicine = medicines.Find(m => m.Id == medicineId);
                if (medicine == null)
                {
                    Console.WriteLine("Medicine not found.");
                    return;
                }
                
                Console.Write("Enter quantity to add/remove (negative to remove): ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    if (quantity >= 0)
                    {
                        medicine.IncreaseStock(quantity);
                        Console.WriteLine($"Added {quantity} units to {medicine.Name}. New stock: {medicine.StockQuantity}");
                    }
                    else
                    {
                        try
                        {
                            medicine.ReduceStock(Math.Abs(quantity));
                            Console.WriteLine($"Removed {Math.Abs(quantity)} units from {medicine.Name}. New stock: {medicine.StockQuantity}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid quantity.");
                }
            }
            else
            {
                Console.WriteLine("Invalid medicine ID.");
            }
        }
        
        // Staff Management Methods
        private void StaffManagementMenu()
        {
            Console.WriteLine("\n👥 Staff Management");
            Console.WriteLine("===================");
            Console.WriteLine("1. View All Staff");
            Console.WriteLine("2. Add New Staff");
            Console.WriteLine("3. View Staff by Role");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ViewAllStaff();
                    break;
                case "2":
                    AddNewStaff();
                    break;
                case "3":
                    ViewStaffByRole();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void ViewAllStaff()
        {
            Console.WriteLine("\n👥 All Staff Members");
            Console.WriteLine("====================");
            
            if (staffMembers.Count == 0)
            {
                Console.WriteLine("No staff members registered.");
                return;
            }
            
            foreach (var staff in staffMembers)
            {
                string status = staff.IsActive ? "Active" : "Inactive";
                Console.WriteLine($"{staff.Id}. {staff} - {status}");
            }
        }
        
        private void AddNewStaff()
        {
            Console.WriteLine("\n➕ Add New Staff");
            Console.WriteLine("================");
            
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            
            Console.Write("TC Number: ");
            string tcNumber = Console.ReadLine();
            
            Console.Write("Role (Doctor/Nurse/Secretary/Admin): ");
            string role = Console.ReadLine();
            
            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();
            
            Console.Write("Email: ");
            string email = Console.ReadLine();
            
            Console.Write("Salary: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                var staff = new Staff(firstName, lastName, tcNumber, role, phone, email, salary);
                staff.Id = staffMembers.Count + 1;
                staffMembers.Add(staff);
                
                Console.WriteLine($"Staff member {staff.GetFullName()} added successfully with ID: {staff.Id}");
            }
            else
            {
                Console.WriteLine("Invalid salary format.");
            }
        }
        
        private void ViewStaffByRole()
        {
            Console.WriteLine("\n👥 Staff by Role");
            Console.WriteLine("=================");
            Console.Write("Enter role (Doctor/Nurse/Secretary/Admin): ");
            string role = Console.ReadLine();
            
            var staffByRole = staffMembers.FindAll(s => 
                s.Role.Equals(role, StringComparison.OrdinalIgnoreCase));
            
            if (staffByRole.Count == 0)
            {
                Console.WriteLine($"No staff members found with role: {role}");
            }
            else
            {
                Console.WriteLine($"Staff members with role {role}:");
                foreach (var staff in staffByRole)
                {
                    string status = staff.IsActive ? "Active" : "Inactive";
                    Console.WriteLine($"{staff.Id}. {staff.GetFullName()} - {status}");
                }
            }
        }
        
        // Billing Methods
        private void BillingMenu()
        {
            Console.WriteLine("\n💰 Billing & Payment");
            Console.WriteLine("====================");
            Console.WriteLine("1. Create Invoice");
            Console.WriteLine("2. View Invoices");
            Console.WriteLine("3. Process Payment");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    CreateInvoice();
                    break;
                case "2":
                    ViewInvoices();
                    break;
                case "3":
                    ProcessPayment();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void CreateInvoice()
        {
            Console.WriteLine("\n🧾 Create Invoice");
            Console.WriteLine("=================");
            
            // Show available patients
            Console.WriteLine("Available Patients:");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Id}. {patient}");
            }
            
            Console.Write("Select Patient ID: ");
            if (int.TryParse(Console.ReadLine(), out int patientId))
            {
                var patient = patients.Find(p => p.Id == patientId);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }
                
                Console.Write("Service Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal serviceAmount))
                {
                    Console.Write("Insurance Provider: ");
                    string insuranceProvider = Console.ReadLine();
                    
                    Console.Write("Insurance Coverage: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal insuranceCoverage))
                    {
                        var invoice = new Invoice(patientId, serviceAmount, insuranceProvider, insuranceCoverage);
                        invoice.Id = invoices.Count + 1;
                        invoice.Patient = patient;
                        invoices.Add(invoice);
                        
                        Console.WriteLine($"Invoice #{invoice.Id} created successfully for {patient.GetFullName()}");
                        Console.WriteLine($"Total Amount: ${invoice.TotalAmount:F2}");
                        Console.WriteLine($"Remaining Amount: ${invoice.RemainingAmount:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid insurance coverage format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid service amount format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid patient ID.");
            }
        }
        
        private void ViewInvoices()
        {
            Console.WriteLine("\n🧾 All Invoices");
            Console.WriteLine("================");
            
            if (invoices.Count == 0)
            {
                Console.WriteLine("No invoices found.");
                return;
            }
            
            foreach (var invoice in invoices)
            {
                Console.WriteLine($"{invoice.Id}. {invoice}");
                Console.WriteLine($"  Service Amount: ${invoice.ServiceAmount:F2}");
                Console.WriteLine($"  Insurance: {invoice.InsuranceProvider} (${invoice.InsuranceCoverage:F2})");
                Console.WriteLine($"  Total: ${invoice.TotalAmount:F2}");
                Console.WriteLine($"  Paid: ${invoice.PaidAmount:F2}");
                Console.WriteLine($"  Remaining: ${invoice.RemainingAmount:F2}");
            }
        }
        
        private void ProcessPayment()
        {
            Console.WriteLine("\n💳 Process Payment");
            Console.WriteLine("==================");
            
            ViewInvoices();
            
            Console.Write("Enter Invoice ID: ");
            if (int.TryParse(Console.ReadLine(), out int invoiceId))
            {
                var invoice = invoices.Find(i => i.Id == invoiceId);
                if (invoice == null)
                {
                    Console.WriteLine("Invoice not found.");
                    return;
                }
                
                if (invoice.PaymentStatus == PaymentStatus.Paid)
                {
                    Console.WriteLine("Invoice is already fully paid.");
                    return;
                }
                
                Console.WriteLine($"Remaining amount: ${invoice.RemainingAmount:F2}");
                Console.Write("Payment Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal paymentAmount))
                {
                    try
                    {
                        invoice.AddPayment(paymentAmount);
                        Console.WriteLine($"Payment of ${paymentAmount:F2} processed successfully.");
                        Console.WriteLine($"New balance: ${invoice.RemainingAmount:F2}");
                        Console.WriteLine($"Payment status: {invoice.PaymentStatus}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid payment amount format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid invoice ID.");
            }
        }
        
        // Reporting Methods
        private void ReportingMenu()
        {
            Console.WriteLine("\n📊 Reporting & Logging");
            Console.WriteLine("======================");
            Console.WriteLine("1. Daily Appointments Report");
            Console.WriteLine("2. Revenue Report");
            Console.WriteLine("3. Medicine Inventory Report");
            Console.Write("Please select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    DailyAppointmentsReport();
                    break;
                case "2":
                    RevenueReport();
                    break;
                case "3":
                    MedicineInventoryReport();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        
        private void DailyAppointmentsReport()
        {
            Console.WriteLine("\n📅 Daily Appointments Report");
            Console.WriteLine("============================");
            
            Console.Write("Enter date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime reportDate))
            {
                var dailyAppointments = appointments.FindAll(a => 
                    a.AppointmentDate.Date == reportDate.Date);
                
                Console.WriteLine($"\nAppointments for {reportDate:dd/MM/yyyy}:");
                
                if (dailyAppointments.Count == 0)
                {
                    Console.WriteLine("No appointments scheduled for this date.");
                }
                else
                {
                    foreach (var appointment in dailyAppointments)
                    {
                        Console.WriteLine($"- {appointment.Patient?.GetFullName()} with Dr. {appointment.Doctor?.GetFullName()} at {appointment.AppointmentTime:hh\\:mm} - {appointment.Status}");
                    }
                    
                    Console.WriteLine($"\nTotal appointments: {dailyAppointments.Count}");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }
        
        private void RevenueReport()
        {
            Console.WriteLine("\n💰 Revenue Report");
            Console.WriteLine("=================");
            
            decimal totalRevenue = 0;
            decimal paidRevenue = 0;
            decimal pendingRevenue = 0;
            
            foreach (var invoice in invoices)
            {
                totalRevenue += invoice.TotalAmount;
                paidRevenue += invoice.PaidAmount;
                pendingRevenue += invoice.RemainingAmount;
            }
            
            Console.WriteLine($"Total Invoiced: ${totalRevenue:F2}");
            Console.WriteLine($"Total Paid: ${paidRevenue:F2}");
            Console.WriteLine($"Total Pending: ${pendingRevenue:F2}");
        }
        
        private void MedicineInventoryReport()
        {
            Console.WriteLine("\n📦 Medicine Inventory Report");
            Console.WriteLine("============================");
            
            int totalMedicines = medicines.Count;
            int inStockCount = medicines.Count(m => m.StockQuantity > 0 && !m.IsExpired());
            int lowStockCount = medicines.Count(m => m.StockQuantity <= 10 && m.StockQuantity > 0 && !m.IsExpired());
            int outOfStockCount = medicines.Count(m => m.StockQuantity == 0);
            int expiredCount = medicines.Count(m => m.IsExpired());
            
            Console.WriteLine($"Total Medicines: {totalMedicines}");
            Console.WriteLine($"In Stock: {inStockCount}");
            Console.WriteLine($"Low Stock (≤10): {lowStockCount}");
            Console.WriteLine($"Out of Stock: {outOfStockCount}");
            Console.WriteLine($"Expired: {expiredCount}");
        }
    }
}
