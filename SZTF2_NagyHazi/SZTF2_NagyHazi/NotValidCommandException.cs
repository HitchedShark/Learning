using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class NotValidCommandException:Exception
    {
        public NotValidCommandException(string message):base(message)
        {

        }
    }
}
