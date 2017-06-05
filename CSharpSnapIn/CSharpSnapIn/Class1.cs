using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using CommenSnapableTypes;



namespace CSharpSnapIn {
  [CompanyInfo(CompanyName = "My Company", CompanyUrl = "www.Mycompany.com")]
  public class CsharpModule : IAppFunctionality {
    void IAppFunctionality.Doit() {
      MessageBox.Show("You have just used the C# plugin");
    }
  }

}
