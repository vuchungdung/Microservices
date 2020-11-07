using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
