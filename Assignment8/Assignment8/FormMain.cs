
using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm {
  public partial class FormMain : Form {
    OrderService orderService;
    BindingSource bdsFields = new BindingSource();
    public event Action<FormEdit>  ShowEditForm;
    public String Keyword { get; set; }

    public FormMain() {
      InitializeComponent();
      orderService = new OrderService();
      bdsOrders.DataSource = orderService.Orders;
      cbxField.SelectedIndex = 0;
      txtKeyword.DataBindings.Add("Text", this, "Keyword");
    }

    private void btnAdd_Click(object sender, EventArgs e) {
      FormEdit formEdit = new FormEdit(new Order(),false,orderService);
      ShowEditForm(formEdit);
    }

    public void QueryAll() {
      bdsOrders.DataSource = orderService.Orders;
      bdsOrders.ResetBindings(false);
    }

    private void btnModify_Click(object sender, EventArgs e) {
      EditOrder();
    }
    private void dbvOrders_DoubleClick(object sender, EventArgs e) {
      EditOrder();
    }
    private void EditOrder() {
      Order order = bdsOrders.Current as Order;
      if (order == null) {
        MessageBox.Show("请选择一个订单进行修改");
        return;
      }
      FormEdit form2 = new FormEdit(order, true,orderService);
      ShowEditForm(form2);
    }

    private void btnDelete_Click(object sender, EventArgs e) {
      Order order = bdsOrders.Current as Order;
      if (order == null) {
        MessageBox.Show("请选择一个订单进行删除");
        return;
      }
      orderService.RemoveOrder(order.OrderId);
      QueryAll();
    }

    private void btnExport_Click(object sender, EventArgs e) {
      DialogResult result = saveFileDialog1.ShowDialog();
      if (result.Equals(DialogResult.OK)) {
        String fileName = saveFileDialog1.FileName;
        orderService.Export(fileName);
      }
    }

    private void btnImport_Click(object sender, EventArgs e) {
      DialogResult result = openFileDialog1.ShowDialog();
      if (result.Equals(DialogResult.OK)) {
        String fileName = openFileDialog1.FileName;
        orderService.Import(fileName);
        QueryAll();
      }
    }

    private void btnQuery_Click(object sender, EventArgs e) {
      switch (cbxField.SelectedIndex) {
        case 0://所有订单
          bdsOrders.DataSource =orderService.Orders;
          break;
        case 1://根据ID查询
          Order order = orderService.GetOrder(Keyword);
          List<Order> result = new List<Order>();
          if (order != null) result.Add(order);
          bdsOrders.DataSource = result;
          break;
        case 2://根据客户查询
          bdsOrders.DataSource =orderService.QueryOrdersByCustomerName(Keyword);
          break;
        case 3://根据货物查询
          bdsOrders.DataSource =orderService.QueryOrdersByGoodsName(Keyword);
          break;
        case 4://根据总价格查询（大于某个总价）
          float.TryParse(Keyword,  out float totalPrice);
          bdsOrders.DataSource =
                 orderService.QueryByTotalAmount(totalPrice);
          break;
      }
      bdsOrders.ResetBindings(false);

    }

  }
}
