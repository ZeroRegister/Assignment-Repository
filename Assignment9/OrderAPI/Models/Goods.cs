﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI {
  public class Goods {
    public string Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Goods() {
      //Id = Guid.NewGuid().ToString();
    }

    public Goods(string name, double price,string id):this() {
      Name = name;
      Price = price;
      Id = id;
    }

    public override bool Equals(object obj) {
      var goods = obj as Goods;
      return goods != null &&
             Id == goods.Id &&
             Name == goods.Name;
    }

    public override int GetHashCode() {
      var hashCode = 1479869798;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      return hashCode;
    }
  }


}
