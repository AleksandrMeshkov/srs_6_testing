using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using srs_6_testing.Models;

namespace srs_6_testing
{
    public class Helper
    {
        public static StudentEntities _context;
        public static StudentEntities GetContext()
        {
            if (_context == null)
            {
                _context = new StudentEntities();
            }
            return _context;
        }
    }
}
