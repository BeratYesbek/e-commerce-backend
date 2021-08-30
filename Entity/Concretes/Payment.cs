using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concretes
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }

        public string CardNumber {  get; set; }

        public string CardHolderName { get; set; }

        public string ExpiryDate { get; set; }

        public int Cvv { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int ProductId  { get; set; }

        public int CartSummaryId { get; set; }

        public float TotalPrice { get; set; }

        public DateTime date { get; set; }

        public string Email { get; set; }
    }
}
