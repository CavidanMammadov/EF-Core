using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Helper.Exceptions
{
    public  class ProductNotFoundException:Exception
    {
        public ProductNotFoundException(string msg):base(msg) { }
    }
}
