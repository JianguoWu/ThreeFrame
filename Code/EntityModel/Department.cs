using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public partial class Department
    {
        [Key]
        public int DId { get; set; }
        public string DNo { get; set; }
        public string DName { get; set; }

        public Department() { }
        public Department(string DNo, string DName)
        {
            this.DNo = DNo;
            this.DName = DName;
        }
        public Department(int DId, string DNo, string DName)
        {
            this.DId = DId;
            this.DNo = DNo;
            this.DName = DName;
        }
    }
}