using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EPbit.Data;
using Microsoft.AspNetCore.Mvc;

namespace EPbit.Controllers
public class TransactionsControllers : Controller
{
    private readonly RemittanceDbContext _context;

    public TransactionsControllers(RemittanceDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Transaction transaction)
    {
        if (ModelState.IsValid)
        {
            transaction.TransactionDate = DateTime.Now;
            transaction.Status = "Pending";

            // Calcula el monto recibido basado en la tasa de cambio y la moneda enviada
            if (transaction.CurrencySent == "USD")
            {
                transaction.AmountReceived = transaction.AmountSent / transaction.ExchangeRate; // USD a BTC
                transaction.CurrencyReceived = "BTC";
            }
            else
            {
                transaction.AmountReceived = transaction.AmountSent * transaction.ExchangeRate; // BTC a USD
                transaction.CurrencyReceived = "USD";
            }

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(transaction);
    }
}
