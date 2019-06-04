using KSTU.App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTU.App.BLL.Entities
{
    [Table("Hobbies")]
    public class Hobbies : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
