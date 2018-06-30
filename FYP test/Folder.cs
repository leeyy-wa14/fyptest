using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_test
{
    class Folder
    {
        public bool isEmpty(String directory)
        {
            Boolean isEmpty;

            DirectoryInfo dir = new DirectoryInfo(@directory);
            FileInfo[] TXTFiles = dir.GetFiles("*.txt");
            if (TXTFiles.Length == 0)
                isEmpty = true;
            else
                isEmpty = false;
            return isEmpty;
        }

        public bool read(String directory, ref DeliveryOrder deliveryOrder)
        {
            if (!isEmpty(directory))
            {
                DirectoryInfo dir = new DirectoryInfo(@directory);
                FileInfo[] TXTFiles = dir.GetFiles("*.txt");

                var lines = File.ReadAllLines(@dir + "\\" + TXTFiles[0].Name);

                string[] data = lines[0].Split(',');

                deliveryOrder.setPONo(data[0]);
                deliveryOrder.setDescriptionNo(data[1]);
                deliveryOrder.setLineNo(data[2]);
                int deliveryQty = int.Parse(data[3]);
                deliveryOrder.setDeliveryQty(deliveryQty);
                deliveryOrder.setDeliveryDate(data[4]);

                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
