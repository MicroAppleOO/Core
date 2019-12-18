using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public partial class PersonInfor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
    }
}
