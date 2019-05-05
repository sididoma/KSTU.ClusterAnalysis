using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KSTU.Common.Services
{
    public class FileService : IFileService
    {
        public List<ClusterEntityDTO> GetDataFromExcel(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public List<ClusterEntityDTO> GetDataFromTxt(IFormFile file)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            string[] names = lines[0].Split(" ");

            List<ClusterEntityDTO> result = new List<ClusterEntityDTO>();

            for(int i = 1; i < lines.Count; i++)
            {
                ClusterEntityDTO dTO = new ClusterEntityDTO();
                string[] parametrs = lines[i].Split(" ");
                dTO.Interests = new List<Interest>();
                dTO.Name = parametrs[0];

                for(int j = 1; j < parametrs.Length; j++)
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
