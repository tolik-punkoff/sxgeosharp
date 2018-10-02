﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SxGeoReader
{
    public class IPGeoinfo
    {
        private string DatabasePath = null;
        private static string[,] SpecList = new string[,]  {
            {"0.0.0.0","0.255.255.255", "Current network"},
            {"255.255.255.255","255.255.255.255", "Broadcast"},
            {"255.0.0.0","255.255.255.255", "Reserved by the IETF, broadcast"},
            {"10.0.0.0","10.255.255.255", "Private network"},
            {"100.64.0.0","100.127.255.255", "Shared Address Space"},
            {"127.0.0.0","127.255.255.255", "Loopback"},
            {"169.254.0.0","169.254.255.255", "Link-local"},
            {"172.16.0.0","172.31.255.255", "Private network"},
            {"192.0.0.0","192.0.0.7", "DS-Lite"},
            {"192.0.0.170","192.0.0.170", "NAT64"},
            {"192.0.0.171","192.0.0.171", "DNS64"},
            {"192.0.2.0","192.0.2.255", "Documentation example"},
            {"192.0.0.0","192.0.0.255", "Reserved by the IETF"},										
            {"192.88.99.0","192.88.99.255", "Anycast"},
            {"192.88.99.1","192.88.99.1", "IPv6 to IPv4 Incapsulation"},
            {"192.168.0.0","192.168.255.255", "Private network"},
            {"198.51.100.0","198.51.100.255", "Documentation example"},
            {"198.18.0.0","198.19.255.255", "Test IP"},
            {"203.0.113.0","203.0.113.255", "Documentation example"},
            {"224.0.0.0","224.255.255.255", "Multicast"},
            {"240.0.0.0","240.255.255.255", "Future reserved"}
        };
        public IPGeoinfo(string databasepath)
        {
            DatabasePath = databasepath;
        }

        public static string CheckSpecDiaps(string IP)
        {
            int uip = IPConverter.IPToInt32(IP);

            for (int i = 0; i < SpecList.GetLength(0); i++)
            {
                int start = IPConverter.IPToInt32(SpecList[i,0]);
                int end = IPConverter.IPToInt32(SpecList[i, 1]);
                string desr = SpecList[i, 2];

                if (uip >= start && uip <= end)
                {
                    return desr;
                }
            }
            
            return string.Empty;
        }

        public Dictionary<string, object> GetIPInfo(string IP)
        {
            Dictionary<string, object> buf = new Dictionary<string, object>();
            string NormalForm = string.Empty;
            string InputIP = string.Empty;            

            if (!IPConverter.IsIP(IP))
            {
                buf.Add("ip", IP);
                buf.Add("status", "ERROR: Not valid IP address");
                return buf;
            }
            SxGeoDB db = new SxGeoDB(DatabasePath);
            db.DatabaseMode = SxGeoMode.FileMode;
            if (!db.OpenDB())
            {
                buf.Add("status", "ERROR: "+db.ErrorMessage);
                return buf;
            }

            NormalForm = IPConverter.ToStandForm(IP);
            if (NormalForm != IP)
            {
                InputIP = IP;
                IP = NormalForm;
            }

            string spec = CheckSpecDiaps(IP);
            if (spec != string.Empty)
            {
                buf.Add("ip", IP);
                if (InputIP != string.Empty) buf.Add("input_ip", InputIP);
                buf.Add("status", "WARNING: "+spec);
                return buf;
            }

            buf = db.GetIPInfo(IP, SxGeoInfoType.FullInfo);
            if (buf == null)
            {
                buf = new Dictionary<string, object>();
                buf.Add("ip", IP);
                if (InputIP != string.Empty) buf.Add("input_ip", InputIP);
                buf.Add("status", db.ErrorMessage);
                return buf;
            }

            if (InputIP != string.Empty) buf.Add("input_ip", InputIP);
            buf.Add("status", "OK");
            db.CloseDB();
            
            return buf;
        }
    }
}
