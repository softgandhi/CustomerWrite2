using CustomerWrite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Repository
{
    public class SQLRepository : ISQLRepository
    {
        private CustmerDomainContext _context;
        public SQLRepository(CustmerDomainContext context)
        {
            _context = context;
        }
        public async Task<Customers> AddCustomer(Customers customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public async Task<Customers> DeleteCustomer(int customerid)
        {
            Customers cust = this.GetCustomerbyid(customerid);
            _context.Customers.Remove(cust);
            await _context.SaveChangesAsync();
            return cust;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customers GetCustomerbyid(int customerid)
        {
            var cust = _context.Customers.Where<Customers>(c => c.CustomerId == customerid).SingleOrDefault();
            return cust;
        }

        public async Task<Customers> UpdateCustomer(Customers customer)
        {
            var custid = customer.CustomerId;
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
