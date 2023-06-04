using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm {
  public partial class FormEdit : Form {
    private OrderService orderService;
    public bool EditModel { get; set; }

    public Order CurrentOrder { get; set; }
    public event Action<FormEdit> CloseEditFrom;

    public FormEdit(Order order, bool model, OrderService orderService) {
      InitializeComponent();
      using (OrderContext ctx =new OrderContext()) {
        bdsCustomers.DataSource= ctx.Customers.ToList(); 
      }
      this.orderService = orderService;
      this.EditModel = model;

      this.CurrentOrder = order;
      bdsOrders.DataSource = CurrentOrder;
      
      txtOrderId.Enabled = !model;
      if (!model) {
        CurrentOrder.Customer = (Customer)bdsCustomers.Current;
      }
    }

    private void btnAddItem_Click(object sender, EventArgs e) {
      FormDetailEdit formItemEdit = new FormDetailEdit(new OrderDetail());
      try {
        if (formItemEdit.ShowDialog() == DialogResult.OK) {
          int index = 0;
          if (CurrentOrder.Details.Count != 0) {
            index = CurrentOrder.Details.Max(i => i.Index) + 1;
          }
          formItemEdit.Detail.Index = index;
          CurrentOrder.AddItem(formItemEdit.Detail);
          bdsDetails.ResetBindings(false);
        }
      }catch (Exception e2) {
        MessageBox.Show(e2.Message);
      }
    }

    private void btnSave_Click(object sender, EventArgs e) {
      //TODO 加上订单合法性验证
      try {
        if (this.EditModel) {
          orderService.UpdateOrder(CurrentOrder);
        }else {
          orderService.AddOrder(CurrentOrder);
        }
        CloseEditFrom(this);
      }catch (Exception e3) {
        MessageBox.Show(e3.InnerException.Message);
      }

    }

    private void btnEditItem_Click(object sender, EventArgs e) {
      EditDetail();
    }

    private void dgvItems_DoubleClick(object sender, EventArgs e) {
      EditDetail();
    }

    private void EditDetail() {
      OrderDetail detail = bdsDetails.Current as OrderDetail;
      if (detail == null) {
        MessageBox.Show("请选择一个订单项进行修改");
        return;
      }
      FormDetailEdit formDetailEdit = new FormDetailEdit(detail);
      if (formDetailEdit.ShowDialog() == DialogResult.OK) {
        bdsDetails.ResetBindings(false);
      }
    }

    private void btnDeleteItem_Click(object sender, EventArgs e) {
      OrderDetail detail = bdsDetails.Current as OrderDetail;
      if (detail == null) {
        MessageBox.Show("请选择一个订单项进行删除");
        return;
      }
      CurrentOrder.RemoveDetail(detail);
      bdsDetails.ResetBindings(false);
    }

    
  }
}
