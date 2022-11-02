using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceRepository.Tests
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private IQueryable<Invoice> _invoices;
        
        public InvoiceRepository(IQueryable<Invoice>? invoices)
        {
            if (invoices is null) 
                throw new ArgumentNullException(nameof(invoices), "Invoices should not be null");

            _invoices = invoices;
        }

        /// <summary>
        /// Should return a total value of an invoice with a given id. If an invoice does not exist null should be returned.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public decimal? GetTotal(int invoiceId)
        {
            Invoice? exist = _invoices.SingleOrDefault(e => e.Id == invoiceId);
            if (exist != null)
            {
                return exist.InvoiceItems.Sum(item => item.Count * item.Price);
            }
            
            return null;
        }

        /// <summary>
        /// Should return a total value of all unpaid invoices.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalOfUnpaid()
        {
            var unpaid = _invoices.Where(e => e.AcceptanceDate == null);
            decimal total = 0;
            foreach (var invoice in unpaid)
            {
                total += invoice.InvoiceItems.Sum(e => (e.Count * e.Price));
            }

            return total;
        }

       
        /// <summary>
        /// Should return a dictionary where the name of an invoice item is a key and the number of bought items is a value.
        /// The number of bought items should be summed within a given period of time (from, to). Both the from date and the end date can be null.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
        {
            Dictionary<string, long> results = new Dictionary<string, long>();

            Func<Invoice, bool> checkRange = (invoice) =>
            {
                
                if (from == null && to != null)
                {
                    return invoice.CreationDate <= to;
                }

                if (from != null && to == null)
                {
                    return invoice.CreationDate >= from;
                }

                if (from == null && to == null)
                {
                    return true;
                }
                

                return invoice.CreationDate >= from && invoice.CreationDate <= to;
            };

            _invoices.Where(e => checkRange(e));
            
            // Question not very clear to me on how to deal with inclusivity and nulls
            var withRange = _invoices.Where( e => checkRange(e));
            
            
            foreach (var invoice in withRange)
            {
                var items = invoice.InvoiceItems.ToList();
                items.ForEach(item =>
                {
                    if (results.ContainsKey(item.Name))
                    {
                        var currentValue = results[item.Name];
                        results.Remove(item.Name);
                        results.Add(item.Name, currentValue + item.Count);
                    }
                    else
                    {
                        results.Add(item.Name, item.Count);
                    }
                });
            }

            return results;
        }
    }

    public interface IInvoiceRepository
    {
    }
}