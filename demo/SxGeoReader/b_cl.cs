using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SxGeoReader
{
    public static class b_cl
    {
        public static string dbDir = Application.StartupPath+"\\data\\";
        public static string SxGeo = "SxGeo.dat";
        public static string SxGeoCity = "SxGeoCity.dat";
        public static string dbPath = dbDir+SxGeoCity;
    }
}
