using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_test
{
    class DeliveryOrder
    {
        private string PONo;
        private string DescriptionNo;
        private string LineNo;
        private int DeliveryQty;
        private string DeliveryDate;

        public DeliveryOrder(string pONo,string descriptionNo, string lineNo, int deliveryQty, string deliveryDate)
        {
            PONo = pONo;
            DescriptionNo = descriptionNo;
            LineNo = lineNo;
            DeliveryQty = deliveryQty;
            DeliveryDate = deliveryDate;
        }
        public DeliveryOrder()
        {

        }
        
        public void setPONo(string pono)
        {
            PONo = pono;
        }
        
        public void setDescriptionNo(string descriptionNo)
        {
            DescriptionNo = descriptionNo;
        }
        public void setLineNo(string lineNo)
        {
            LineNo = lineNo;
        }
        public void setDeliveryQty(int deliveryQty)
        {
            DeliveryQty = deliveryQty;
        }
        public void setDeliveryDate(string deliveryDate)
        {
            DeliveryDate = deliveryDate;
        }
        public string getPONo()
        {
            return PONo;
        }
        public string getDescriptionNo()
        {
            return DescriptionNo;
        }
        public string getLineNo()
        {
            return LineNo;
        }
        public int getDeliveryQty()
        {
            return DeliveryQty;
        }
        public string getDeliveryDate()
        {
            return DeliveryDate;
        }

        public override string ToString()
        {
            string value = "Purchase Order No : " + PONo+
                            "\nDescription No : " + DescriptionNo +
                           "\nLine No : " + LineNo +
                           "\nDelivery Quantity : " + DeliveryQty +
                           "\nDelviery Date : " + DeliveryDate + "\n";
            return value;
        }
    }
}
