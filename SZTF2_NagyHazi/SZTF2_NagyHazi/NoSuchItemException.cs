using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class NoSuchItemException: Exception
    {
        public NoSuchItemException(string message):base(message)
        {

        }
    }
}
