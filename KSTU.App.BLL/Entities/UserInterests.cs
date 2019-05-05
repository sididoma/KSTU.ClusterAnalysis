using KSTU.App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTU.App.BLL.Entities
{
    public class UserInterests : BaseEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public double InterestValue { get; set; }
    }
}
