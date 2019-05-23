using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KSTU.Web.Models
{
    public class HierarchicalCreateVM
    {
        [Required(ErrorMessage = "Укажите {0}")]
        [Display(Name = "Количество объединений на каждом шагу")]
        public int CountOfUnionsInStep { get; set; }
        [Required(ErrorMessage = "Укажите {0}")]
        [Display(Name = "Тип вычисления растояния")]
        public byte DistanceType { get; set; }
        [Display(Name = "Метод объединения кластеров")]
        [Required(ErrorMessage = "Укажите {0}")]
        public byte ClusterUnionType { get; set; }
        [Display(Name = "Формат исходных данных")]
        [Required(ErrorMessage = "Выберите {0}")]
        public byte DataType { get; set; }
        [Display(Name = "Файл с данными для кластеризации")]
        public IFormFile UploadFile { get; set; }
    }
}
