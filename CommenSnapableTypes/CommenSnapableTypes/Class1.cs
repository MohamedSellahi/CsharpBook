using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommenSnapableTypes {
  // this is a polymorphic interace that has to be implemented by any snap-in
  // dll in orther to be used from my extensible application

  public interface IAppFunctionality {
    void Doit();
  }

  [AttributeUsage(AttributeTargets.Class)]
  public sealed class CompanyInfoAttribute: System.Attribute {
    public string CompanyName { get; set; }
    public string CompanyUrl { get; set; }
  }
}
