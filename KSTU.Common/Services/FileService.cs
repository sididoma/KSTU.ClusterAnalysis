using ClosedXML.Excel;
using KSTU.Common.DTOs;
using KSTU.Common.Helpers;
using KSTU.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KSTU.Common.Services
{
    public class FileService : IFileService
    {
        public List<ClusterEntityDTO> GetData(IFormFile file, byte dataType)
        {
            switch (dataType)
            {
                case (byte)EnumDataType.Text:
                    return GetDataFromTxt(file);
                case (byte)EnumDataType.Excel:
                    return GetDataFromExcel(file);
                case (byte)EnumDataType.DataBase:
                    return GetDataFromDB();
            }
            return new List<ClusterEntityDTO>();
        }

        private List<ClusterEntityDTO> GetDataFromDB()
        {

            return null;
        }
        private List<ClusterEntityDTO> GetDataFromExcel(IFormFile file)
        {
            var wb = new XLWorkbook(file.OpenReadStream());
            var ws = wb.Worksheets.First();
            var range = ws.RangeUsed();
            var rowCount = range.RowCount();
            var colCount = range.ColumnCount();
            List<ClusterEntityDTO> result = new List<ClusterEntityDTO>();
            List<string> names = new List<string>();

            for(int i = 2; i <= colCount; i++)
            {
                names.Add(ws.Cell(1, i).Value.ToString());
            }

            for(int i = 2; i <= rowCount; i++)
            {
                ClusterEntityDTO dTO = new ClusterEntityDTO();
                dTO.Name = ws.Cell(i, 1).Value.ToString();
                dTO.Interests = new List<Interest>();

                for(int j = 2; j <= colCount; j++)
                {
                    Interest interest = new Interest
                    {
                        Name = names[j - 2],
                        Weight = double.Parse(ws.Cell(i, j).Value.ToString()),
                        Weight2 = double.Parse(ws.Cell(i, j).Value.ToString())
                    };
                    dTO.Interests.Add(interest);
                }
                result.Add(dTO);
            }

            return result;
        }

        private List<ClusterEntityDTO> GetDataFromTxt(IFormFile file)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            string[] names = lines[0].Split(" ");

            List<ClusterEntityDTO> result = new List<ClusterEntityDTO>();

            for (int i = 1; i < lines.Count; i++)
            {
                ClusterEntityDTO dTO = new ClusterEntityDTO();
                string[] parametrs = lines[i].Split(" ");
                dTO.Interests = new List<Interest>();
                dTO.Name = parametrs[0];

                for (int j = 1; j < parametrs.Length; j++)
                {
                    Interest intrst = new Interest
                    {
                        Name = names[j],
                        Weight = double.Parse(parametrs[j]),
                        Weight2 = double.Parse(parametrs[j])
                    };
                    dTO.Interests.Add(intrst);
                }
                result.Add(dTO);
            }

            return result;
        }
    }
}
