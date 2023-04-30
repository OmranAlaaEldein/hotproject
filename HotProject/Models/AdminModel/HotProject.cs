using Shopping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class HotProjectObj:IEntity
    {
        public HotProjectObj()
        {
            DateAdd = DateTime.Now;
        }
        [Key]
        public Guid id { set; get; }
        
        public string Name { set; get; }
        public string pathImage { set; get; }

        public DateTime DateAdd { set; get; }


    }
}
