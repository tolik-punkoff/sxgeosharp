using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SxGeoReader
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        SxGeoDB SxGeo = null;

        private void frmMain_Load(object sender, EventArgs e)
        {
            SxGeo = new SxGeoDB(b_cl.dbPath);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {            
            /*SxGeo.OpenDB();

            SxGeo.GetIPInfo("93.190.206.171",SxGeoInfoType.FullInfo);

            SxGeo.CloseDB();*/            
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            SxGeo.OpenDB();
            SxGeo.CloseDB();
            SxGeoHeader Header = SxGeo.GetHeader();
            if (Header.PackFormat == null) Header.PackFormat = string.Empty;

            frmInfo fInfo = new frmInfo();
            fInfo.Header = Header;
            fInfo.ShowDialog();

        }
        

        private void btnShowRegions_Click(object sender, EventArgs e)
        {
            DataSet dsRegions = new DataSet();
            SxGeo.OpenDB();
            //нет справочника регионов
            if (SxGeo.GetHeader().RegionSize == 0)
            {
                SxGeo.CloseDB();
                MessageBox.Show("No regions data!");
                return;

            }
            
            SxGToDataSet toDS = new SxGToDataSet(dsRegions, SxGeo);
            string RegionFormat = SxGeo.GetHeader().PackFormat.
                Split('\0')[1];

            toDS.CreateTable("Regions", RegionFormat, SxGeoDirType.Regions);
            if (!toDS.FillTable())
            {
                MessageBox.Show(toDS.ErrorMessage);
                return;
            }


            frmTable fTableRegion = new frmTable();
            fTableRegion.TableName = "Regions";
            fTableRegion.dsTable = dsRegions;
            fTableRegion.RecordsCount = toDS.RecordsCount;
            fTableRegion.ShowDialog();
            SxGeo.CloseDB();
        }

        private void BtnShowCountries_Click(object sender, EventArgs e)
        {
            DataSet dsCountries = new DataSet();
            SxGeo.OpenDB();
            //нет справочника стран
            if (SxGeo.GetHeader().CountrySize == 0)
            {
                SxGeo.CloseDB();
                MessageBox.Show("No countries data!");
                return;

            }

            SxGToDataSet toDS = new SxGToDataSet(dsCountries, SxGeo);
            string CountryFormat = SxGeo.GetHeader().PackFormat.
                Split('\0')[0];

            toDS.CreateTable("Countries", CountryFormat, SxGeoDirType.Countries);
            if (!toDS.FillTable())
            {
                MessageBox.Show(toDS.ErrorMessage);
                return;
            }


            frmTable fTableCountry = new frmTable();
            fTableCountry.TableName = "Countries";
            fTableCountry.dsTable = dsCountries;
            fTableCountry.RecordsCount = toDS.RecordsCount;
            fTableCountry.ShowDialog();
            SxGeo.CloseDB();
        }

        private void btnShowCites_Click(object sender, EventArgs e)
        {
            DataSet dsCites = new DataSet();
            SxGeo.OpenDB();
            //нет справочника стран
            if (SxGeo.GetHeader().CitySize == 0)
            {
                SxGeo.CloseDB();
                MessageBox.Show("No cites data!");
                return;

            }

            SxGToDataSet toDS = new SxGToDataSet(dsCites, SxGeo);
            string CountryFormat = SxGeo.GetHeader().PackFormat.
                Split('\0')[2];

            toDS.CreateTable("Cites", CountryFormat, SxGeoDirType.Cites);
            if (!toDS.FillTable())
            {
                MessageBox.Show(toDS.ErrorMessage);
                return;
            }

            frmTable fTableCountry = new frmTable();
            fTableCountry.TableName = "Cites";
            fTableCountry.dsTable = dsCites;
            fTableCountry.RecordsCount = toDS.RecordsCount;
            fTableCountry.ShowDialog();
            SxGeo.CloseDB();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            frmIPInfo fIPInfo = new frmIPInfo();
            IPGeoinfo ipg = new IPGeoinfo(b_cl.dbPath);
            fIPInfo.data=ipg.GetIPInfo(txtIP.Text.Trim());
            fIPInfo.ShowDialog();
        }

        private void rbSxGeoCity_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSxGeoCity.Checked)
            {
                b_cl.dbPath = b_cl.dbDir + b_cl.SxGeoCity;
            }
            else
            {
                b_cl.dbPath = b_cl.dbDir + b_cl.SxGeo;
            }

            SxGeo = new SxGeoDB(b_cl.dbPath);
        }
    }
}
