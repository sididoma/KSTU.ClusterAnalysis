using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KSTU.App.BLL.DTOs
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
