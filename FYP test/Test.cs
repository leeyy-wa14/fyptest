using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_test
{
    class Test
    {
        static void Main()
        {
            DeliveryOrder dor = new DeliveryOrder("3320-17020041", "1001", "001", 8000, "25/06/2018");
            
            Validation test = new Validation();
            if (test.Validate(dor)) {
                Console.Write("Validated");
            }
            else
            { 
            Console.Write("Wrong");
            }

            Calculation cal = new Calculation();
            if (cal.confirmDeliveryDate(dor))
            {
                Console.Write("True");
            }
            else
                Console.Write("False");
        }


    }
}
