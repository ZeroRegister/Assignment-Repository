using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI {
  public class Customer {
    public string Id { get; set; }//数据库编程必须，作为主键 long 
    public string Name { get; set; }

    public Customer() {
      //Id = Guid.NewGuid().ToString();
    }

    public Customer(string name,string id) :this() {
      Name = name;
      Id = id;
    }

    public override bool Equals(object obj) {
      var customer = obj as Customer;
      return customer != null &&
             Id == customer.Id &&
             Name == customer.Name;
    }

    public override int GetHashCode() {
      var hashCode = 1479869798;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      return hashCode;
    }
  }
}
