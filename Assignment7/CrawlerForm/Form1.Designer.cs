
namespace CrawlerForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lburl = new System.Windows.Forms.Label();
            this.tburl = new System.Windows.Forms.TextBox();
            this.lbhost = new System.Windows.Forms.Label();
            this.tbhost = new System.Windows.Forms.TextBox();
            this.lbfile = new System.Windows.Forms.Label();
            this.lbnum = new System.Windows.Forms.Label();
            this.tbnum = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnstart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvresult = new System.Windows.Forms.DataGridView();
            this.Res = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlbindingsource = new System.Windows.Forms.BindingSource(this.components);
            this.tbfile = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvresult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlbindingsource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lburl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tburl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbhost, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbhost, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbfile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbnum, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbnum, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbfile, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1463, 309);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lburl
            // 
            this.lburl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lburl.AutoSize = true;
            this.lburl.Location = new System.Drawing.Point(88, 65);
            this.lburl.Name = "lburl";
            this.lburl.Size = new System.Drawing.Size(274, 24);
            this.lburl.TabIndex = 0;
            this.lburl.Text = "请输入需要爬取的网址：";
            // 
            // tburl
            // 
            this.tburl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tburl.Location = new System.Drawing.Point(368, 59);
            this.tburl.Name = "tburl";
            this.tburl.Size = new System.Drawing.Size(271, 35);
            this.tburl.TabIndex = 1;
            // 
            // lbhost
            // 
            this.lbhost.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbhost.AutoSize = true;
            this.lbhost.Location = new System.Drawing.Point(938, 65);
            this.lbhost.Name = "lbhost";
            this.lbhost.Size = new System.Drawing.Size(154, 24);
            this.lbhost.TabIndex = 2;
            this.lbhost.Text = "请指定host：";
            // 
            // tbhost
            // 
            this.tbhost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbhost.Location = new System.Drawing.Point(1098, 59);
            this.tbhost.Name = "tbhost";
            this.tbhost.Size = new System.Drawing.Size(273, 35);
            this.tbhost.TabIndex = 3;
            // 
            // lbfile
            // 
            this.lbfile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbfile.AutoSize = true;
            this.lbfile.Location = new System.Drawing.Point(208, 219);
            this.lbfile.Name = "lbfile";
            this.lbfile.Size = new System.Drawing.Size(154, 24);
            this.lbfile.TabIndex = 4;
            this.lbfile.Text = "请指定file：";
            // 
            // lbnum
            // 
            this.lbnum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbnum.AutoSize = true;
            this.lbnum.Location = new System.Drawing.Point(890, 219);
            this.lbnum.Name = "lbnum";
            this.lbnum.Size = new System.Drawing.Size(202, 24);
            this.lbnum.TabIndex = 6;
            this.lbnum.Text = "请输入爬取数量：";
            // 
            // tbnum
            // 
            this.tbnum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbnum.Location = new System.Drawing.Point(1098, 214);
            this.tbnum.Name = "tbnum";
            this.tbnum.Size = new System.Drawing.Size(273, 35);
            this.tbnum.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnstart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 802);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1463, 100);
            this.panel1.TabIndex = 1;
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(475, 31);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(146, 57);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "运行程序";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvresult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 309);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1463, 493);
            this.panel2.TabIndex = 2;
            // 
            // dgvresult
            // 
            this.dgvresult.AutoGenerateColumns = false;
            this.dgvresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvresult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startUrlDataGridViewTextBoxColumn,
            this.resultUrlDataGridViewTextBoxColumn,
            this.Res});
            this.dgvresult.DataSource = this.urlbindingsource;
            this.dgvresult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvresult.Location = new System.Drawing.Point(0, 0);
            this.dgvresult.Name = "dgvresult";
            this.dgvresult.RowHeadersWidth = 82;
            this.dgvresult.RowTemplate.Height = 37;
            this.dgvresult.Size = new System.Drawing.Size(1463, 493);
            this.dgvresult.TabIndex = 0;
            // 
            // Res
            // 
            this.Res.DataPropertyName = "Res";
            this.Res.HeaderText = "是否成功";
            this.Res.MinimumWidth = 10;
            this.Res.Name = "Res";
            this.Res.Width = 200;
            // 
            // startUrlDataGridViewTextBoxColumn
            // 
            this.startUrlDataGridViewTextBoxColumn.DataPropertyName = "StartUrl";
            this.startUrlDataGridViewTextBoxColumn.HeaderText = "StartUrl";
            this.startUrlDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.startUrlDataGridViewTextBoxColumn.Name = "startUrlDataGridViewTextBoxColumn";
            this.startUrlDataGridViewTextBoxColumn.Width = 400;
            // 
            // resultUrlDataGridViewTextBoxColumn
            // 
            this.resultUrlDataGridViewTextBoxColumn.DataPropertyName = "ResultUrl";
            this.resultUrlDataGridViewTextBoxColumn.HeaderText = "ResultUrl";
            this.resultUrlDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.resultUrlDataGridViewTextBoxColumn.Name = "resultUrlDataGridViewTextBoxColumn";
            this.resultUrlDataGridViewTextBoxColumn.Width = 400;
            // 
            // urlbindingsource
            // 
            this.urlbindingsource.DataSource = typeof(CrawlerForm.Result);
            // 
            // tbfile
            // 
            this.tbfile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbfile.Location = new System.Drawing.Point(368, 214);
            this.tbfile.Name = "tbfile";
            this.tbfile.Size = new System.Drawing.Size(271, 35);
            this.tbfile.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 902);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvresult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlbindingsource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lburl;
        private System.Windows.Forms.TextBox tburl;
        private System.Windows.Forms.Label lbhost;
        private System.Windows.Forms.TextBox tbhost;
        private System.Windows.Forms.Label lbfile;
        private System.Windows.Forms.BindingSource urlbindingsource;
        private System.Windows.Forms.Label lbnum;
        private System.Windows.Forms.TextBox tbnum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn startUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Res;
        private System.Windows.Forms.TextBox tbfile;
    }
}

