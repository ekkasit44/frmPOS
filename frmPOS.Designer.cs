namespace MinimartMIS
{
    partial class frmPOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtEmpID = new TextBox();
            label2 = new Label();
            txtEmpName = new TextBox();
            label3 = new Label();
            lblNetPrice = new Label();
            groupBox1 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            lsvProducts = new ListView();
            txtTotal = new TextBox();
            txtQuantity = new TextBox();
            txtUnitPrice = new TextBox();
            txtProductName = new TextBox();
            txtProductID = new TextBox();
            btnAdd = new Button();
            btnClear = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "รหัสพนักงาน";
            // 
            // txtEmpID
            // 
            txtEmpID.Location = new Point(92, 23);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.Size = new Size(100, 23);
            txtEmpID.TabIndex = 1;
            txtEmpID.KeyDown += txtEmpID_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 26);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 2;
            label2.Text = "ชื่อ-สกุล";
            // 
            // txtEmpName
            // 
            txtEmpName.Location = new Point(277, 23);
            txtEmpName.Name = "txtEmpName";
            txtEmpName.ReadOnly = true;
            txtEmpName.Size = new Size(192, 23);
            txtEmpName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(526, 23);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "รวมเป็น";
            // 
            // lblNetPrice
            // 
            lblNetPrice.BackColor = Color.FromArgb(192, 255, 255);
            lblNetPrice.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNetPrice.Location = new Point(583, 23);
            lblNetPrice.Name = "lblNetPrice";
            lblNetPrice.Size = new Size(188, 42);
            lblNetPrice.TabIndex = 5;
            lblNetPrice.Text = "0000";
            lblNetPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(255, 255, 192);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lsvProducts);
            groupBox1.Controls.Add(txtTotal);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(txtProductID);
            groupBox1.Location = new Point(22, 85);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(545, 364);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "รายการสั่งซื้อ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(467, 26);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 16;
            label9.Text = "รวมเป็นเงิน";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(382, 26);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 15;
            label8.Text = "จำนวน";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(310, 26);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 14;
            label7.Text = "ราคาขาย";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(184, 26);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 13;
            label6.Text = "ชื่อสินค้า";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 26);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 11;
            label5.Text = "รหัสสินค้า";
            // 
            // lsvProducts
            // 
            lsvProducts.Location = new Point(6, 93);
            lsvProducts.Name = "lsvProducts";
            lsvProducts.Size = new Size(533, 265);
            lsvProducts.TabIndex = 12;
            lsvProducts.UseCompatibleStateImageBehavior = false;
            lsvProducts.DoubleClick += lsvProducts_DoubleClick;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(447, 44);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(92, 23);
            txtTotal.TabIndex = 11;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(378, 44);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(54, 23);
            txtQuantity.TabIndex = 10;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            txtQuantity.KeyDown += txtQuantity_KeyDown;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(300, 44);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(72, 23);
            txtUnitPrice.TabIndex = 9;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(113, 44);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(181, 23);
            txtProductName.TabIndex = 8;
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(6, 44);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(101, 23);
            txtProductID.TabIndex = 7;
            txtProductID.KeyDown += txtProductID_KeyDown;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(192, 255, 192);
            btnAdd.Location = new Point(609, 113);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(77, 39);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "เพิ่มรายการ";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 255, 192);
            btnClear.Location = new Point(609, 178);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(77, 39);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 255, 192);
            btnSave.Enabled = false;
            btnSave.Location = new Point(609, 301);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(134, 39);
            btnSave.TabIndex = 9;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Location = new Point(609, 387);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(134, 39);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "ยกเลิกรายการทั้งหมด";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmPOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(800, 469);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(lblNetPrice);
            Controls.Add(label3);
            Controls.Add(txtEmpName);
            Controls.Add(label2);
            Controls.Add(txtEmpID);
            Controls.Add(label1);
            Name = "frmPOS";
            Text = "frmPOS";
            Load += frmPOS_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEmpID;
        private Label label2;
        private TextBox txtEmpName;
        private Label label3;
        private Label lblNetPrice;
        private GroupBox groupBox1;
        private TextBox txtTotal;
        private TextBox txtQuantity;
        private TextBox txtUnitPrice;
        private TextBox txtProductName;
        private TextBox txtProductID;
        private ListView lsvProducts;
        private Button btnAdd;
        private Button btnClear;
        private Button btnSave;
        private Button btnCancel;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
    }
}