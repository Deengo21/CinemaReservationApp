﻿using DataEngine;

namespace BackEnd
{
    public class Payments
    {
        private readonly CinemaContext _dbContext;

        public int PaymentId { get; set; }
        public decimal Cost { get; set; }
        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsConfirmed { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Payments(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Metoda dokonywania płatności
        public async Task<bool> MakePayment(int customerId, decimal amount)
        {

            var payment = new DataSchema.Payment()
            {
                PaymentId = customerId,
                Cost = amount,
                PaymentDate = DateTime.Now,
                IsConfirmed = false // Początkowo płatność nie jest potwierdzona
            };

            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();

            // Po udanej płatności ustaw flagę IsConfirmed na true
            payment.IsConfirmed = true;
            await _dbContext.SaveChangesAsync();

            return true; // Zakładamy, że płatność zakończyła się pomyślnie
        }

        // Metoda potwierdzania płatności
        public async Task<bool> ConfirmPayment(int paymentId)
        {

            var payment = await _dbContext.Payments.FindAsync(paymentId);

            if (payment != null)
            {
                payment.IsConfirmed = true;
                await _dbContext.SaveChangesAsync();
                return true; // Potwierdzono płatność
            }

            return false; // Nie znaleziono płatności o podanym ID
        }
    }
}
