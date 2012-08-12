using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songkhue.SE303.Core.Branch
{
    public class BranchManager
    {
        private Dev_Sk_SE303Entities _context;
        private Repository<Sk_Branch> _reporsitory;

        public BranchManager()
        {
            _context = new Dev_Sk_SE303Entities();
            _reporsitory = new Repository<Sk_Branch>(_context, true);
        }

        public Sk_Branch GetBranchById(int branchId)
        {
            return _reporsitory.Fetch().Where(x => x.Id == branchId).SingleOrDefault();
        }
    }
}
