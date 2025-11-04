using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal ServiceAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string InsuranceProvider { get; set; }
        public decimal InsuranceCoverage { get; set; }
        public string Notes { get; set; }
        
        // Navigation properties
        public Patient Patient { get; set; }
        public List<Payment> Payments { get; set; }
        
        public Invoice()
        {
            InvoiceDate = DateTime.Now;
            Payments = new List<Payment>();
            PaymentStatus = PaymentStatus.Pending;
        }
        
        public Invoice(int patientId, decimal serviceAmount, string insuranceProvider, decimal insuranceCoverage)
        {
            PatientId = patientId;
            InvoiceDate = DateTime.Now;
            ServiceAmount = serviceAmount;
            InsuranceProvider = insuranceProvider;
            InsuranceCoverage = insuranceCoverage;
            Payments = new List<Payment>();
            
            // Calculate amounts
            CalculateInvoice();
        }
        
        private void CalculateInvoice()
        {
            // Apply insurance coverage
            decimal coveredAmount = Math.Min(ServiceAmount, InsuranceCoverage);
            decimal patientResponsibility = ServiceAmount - coveredAmount;
            
            // Apply discount if any
            decimal discountedAmount = patientResponsibility - DiscountAmount;
            
            // Calculate tax (assuming 18% VAT)
            TaxAmount = discountedAmount * 0.18m;
            
            // Calculate total amount
            TotalAmount = discountedAmount + TaxAmount;
            
            // Initialize payment tracking
            PaidAmount = 0;
            RemainingAmount = TotalAmount;
            
            // Set payment status
            UpdatePaymentStatus();
        }
        
        public void AddPayment(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be positive");
                
            if (amount > RemainingAmount)
                throw new ArgumentException("Payment amount exceeds remaining balance");
                
            PaidAmount += amount;
            RemainingAmount -= amount;
            
            Payments.Add(new Payment
            {
                InvoiceId = Id,
                Amount = amount,
                PaymentDate = DateTime.Now,
                PaymentMethod = "Cash" // Default payment method
            });
            
            UpdatePaymentStatus();
        }
        
        private void UpdatePaymentStatus()
        {
            if (PaidAmount <= 0)
                PaymentStatus = PaymentStatus.Pending;
            else if (RemainingAmount <= 0)
                PaymentStatus = PaymentStatus.Paid;
            else
                PaymentStatus = PaymentStatus.PartiallyPaid;
        }
        
        public override string ToString()
        {
            return $"Invoice #{Id} for {Patient?.GetFullName()} - Total: ${TotalAmount:F2} - Status: {PaymentStatus}";
        }
    }
    
    public enum PaymentStatus
    {
        Pending,
        PartiallyPaid,
        Paid,
        Overdue
    }
    
    public class Payment
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // Cash, Credit Card, Insurance, etc.
        public string ReferenceNumber { get; set; }
        
        public Payment()
        {
            PaymentDate = DateTime.Now;
        }
    }
}
