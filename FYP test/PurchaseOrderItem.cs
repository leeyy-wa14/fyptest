using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_test
{
    class PurchaseOrderItem
    {
        private string LineNO;
        private string PONo;
        private string DescriptionNo;
        private string ETADate;
        private int Quantity;
        private float Price;

        public PurchaseOrderItem(string lineNO, string pONo, string descriptionNo, string eTADate, int quantity, float price)
        {
            LineNO = lineNO;
            PONo = pONo;
            DescriptionNo = descriptionNo;
            ETADate = eTADate;
            this.Quantity = quantity;
            this.Price = price;
        }
        public PurchaseOrderItem()
        {

        }

        public void setLineNO(string lineNo){
            LineNO = lineNo;
        }
        public void setPONo(string pono)
        {
            PONo = pono;
        }
        public void setDescriptionNO(string descriptionNo)
        {
            DescriptionNo = descriptionNo;
        }
        public void setETADate(string etaDate)
        {
            ETADate = etaDate;
        }
        public void setQuantity(int quantity)
        {
            Quantity = quantity;
        }
        public void setPrice(float price)
        {
            Price = price;
        }
        public string getLineNo()
        {
            return LineNO;
        }
        public string getPoNo()
        {
            return PONo;
        }
        public string getDescriptionNo()
        {
            return DescriptionNo;
        }
        public string getETADate()
        {
            return ETADate;
        }
        public int getQuantity()
        {
            return Quantity;
        }
        public float getPrice()
        {
            return Price;
        }
        
    }
}
