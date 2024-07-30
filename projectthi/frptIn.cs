using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frptIn : Form
    {
        string ma;
        public frptIn(string ma)
        {
            InitializeComponent();
            this.ma = ma;
            rptIn r = new rptIn();
            //r.SetParameterValue("@MaHD", ma);
            crystalReportViewer1.ReportSource = r;
            //TextObject txtReportHeader;
            //string tennv = DataProvider.Instance.ExecuteScalar("exec getTenNVHD @ma", new object[] { ma }).ToString();
            //txtReportHeader = r.ReportDefinition.ReportObjects["Text2"] as TextObject;
            //txtReportHeader.Text = tennv;
            
        }
    }
}
