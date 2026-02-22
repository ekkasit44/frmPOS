using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinimartMIS
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int empID { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string empName { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string position { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string username { get; set; }

        SqlConnection conn;
        SqlTransaction tr;
        private int unitsInStock = 0; //เก็บจำนวน stock ของสินค้า
        private void frmPOS_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart(); //เรียกใช้ฟังก์ชันเชื่อมต่อฐานข้อมูล
            ListViewFormat();
            ClearProductData();
            txtEmpID.Text = this.empID.ToString();
            txtEmpName.Text = this.empName;
        }
        private void ClearProductData() //เคลียร์ข ้อมูลใน Textbox รายการสนิ คา้
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtUnitPrice.Text = "0";
            txtQuantity.Text = "1";
            txtTotal.Text = "0";
        }
        private void ListViewFormat() //ส าหรับจัดรูปแบบ ListView
        {
            lsvProducts.Columns.Add("รหัสสินค้า", 120, HorizontalAlignment.Left);
            lsvProducts.Columns.Add("สินค้า", 170, HorizontalAlignment.Left);
            lsvProducts.Columns.Add("ราคา", 120, HorizontalAlignment.Right);
            lsvProducts.Columns.Add("จำนวน", 75, HorizontalAlignment.Right);
            lsvProducts.Columns.Add("รวมเป็นเงิน", 100, HorizontalAlignment.Right);
            lsvProducts.View = View.Details;
            lsvProducts.GridLines = true;
            lsvProducts.FullRowSelect = true;
        }
        private void ClearEmployeeData() //เคลยี รช์ อื่ และรหัสพนักงาน
        {
            txtEmpID.Text = "";
            txtEmpName.Text = "";
        }
        private void CalculateTotal() //เอาไว้ค านวณราคารวมของแต่ละรายการ
        {
            double total = Convert.ToDouble(txtUnitPrice.Text) * Convert.ToDouble(txtQuantity.Text);
            txtTotal.Text = total.ToString("#,##0.00");
            txtProductID.Focus();
            txtProductID.SelectAll();
        }
        private void CalculateNetPrice() //เอาไว้ค านวณราคารวมทั้งหมด
        {
            double tmpNetPeice = 0.0;
            for (int i = 0; i <= lsvProducts.Items.Count - 1; i++)
            {
                tmpNetPeice += Convert.ToDouble(lsvProducts.Items[i].SubItems[4].Text);
            }
            lblNetPrice.Text = tmpNetPeice.ToString("#,##0.00");
        }

        private void txtEmpID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                conn = connectDB.ConnectMinimart();
                string sql = "Select EmployeeID, Title+FirstName+space(2)+LastName EmpName, Position"
                + " from Employees"
                + " Where EmployeeID = @EmployeeID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@EmployeeID", txtEmpID.Text);
                // เช็คการเชื่อมต่อฐานข้อมูลก่อนเปิดการเชื่อมต่อ
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtEmpID.Text = dt.Rows[0][0].ToString();
                    txtEmpName.Text = dt.Rows[0][1].ToString();
                    txtProductID.Focus();
                }
                else
                {
                    ClearEmployeeData();
                    txtEmpID.Focus();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "Select ProductID, ProductName,UnitPrice,UnitsInStock"
                + " from Products where productID = @ProductID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtProductID.Text = dt.Rows[0][0].ToString();
                    txtProductName.Text = dt.Rows[0][1].ToString();
                    txtUnitPrice.Text = dt.Rows[0][2].ToString();
                    unitsInStock = Convert.ToInt32(dt.Rows[0][3]); //เก็บจำนวน stock
                    CalculateTotal();
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                }
                else
                {
                    MessageBox.Show("ไม่พบสินค้ารหัสนี้", "ผิดพลาด");
                    ClearProductData();
                    txtProductID.Focus();

                    txtProductID.SelectAll();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == "") txtQuantity.Text = "1";
            if (Convert.ToInt16(txtQuantity.Text) == 0) txtQuantity.Text = "1";
            CalculateTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Trim() == "" || txtProductName.Text.Trim() == "")
            {
                txtProductID.Focus();
                txtProductID.SelectAll();
                return;
            }
            if (Convert.ToInt16(txtQuantity.Text) == 0)
            {
                txtProductID.Focus();
                txtProductID.SelectAll();
                return;
            }
            //ตรวจสอบ stock ว่าเพียงพอหรือไม่
            if (Convert.ToInt16(txtQuantity.Text) > unitsInStock)
            {
                MessageBox.Show("จำนวนสินค้าไม่เพียงพอ\nStock คงเหลือ: " + unitsInStock.ToString() + " หน่วย", "แจ้งเตือน");
                txtQuantity.Focus();
                txtQuantity.SelectAll();
                return;
            }
            ListViewItem lvi;
            string tmpProductID = "";
            for (int i = 0; i <= lsvProducts.Items.Count - 1; i++)
            {
                tmpProductID = lsvProducts.Items[i].SubItems[0].Text;
                if (txtProductID.Text == tmpProductID)
                {
                    int qty = Convert.ToInt16(lsvProducts.Items[i].SubItems[3].Text)
                    + Convert.ToInt16(txtQuantity.Text);
                    double newTotal = Convert.ToDouble(lsvProducts.Items[i].SubItems[4].Text)
                    + Convert.ToDouble(txtTotal.Text);
                    lsvProducts.Items[i].SubItems[3].Text = qty.ToString();
                    lsvProducts.Items[i].SubItems[4].Text = newTotal.ToString("#,##0.00");
                    ClearProductData();
                    CalculateTotal();
                    CalculateNetPrice();
                    return;
                }
            }
            string[] anyData;
            anyData = new string[] { txtProductID.Text , txtProductName.Text,txtUnitPrice.Text,
txtQuantity.Text , txtTotal.Text};
            lvi = new ListViewItem(anyData);
            lsvProducts.Items.Add(lvi);

            CalculateNetPrice(); ClearProductData(); btnSave.Enabled = true;
            txtProductID.Focus(); txtProductID.SelectAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการบันทึกรายการสินค้า?", "โปรดยืนยัน", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            int LastOrderID = 0; //เอาไว้เก็บรหัสที่เพิ่มล่าสุด
            if (lsvProducts.Items.Count > 0)
            {
                //ประกาศเริ่ม Transaction
                conn.Open();
                tr = conn.BeginTransaction();
                //เพิ่มข ้อมูล Receipt
                SqlCommand comm = new SqlCommand("InsertReceipts", conn, tr);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ReceiptDate", DateTime.Today);
                comm.Parameters.AddWithValue("@EmployeeID", txtEmpID.Text);
                comm.Parameters.AddWithValue("@TotalCash", lblNetPrice.Text);
                comm.ExecuteNonQuery();
                //อ่านข ้อมูล รหัสของ Receipt รายการล่าสุดไว้ในตัวแปร LastOrderID
                string sql = "Select top 1 ReceiptID from Receipts Order by ReceiptID desc";

                SqlCommand comm1 = new SqlCommand(sql, conn, tr);
                SqlDataReader dr = comm1.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    LastOrderID = dr.GetInt32(dr.GetOrdinal("ReceiptID"));
                }
                dr.Close();
                //เพมิ่ รายการสนิ คา้ใน Details โดยใชร้หัส LastOrderID และตัด stock
                string ls = "";
                for (int i = 0; i <= lsvProducts.Items.Count - 1; i++)
                {
                    SqlCommand comm3 = new SqlCommand("InsertDetails", conn, tr);
                    comm3.CommandType = CommandType.StoredProcedure;
                    comm3.Parameters.AddWithValue("@ReceiptID", LastOrderID);
                    comm3.Parameters.AddWithValue("@productID", lsvProducts.Items[i].SubItems[0].Text);
                    comm3.Parameters.AddWithValue("@UnitPrice", lsvProducts.Items[i].SubItems[2].Text);
                    comm3.Parameters.AddWithValue("@Quantity", lsvProducts.Items[i].SubItems[3].Text);
                    comm3.ExecuteNonQuery();

                    //ตัด stock จากตาราง Products
                    string updateStockSql = "UPDATE Products SET UnitsInStock = UnitsInStock - @Quantity WHERE productID = @ProductID";
                    SqlCommand commUpdateStock = new SqlCommand(updateStockSql, conn, tr);
                    commUpdateStock.Parameters.AddWithValue("@Quantity", Convert.ToInt32(lsvProducts.Items[i].SubItems[3].Text));
                    commUpdateStock.Parameters.AddWithValue("@ProductID", lsvProducts.Items[i].SubItems[0].Text);
                    commUpdateStock.ExecuteNonQuery();

                    ls += lsvProducts.Items[i].SubItems[0].Text + "--";
                    ls += lsvProducts.Items[i].SubItems[1].Text + "--";
                    ls += lsvProducts.Items[i].SubItems[2].Text + "--";
                    ls += lsvProducts.Items[i].SubItems[3].Text + "--";
                    ls += lsvProducts.Items[i].SubItems[4].Text + Environment.NewLine;
                }
                tr.Commit();
                conn.Close();
                string msg = "รหัสการขาย" + LastOrderID.ToString() + Environment.NewLine
                + ls
                + "ยอดรวม " + lblNetPrice.Text;
                MessageBox.Show("บันทึกรายการขายสินค้าเรียบร้อยแล้ว" + msg, "ผลการทำงาน");
            }
            btnCancel.PerformClick(); //ค าสงั่ นี้สงั่ ใหร้ะบบคลกิป่มุ btnCancel เพื่อเริ่มรายการใหม่
        }

        private void lsvProducts_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i <= lsvProducts.SelectedItems.Count - 1; i++)
            {
                ListViewItem lvi = lsvProducts.SelectedItems[i];
                lsvProducts.Items.Remove(lvi);
            }
            CalculateNetPrice();
            txtProductID.Focus();
            txtProductID.SelectAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lsvProducts.Clear();
            ClearProductData();
            ListViewFormat();
            lblNetPrice.Text = "0.00";
            txtProductID.Focus();
            txtProductID.SelectAll();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick(); //สงั่ กดป่มุ เพมิ่ ทันที
            }
        }
    }
}