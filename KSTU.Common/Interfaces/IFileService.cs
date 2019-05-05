using KSTU.Common.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.Interfaces
{
    public interface IFileService
    {
        List<ClusterEntityDTO> GetDataFromTxt(IFormFile file);
        List<ClusterEntityDTO> GetDataFromExcel(IFormFile file);
    }
}
