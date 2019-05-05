using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KSTU.Web.Models
{
    public class KMeansCreateVM
    {
        [Required(ErrorMessage = "Укажите {0}")]
        [Display(Name = "Количество кластеров")]
        public int ClustersCount { get; set; }
        [Required(ErrorMessage = "Укажите {0}")]
        [Display(Name = "Тип вычисления растояния")]
        public byte DistanceType { get; set; }
        [Display(Name = "Файл с данными для кластеризации")]
        public IFormFile UploadFile { get; set; }
    }
}
