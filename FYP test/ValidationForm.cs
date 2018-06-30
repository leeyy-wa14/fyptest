using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FYP_test
{
    public partial class ValidationForm : Form
    {
        public ValidationForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            SqlConnection connection;
            string sql = null;

            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\PUA\\Desktop\\FYP test\\FYP test\\fypDB.mdf\";Integrated Security=True";

            connection = new SqlConnection(connectionString);

            connection.Open();

            sql = "SELECT * from POItems where PONo = \'3320-17020041\' ";
            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataAdapter dscmd = new SqlDataAdapter(sql, connection);

            DataSet ds = new DataSet();

            dscmd.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;

            Excel.Workbook xlWorkBook;

            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;



            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int i = 0;

            int j = 0;



            for (i = 0; i <= dataGridView1.RowCount - 1; i++)

            {

                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)

                {

                    DataGridViewCell cell = dataGridView1[j, i];

                    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;

                }

            }



            xlWorkBook.SaveAs("New.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();



            ReleaseObject(xlWorkSheet);

            ReleaseObject(xlWorkBook);

            ReleaseObject(xlApp);



            MessageBox.Show("Excel file created , you can find the file c:\\new.xls");

        }



        private void ReleaseObject(object obj)

        {

            try

            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;

            }

            catch (Exception ex)

            {

                obj = null;

                MessageBox.Show("Exception Occured " + ex.ToString());

            }

            finally

            {

                GC.Collect();

            }


        }

        private void ValidationForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fypDBDataSet.POItems' table. You can move, or remove it, as needed.
            this.pOItemsTableAdapter.Fill(this.fypDBDataSet.POItems);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "DO";
                oSheet.Cells[1, 2] = "PO";
                oSheet.Cells[1, 3] = "Product";
                oSheet.Cells[1, 4] = "Quantity";
                oSheet.Cells[1, 5] = "Unit Price";
                oSheet.Cells[2, 1] = "DO1";
                oSheet.Cells[2, 2] = "PO1";
                oSheet.Cells[2, 3] = "Capasitor";
                oSheet.Cells[2, 4] = "500";
                oSheet.Cells[2, 5] = "5";
                oSheet.Cells[3, 1] = "DO2";
                oSheet.Cells[3, 2] = "PO2";
                oSheet.Cells[3, 3] = "Transitor";
                oSheet.Cells[3, 4] = "300";
                oSheet.Cells[3, 5] = "10";



                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "F1").Font.Bold = true;
                oSheet.get_Range("A1", "F1").VerticalAlignment =
                Excel.XlVAlign.xlVAlignCenter;



                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                oRng = oSheet.get_Range("E2", "E3");
                oRng.NumberFormat = "$0.00";


                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "F1");
                oRng.EntireColumn.AutoFit();
            }
            catch (Exception ex){
            }
    }
    }
}
