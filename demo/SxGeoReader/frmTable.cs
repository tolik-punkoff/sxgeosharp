using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SxGeoReader
{
    public partial class frmTable : Form
    {
        public string TableName = "";
        public DataSet dsTable = null;
        public int RecordsCount = 0;
        int iCurrCol = -1;
        public frmTable()
        {
            InitializeComponent();
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + TableName+" [" +RecordsCount.ToString()+ "]";
        }

        private void frmTable_Shown(object sender, EventArgs e)
        {
            grdTable.DataSource=dsTable.Tables[TableName].DefaultView;
        }

        private void grdTable_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((grdTable.CurrentCell != null))
            {
                lblSearchIn.Text = "Поиск по столбцу [" + grdTable.Columns[grdTable.CurrentCell.ColumnIndex].HeaderText + "]:";
                iCurrCol = grdTable.CurrentCell.ColumnIndex;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //поиск по любому полю в таблице (вниз)
            for (int i = grdTable.CurrentCell.RowIndex + 1; i < grdTable.RowCount; i++)
            {
                grdTable.Rows[i].Selected = false;
                if (grdTable.Rows[i].Cells[iCurrCol].Value != null)
                    if (grdTable.Rows[i].Cells[iCurrCol].Value.ToString().StartsWith(txtFind.Text, true, null))
                    {
                        grdTable.CurrentCell = grdTable.Rows[i].Cells[iCurrCol];
                        grdTable.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            for (int i = grdTable.CurrentCell.RowIndex - 1; i >= 0; i--)
            {
                grdTable.Rows[i].Selected = false;
                if (grdTable.Rows[i].Cells[iCurrCol].Value != null)
                    if (grdTable.Rows[i].Cells[iCurrCol].Value.ToString().StartsWith(txtFind.Text, true, null))
                    {
                        grdTable.CurrentCell = grdTable.Rows[i].Cells[iCurrCol];
                        grdTable.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
            }
        }
    }
}
