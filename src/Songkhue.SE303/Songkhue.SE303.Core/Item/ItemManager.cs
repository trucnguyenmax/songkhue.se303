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

        public ItemManager()
        {
            _context = new Dev_Sk_SE303Entities();
            _reporsitory = new Repository<Sk_Item>(_context, true);
        }

        public void Add(Sk_Item item)
        {
            item.CreatedOn = DateTime.Now;

            _reporsitory.Add(item);
            _reporsitory.SaveChanges();
        }

        public void Update(Sk_Item item)
        {
            item.CreatedOn = DateTime.Now;
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

        public Sk_Item GetItemById(int id)
        {
            return _reporsitory.Fetch().Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<Sk_Item> GetItemsByGroup(int group)
        {
            return _reporsitory.Fetch().Where(x => x.ItemGroup == group).OrderByDescending(x => x.Id).AsEnumerable();
        }

        public IEnumerable<Sk_Item> GetAllItems()
        {
            return _reporsitory.Fetch().OrderByDescending(x => x.Id).AsEnumerable();
        }
    }
}
