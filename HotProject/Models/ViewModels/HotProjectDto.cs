using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models.ViewModels
{
    public class HotProjectDto
    {
        //test init list
        public Guid id { set; get; }
        [Display(Name= "HotProject")]
        public string Name { set; get; }
        
        [Display(Name = "Image")]
        public string pathImage { set; get; }

    }

    public class CreateUpdateHotProjectDto
    {
        public Guid? id { set; get; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { set; get; }
        public string pathImage { set; get; }

    }

    //page layer
    public class PageingHotProjectDto
    {
        int paged { set; get; }
        int total { set; get; }
        
        List<HotProjectDto> hotProjects { set; get; }
    }
}
