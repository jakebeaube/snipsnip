using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApp.Models
{
    public class Coffee   
    {
        public int ID { get; set; }
        public string Name { get; set;  }
        public string Origin { get; set;  }
        public string Roast { get; set;  }
        public string Brand { get; set;  }

        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }
    }
}
