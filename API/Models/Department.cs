using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("TB_M_Department")]
    public class Department
    {
        [key]
        public int id { get; set; }
        public string name { get; set; }
        public int Division_id { get; set; }
        [ForeignKey("Division_id")]
        public Division Division { get; set; }
    }
}