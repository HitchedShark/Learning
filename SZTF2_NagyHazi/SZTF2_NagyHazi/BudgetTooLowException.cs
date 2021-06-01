using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class BudgetTooLowException: Exception
    {
        public BudgetTooLowException(string message):base(message)
        {

        }
    }
}
