using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace SxGeoReader
{
    public class SxGToDataSet
    {
        public string ErrorMessage { get; private set; }
        public int RecordsCount { get; private set; } //количество записей в таблице
        //public bool RevBO { get; set; }

        private DataSet SxDS = null;
        private string TableName = null;
        private string RecordFormat = null;
        private SxGeoDirType TableType;
        private SxGeoUnpack Unpacker = null;
        private SxGeoDB Database = null; //проинициализированная и открытая база данных

        private long TableStart = 0; //начало таблицы (в байтах)
        private uint TableSize = 0; //размер таблицы (RegionSize и т.д.)
        private ushort MaxRecordSize = 0; //максимальный размер записи в байтах (MaxRegion и т.д.)


        public SxGToDataSet(DataSet ds, SxGeoDB db)
        {
            SxDS = ds;
            Database = db;
        }

        public void CreateTable(string Table, string Format, SxGeoDirType tabletype)
        {
            TableName = Table;
            RecordFormat = Format;
            TableType = tabletype;
            SxGeoHeader Header = Database.GetHeader();
            Unpacker = new SxGeoUnpack(RecordFormat,
                Header.DBEncoding);            

            //добавляем табличку
            SxDS.Tables.Add(TableName);

            Dictionary<string, Type> RecordTypes = Unpacker.GetRecordTypes();

            //добавляем колонки
            foreach (string FieldName in RecordTypes.Keys)
            {
                SxDS.Tables[TableName].Columns.Add(FieldName, 
                    RecordTypes[FieldName]);
            }

            switch (TableType)
            {
                case SxGeoDirType.Cites:
                    {
                        TableStart = Header.cites_begin;
                        TableSize = Header.CitySize;
                        MaxRecordSize = Header.MaxCity;
                    }; break;
                case SxGeoDirType.Countries:
                    {
                        TableStart = Header.countries_begin + 1;//вот хз почему +1, иначе не работает
                        TableSize = Header.CountrySize;
                        MaxRecordSize = Header.MaxCountry;
                    }; break;
                case SxGeoDirType.Regions:
                    {
                        TableStart = Header.regions_begin+1;//вот хз почему +1, иначе не работает
                        TableSize = Header.RegionSize;
                        MaxRecordSize = Header.MaxRegion;
                    }; break;
            }
        }

        public bool FillTable()
        {            
            //становимся на начало таблицы
            if (!Database.Seek(TableStart, SeekOrigin.Begin))
            {
                ErrorMessage = Database.ErrorMessage;
                return false;
            }

            long Readed = 0;
            int NextRead = MaxRecordSize;

            while (Readed < TableSize-1)
            {
                //читаем запись
                byte[] buf = Database.ReadBytes(NextRead);
                if (buf == null)
                {
                    ErrorMessage = Database.ErrorMessage;
                    return false;
                }

                //распаковываем запись
                int RealLength = 0;
                Dictionary<string, object> Record = Unpacker.Unpack(buf, 
                    out RealLength);

                //кладем ее в таблицу DataSet
                DataRow dr = SxDS.Tables[TableName].NewRow();

                foreach (string FieldName in Record.Keys)
                {
                    dr[FieldName] = Record[FieldName];
                }

                SxDS.Tables[TableName].Rows.Add(dr);

                //Сохраняем количество фактических байт записи
                Readed += RealLength;
                //Отступаем в потоке назад
                long backstep = 0;
                if (TableStart + Readed + MaxRecordSize > Database.FileSize)
                {
                    //если на чтение последних записей файла не хватило
                    //максимальной длины записи                    
                    backstep = -NextRead + RealLength;
                    NextRead = (int)(Database.FileSize - TableStart - Readed);                    
                    //break;
                }
                else
                {
                    backstep = -NextRead + RealLength;
                }
                
                Database.Seek(backstep, SeekOrigin.Current);
                
                //добавляем счетчик записей
                RecordsCount++;
            }
            return true;
        }

    }
}
