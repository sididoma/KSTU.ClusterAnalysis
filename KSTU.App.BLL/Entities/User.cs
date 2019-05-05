using KSTU.App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.App.BLL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserInterests> UserInterests { get; set; }
    }
}
