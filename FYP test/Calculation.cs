using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_test
{
    class Calculation
    {

        public bool confirmDeliveryDate(DeliveryOrder deliveryOrder)
        {
            PurchaseOrderItem po = new PurchaseOrderItem();

            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\PUA\\Desktop\\FYP test\\FYP test\\fypDB.mdf\";Integrated Security=True";
            sql = "select * from POItems where PONo = @PONo";
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@PONo", deliveryOrder.getPONo());
                dataReader = command.ExecuteReader();
              while (dataReader.Read())
                {
                    po.setLineNO(dataReader["LineNo"].ToString());
                    po.setPONo(dataReader["PONo"].ToString());
                    po.setDescriptionNO(dataReader["DescriptionNo"].ToString());
                    po.setETADate(dataReader["ETADate"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
            }
            
            DateTime poETADate = DateTime.Parse(po.getETADate());
            DateTime doDate = DateTime.Parse(deliveryOrder.getDeliveryDate());

            if (doDate <= poETADate)
                return false;
            else
                return true;

        }
    }
}
