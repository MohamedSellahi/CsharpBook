using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoLotConnectedLayer;

namespace WebApp00 {
   public partial class Default : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {

      }

      protected void btnFillData_Click(object sender, EventArgs e) {
         InventoryDAL dal = new InventoryDAL();
         dal.OpenConnection(@"Data Source=(local)\SQLEXPRESS;" +
            "Initial Catalog=AutoLot;Integrated Security=True");
         CarGridView.DataSource = dal.GetAllInventoryAsList();
         CarGridView.DataBind();
         dal.CloseConnection();
      }
   }
}