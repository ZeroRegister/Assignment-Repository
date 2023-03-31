using System;

namespace OrderApp {

  public class Customer {

    public int Id { get; set; }

    public string Name { get; set; }

    public Customer() { }

    public Customer(int id, string name) {
      this.Id = id;
      this.Name = name;
    }

    public override string ToString() {
      return $"customerId:{Id}, CustomerName:{Name}";
    }

    public override bool Equals(object obj) {
      var customer = obj as Customer;
      return customer != null && Id == customer.Id;
    }

    public override int GetHashCode() {
      return 2108858624 + Id.GetHashCode();
    }


  }
}