using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
