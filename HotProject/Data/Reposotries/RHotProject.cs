using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data
{
    public class RHotProject : Respository<HotProjectObj>, IRHotProject
    {
        public RHotProject(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
