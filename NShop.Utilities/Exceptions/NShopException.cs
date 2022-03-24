using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Utilities.Exceptions
{
    public class NShopException : Exception
    {
        public NShopException()
        {
        }

        public NShopException(string message)
            : base(message)
        {
        }

        public NShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
