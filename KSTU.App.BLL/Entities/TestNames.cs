using KSTU.App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTU.App.BLL.Entities
{
    [Table("russian_names")]
    public class TestNames : BaseEntity
    {
        public string Name { get; set; }
        public string Sex { get; set; }
    }
}
