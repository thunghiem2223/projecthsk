using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectthi
{
    public partial class fSearch : Form
    {
        private DataTable dataTable; // Biến lưu DataTable ban đầu
        private string ma;
        private ISearch isearch;
        public fSearch(string ma, ISearch isearch)
        {
            InitializeComponent();
            this.ma = ma;
            this.isearch = isearch;
            LoadData();
        }

        private void LoadData()
        {
            // Tải dữ liệu từ cơ sở dữ liệu và lưu vào DataTable
            dataTable = DataProvider.Instance.ExecuteQuery("select * from tblsach");
            dtgv1.DataSource = dataTable;
        }

        private void dtgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được chọn là hàng đầu tiên
            if (e.RowIndex > 0) // e.RowIndex là chỉ số của hàng được chọn
            {
                // Lấy DataRow của hàng được chọn
                DataGridViewRow row = dtgv1.Rows[e.RowIndex];
                DataRowView dataRowView = row.DataBoundItem as DataRowView;

                if (dataRowView != null)
                {
                    DataRow dataRow = dataRowView.Row;

                    isearch.getRow(dataRow);
                    this.Close();
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tukhoa = tbTim.Text.Trim();

            if (string.IsNullOrEmpty(tukhoa))
            {
                dtgv1.DataSource = dataTable; // Hiển thị lại toàn bộ dữ liệu nếu từ khóa rỗng
            }
            else
            {
                DataView dv = new DataView(dataTable);
                //dv.RowFilter = string.Format("sMaSach LIKE '%{0}%' OR sTenSach LIKE '%{0}%' OR sTacGia LIKE '%{0}%' OR sMaTL LIKE '%{0}%' OR sMaNXB LIKE '%{0}%' OR Convert(iSL, 'System.String') LIKE '%{0}%'", tukhoa);
                dtgv1.DataSource = dv;
            }
        }
    }
}
