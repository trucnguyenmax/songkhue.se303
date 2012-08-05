using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songkhue.SE303.Core.Item
{
    public class ItemManager
    {
        private Dev_Sk_SE303Entities _context;
        private Repository<Sk_Item> _reporsitory;

        private ItemManager()
        {
            _context = new Dev_Sk_SE303Entities();
            _reporsitory = new Repository<Sk_Item>(_context, true);
        }

        public void Add(Sk_Item item)
        {
            _reporsitory.Add(item);
            _reporsitory.SaveChanges();
        }

        public void Update(Sk_Item item)
        {
            _reporsitory.Edit(item);
            _reporsitory.SaveChanges();
        }

        public void Delete(Sk_Item item)
        {
            _reporsitory.Delete(item);
            _reporsitory.SaveChanges();
        }

        public IQueryable<Sk_Item> GetItems()
        {
            return _reporsitory.Fetch();
        }
    }
}
