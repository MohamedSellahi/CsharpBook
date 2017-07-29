using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MultiTabledDataSet {
   public partial class MainForm : Form {
      // Form wide DataSet.
      private DataSet autoLotDS = new DataSet("AutoLot");

      // Maje use of command builders to simplify data adapter configuration 
      private SqlCommandBuilder sqlCBInvetory;
      private SqlCommandBuilder sqlCBCustomer;
      private SqlCommandBuilder sqlCBOrder;

      // the data adapters 
      private SqlDataAdapter invTableAdapter;
      private SqlDataAdapter custTableAdapter;
      private SqlDataAdapter orderTableAdapter;

      // Form wide string
      private string cnStr = string.Empty;

      public MainForm() {
         InitializeComponent();

         // Get connection string from .config file 
         cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

         // Create adapter
         invTableAdapter = new SqlDataAdapter("Select * From Inventory", cnStr);
         custTableAdapter = new SqlDataAdapter("Select * From Customer", cnStr);
         orderTableAdapter = new SqlDataAdapter("SELECT [OrderID],[CustID],[CarID] FROM [dbo].[Order]", cnStr);

         // Auto generate commands 
         sqlCBInvetory = new SqlCommandBuilder(invTableAdapter);
         sqlCBCustomer = new SqlCommandBuilder(custTableAdapter);
         sqlCBOrder = new SqlCommandBuilder(orderTableAdapter);

         // Fill tables in dataset 
         invTableAdapter.Fill(autoLotDS, "Inventory");
         custTableAdapter.Fill(autoLotDS, "Customer");
         orderTableAdapter.Fill(autoLotDS, "Order");

         // Build table relation between tables
         BuildTableRelation();

         // Bind the grids 
         dataGridInventory.DataSource = autoLotDS.Tables["Inventory"];
         dataGridCustomers.DataSource = autoLotDS.Tables["Customer"];
         dataGridOrders.DataSource = autoLotDS.Tables["Order"];



      }

      private void BuildTableRelation() {
         // Create Custoer data relation object 
         DataRelation dr = new DataRelation("CustomerOrder",
            autoLotDS.Tables["Customer"].Columns["CustID"],
            autoLotDS.Tables["Order"].Columns["CustID"]); // foreign key constraint 

         autoLotDS.Relations.Add(dr);

         dr = new DataRelation("InventoryOrder",
            autoLotDS.Tables["Inventory"].Columns["CarID"],
            autoLotDS.Tables["Order"].Columns["CarID"]);

         autoLotDS.Relations.Add(dr);
      }

      private void btnUpdate_Click(object sender, EventArgs e) {
         try {
            invTableAdapter.Update(autoLotDS, "Inventory");
            custTableAdapter.Update(autoLotDS, "Customer");
            orderTableAdapter.Update(autoLotDS, "Order");
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void btnOrderDetails_Click(object sender, EventArgs e) {
         string strOrderInfo = string.Empty;
         DataRow[] drsCust = null;
         DataRow[] drsOrder = null;

         // Get the customer ID in the text box 
         int custID = int.Parse(this.txtCustID.Text);

         // Now based on the custId, get the correct row in the customers table; 
         drsCust = autoLotDS.Tables["Customer"].Select(string.Format("CustID = {0}", custID));
         strOrderInfo += string.Format("Customer {0}: {1} {2}\n",
         drsCust[0]["CustID"].ToString(),
         drsCust[0]["FirstName"].ToString(),
         drsCust[0]["LastName"].ToString());

         // Navigate fom customer table to orders table 
         drsOrder = drsCust[0].GetChildRows(autoLotDS.Relations["CustomerOrder"]);

         // Loop through all orders for thsi customer
         foreach (DataRow order in drsOrder) {
            strOrderInfo += string.Format("----\nOrder Number:" +
               "{0}\n", order["OrderID"]);

            // get the car referenced by this order 
            DataRow[] drsInv = order.GetParentRows(autoLotDS.Relations["InventoryOrder"]);
            // Get info for (SINGLE) car info for this order.
            DataRow car = drsInv[0];
            strOrderInfo += string.Format("Maker: {0}\n", car["Maker"]);
            strOrderInfo += string.Format("Color: {0}\n", car["Color"]);
            strOrderInfo += string.Format("Pet Name: {0}\n", car["PetName"]);
         }

         MessageBox.Show(strOrderInfo, "Order Details");
      }
   }
}
