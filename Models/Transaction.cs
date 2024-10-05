using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPbit.Models
{
    public class Transaction
    {
       
    public int TransactionId { get; set; }
    public required string Sender { get; set; }
    public required string Receiver { get; set; }
    public required string OriginCountry { get; set; }
    public required string DestinationCountry { get; set; }
    public decimal AmountSent { get; set; }
    public required string CurrencySent { get; set; } // USD or BTC
    public decimal ExchangeRate { get; set; }
    public decimal AmountReceived { get; set; }
    public required string CurrencyReceived { get; set; }
    public DateTime TransactionDate { get; set; }
    public required string Status { get; set; } // Pending, Completed, Failed
}

    
}