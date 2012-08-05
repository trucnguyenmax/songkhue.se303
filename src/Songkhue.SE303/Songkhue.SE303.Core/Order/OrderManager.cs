using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songkhue.SE303.Core.Order
{
    public class OrderManager
    {
        private Dev_Sk_SE303Entities _context;
        private Repository<Sk_Order> _reporsitory;

        public OrderManager()
        {
            _context = new Dev_Sk_SE303Entities();
            _reporsitory = new Repository<Sk_Order>(_context, true);
        }

        public IEnumerable<Sk_Order> GetOrders()
        {
            // remove time
            return _reporsitory.Fetch()
                .OrderByDescending(x => x.CreatedOn)
                .AsEnumerable();
        }

        public IEnumerable<Sk_Order> GetOrders(DateTime date)
        {
            return _reporsitory.Fetch().OrderByDescending(x => x.CreatedOn)
                .Where(x => DateTime.Parse(x.CreatedOn.ToShortDateString()) == date)
                .AsEnumerable();
        }
    }
}
