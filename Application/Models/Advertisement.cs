using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Advertisement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public string ImagePath { get; set; }
    }
}
