using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_test
{
    class Validation
    {
        public bool Validate(DeliveryOrder deliveryOrder)
        {
            PurchaseOrderItem po = new PurchaseOrderItem();

            //var con = ConfigurationManager.ConnectionStrings["Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\"C: \\Users\\PUA\\Desktop\\FYP test\\FYP test\\fypDB.mdf\";Integrated Security=True"] .ConnectionString;
            //SqlConnection myConnection = new SqlConnection(con);
            //string queryString = "select * from PurchaseOrder where PONo = @PONo";
            //SqlCommand query = new SqlCommand(queryString, myConnection);
            //query.Parameters.AddWithValue("@PONo", deliveryOrder.getPONo());
            //}
            //myConnection.Open();


            //using (SqlDataReader oReader = query.ExecuteReader())
            //{
            //    while (oReader.Read())
            //    {
            //        po.setLineNO(oReader["LineNo"].ToString());
            //        po.setPONo(oReader["PONo"].ToString());
            //        po.setDescriptionNO(oReader["DescriptionNo"].ToString());
            //        po.setETADate(oReader["ETADate"].ToString());
            //    }
            //}

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

            }catch (Exception ex)
            {

            }
            

            if (deliveryOrder.getPONo().Equals(po.getPoNo()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
