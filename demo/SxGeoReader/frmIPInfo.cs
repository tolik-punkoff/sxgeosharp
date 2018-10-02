using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SxGeoReader
{
    public partial class frmIPInfo : Form
    {
        public Dictionary<string, object> data = null;
        public frmIPInfo()
        {
            InitializeComponent();
        }

        private void frmIPInfo_Load(object sender, EventArgs e)
        {
            grdInfo.Columns.Add("Parameter", "Parameter");
            grdInfo.Columns.Add("Data", "Data");
            foreach (string Key in data.Keys)
            {
                grdInfo.Rows.Add(Key.ToUpperInvariant(), data[Key]);
            }
            string st = (string)data["status"];
            st = st.Split(':')[0];
            if (st == "ERROR")
            {
                grdInfo.Rows[grdInfo.Rows.Count - 1].Cells[1].Style.ForeColor 
                    = Color.Red;
            }
            if (st == "WARNING")
            {
                grdInfo.Rows[grdInfo.Rows.Count - 1].Cells[1].Style.ForeColor
                    = Color.Yellow;
                grdInfo.Rows[grdInfo.Rows.Count - 1].Cells[1].Style.BackColor
                    = Color.Black;
            }
            if (st == "OK")
            {
                grdInfo.Rows[grdInfo.Rows.Count - 1].Cells[1].Style.ForeColor
                    = Color.Green;             
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
