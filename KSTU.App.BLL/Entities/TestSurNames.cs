using KSTU.App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTU.App.BLL.Entities
{
    [Table("russian_surnames")]
    public class TestSurNames : BaseEntity
    {
        public string Surname { get; set; }
        public string Sex { get; set; }
    }
}
