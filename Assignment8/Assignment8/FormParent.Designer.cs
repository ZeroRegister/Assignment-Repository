namespace OrderForm {
  partial class FormParent {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.contentPanel = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.orderMainLink = new System.Windows.Forms.LinkLabel();
      this.seperatorLabel = new System.Windows.Forms.Label();
      this.orderEditLink = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contentPanel
      // 
      this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.contentPanel.Location = new System.Drawing.Point(0, 34);
      this.contentPanel.Name = "contentPanel";
      this.contentPanel.Size = new System.Drawing.Size(800, 416);
      this.contentPanel.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.contentPanel);
      this.panel1.Controls.Add(this.flowLayoutPanel1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 450);
      this.panel1.TabIndex = 2;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
      this.flowLayoutPanel1.Controls.Add(this.orderMainLink);
      this.flowLayoutPanel1.Controls.Add(this.seperatorLabel);
      this.flowLayoutPanel1.Controls.Add(this.orderEditLink);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
      this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 34);
      this.flowLayoutPanel1.TabIndex = 0;
      // 
      // orderMainLink
      // 
      this.orderMainLink.AutoSize = true;
      this.orderMainLink.Enabled = false;
      this.orderMainLink.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.orderMainLink.Location = new System.Drawing.Point(10, 10);
      this.orderMainLink.Margin = new System.Windows.Forms.Padding(0);
      this.orderMainLink.Name = "orderMainLink";
      this.orderMainLink.Size = new System.Drawing.Size(56, 17);
      this.orderMainLink.TabIndex = 0;
      this.orderMainLink.TabStop = true;
      this.orderMainLink.Text = "订单管理";
      this.orderMainLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.orderMainLink_LinkClicked_1);
      // 
      // seperatorLabel
      // 
      this.seperatorLabel.AutoSize = true;
      this.seperatorLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.seperatorLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
      this.seperatorLabel.Location = new System.Drawing.Point(66, 10);
      this.seperatorLabel.Margin = new System.Windows.Forms.Padding(0);
      this.seperatorLabel.Name = "seperatorLabel";
      this.seperatorLabel.Size = new System.Drawing.Size(12, 17);
      this.seperatorLabel.TabIndex = 2;
      this.seperatorLabel.Text = "|";
      this.seperatorLabel.Visible = false;
      // 
      // orderEditLink
      // 
      this.orderEditLink.AutoSize = true;
      this.orderEditLink.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.orderEditLink.Location = new System.Drawing.Point(78, 10);
      this.orderEditLink.Margin = new System.Windows.Forms.Padding(0);
      this.orderEditLink.Name = "orderEditLink";
      this.orderEditLink.Size = new System.Drawing.Size(56, 17);
      this.orderEditLink.TabIndex = 3;
      this.orderEditLink.Text = "添加订单";
      this.orderEditLink.Visible = false;
      // 
      // FormParent
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.panel1);
      this.Name = "FormParent";
      this.Text = "FormParent";
      this.Load += new System.EventHandler(this.FormParent_Load);
      this.panel1.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel contentPanel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.LinkLabel orderMainLink;
    private System.Windows.Forms.Label seperatorLabel;
    private System.Windows.Forms.Label orderEditLink;
  }
}