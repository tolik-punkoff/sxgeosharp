using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SxGeoReader
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        public SxGeoHeader Header;
        
        private void frmInfo_Load(object sender, EventArgs e)
        {
            
        }
        
        private void frmInfo_Shown(object sender, EventArgs e)
        {
            string[] LabelText = new string[] {"Версия: ",
            "Время создания: ",
            "Тип БД: ",
            "Кодировка: ",
            "Элементов в индексе первых байт (b_idx_len/fbIndexLen): ",
            "Элементов в основном индексе (m_idx_len/mIndexLen): ",
            "Блоков в одном элементе индекса (range/Range): ",
            "Количество диапазонов (db_items/DiapCount): ",
            "Размер ID-блока в байтах (1 для стран, 3 для городов) (id_len/IdLen): ",
            "Максимальный размер записи региона - до 64 кб (max_region): ",
            "Максимальный размер записи города - до 64 кб (max_city): ",
            "Размер справочника регионов (region_size): ",
            "Размер справочника городов (city_size): ",
            "Максимальный размер записи страны - до 64 кб (max_country): ",
            "Размер справочника стран (country_size): ",
            "Размер описания формата упаковки города/региона/страны (pack_size): ",
            "Описание формата упаковки (RAW): ",
            //"---",
            "Начало индекса первых байт: ",
            "Начало основного индекса: ",
            "Начало диапазонов: ",
            "Начало справочника регионов: ",
            "Начало справочника городов: ",
            "Начало справочника стран: "};

            grdInfo.Columns.Add("Info", "Info");
            grdInfo.Columns.Add("Data", "Data");

            foreach (string txt in LabelText)
            {
                if (txt == "---")
                {
                    grdInfo.Rows.Add(3);
                }
                else
                {
                    grdInfo.Rows.Add(txt, "");
                }
            }

            grdInfo.Rows[0].Cells[1].Value = Header.Version ;
            grdInfo.Rows[1].Cells[1].Value = Header.Timestamp.ToString() ;
            grdInfo.Rows[2].Cells[1].Value = Header.DBType.ToString() ;
            grdInfo.Rows[3].Cells[1].Value = Header.DBEncoding.ToString() ;
            grdInfo.Rows[4].Cells[1].Value = Header.fbIndexLen.ToString() ;
            grdInfo.Rows[5].Cells[1].Value = Header.mIndexLen.ToString() ;
            grdInfo.Rows[6].Cells[1].Value = Header.Range.ToString() ;
            grdInfo.Rows[7].Cells[1].Value = Header.DiapCount.ToString() ;
            grdInfo.Rows[8].Cells[1].Value = Header.IdLen.ToString() ;
            grdInfo.Rows[9].Cells[1].Value = Header.MaxRegion.ToString() ;
            grdInfo.Rows[10].Cells[1].Value = Header.MaxCity.ToString() ;
            grdInfo.Rows[11].Cells[1].Value = Header.RegionSize.ToString() ;
            grdInfo.Rows[12].Cells[1].Value = Header.CitySize.ToString() ;
            grdInfo.Rows[13].Cells[1].Value = Header.MaxCountry.ToString() ;
            grdInfo.Rows[14].Cells[1].Value = Header.CountrySize.ToString() ;
            grdInfo.Rows[15].Cells[1].Value = Header.PackSize.ToString() ;
            grdInfo.Rows[16].Cells[1].Value = Header.PackFormat.ToString().Replace('\0', '\n') ;

            //смещения частей БД
            grdInfo.Rows[17].Cells[1].Value = Header.fb_begin ;
            grdInfo.Rows[18].Cells[1].Value = Header.midx_begin ;
            grdInfo.Rows[19].Cells[1].Value = Header.db_begin ;
            grdInfo.Rows[20].Cells[1].Value = Header.regions_begin ;
            grdInfo.Rows[21].Cells[1].Value = Header.cites_begin ;
            grdInfo.Rows[22].Cells[1].Value = Header.countries_begin ;

            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
