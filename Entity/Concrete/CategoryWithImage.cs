using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class CategoryWithImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ImagePath { get; set; }
    }
}
