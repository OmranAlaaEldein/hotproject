using Microsoft.AspNetCore.Http;
using Shopping.Models;
using Shopping.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Services.Admin.BradeSer
{
    public interface IHotProjectServices
    {
        //Get
        Task<List<HotProjectDto>> GetAll();

        Task<HotProjectDto> Get(Guid? id);

        Task<List<HotProjectDto>> FindWithName(string name);

        List<HotProjectDto> Filter(string name, int skip, int take);

        //DML
        Task<HotProjectDto> Add(CreateUpdateHotProjectDto entity,IFormFile file);

        Task<HotProjectDto> Update(CreateUpdateHotProjectDto entity, IFormFile file);

        Task<HotProjectDto> Delete(Guid id);

        //Save
        void Save();
    }
}
