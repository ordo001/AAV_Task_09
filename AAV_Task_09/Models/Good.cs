using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAV_Task_09.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string GoodName { get; set; } = string.Empty;
        public double Price { get; set; }
        public byte[]? Picture { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CountGood { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
