using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shopping.Data;
using Shopping.Models;
using Shopping.Models.Const;
using Shopping.Models.ViewModels;
using Shopping.Services.Admin.BradeSer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopping.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotProjectController : ControllerBase
    {
        private readonly IHotProjectServices _bradeServices;
        
        public HotProjectController(HotProjectServices bradeServices)
        {
            _bradeServices = bradeServices;
        }
        #region get

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var Brads = await _bradeServices.GetAll();
            return Ok(Brads);
            
            //return Ok(new Response()
            //{
            //    Errors = new List<string>(),
            //    Result = true,
            //    Data = new JsonResult(Brads)
            //});

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(Guid id)
        {
            //valid
            if (id == Guid.Empty)
                return NotFound();
            
            //get
            var Brad = await _bradeServices.Get(id);
            if (Brad == null)
                return NotFound();

            return Ok(Brad);
            //return Ok(new Response()
            //{
            //    Errors = new List<string>(),
            //    Result = true,
            //    Data = new JsonResult(Brad)
            //});
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult> SearchAsync(string name)
        {
            var Brad = await _bradeServices.FindWithName(name);
            return Ok(Brad);

            //return Ok(new Response()
            //{
            //    Errors = new List<string>(),
            //    Result = true,
            //    Data = new JsonResult(Brad)
            //});
        }

        [HttpGet]
        [Route("Filter")]
        public ActionResult Filter(string name, int skip, int take)
        {
            var Brads = _bradeServices.Filter(name, skip, take);
            return Ok(Brads);
            //return Ok(new Response()
            //        {
            //            Errors = new List<string>(),
            //            Result = true,
            //            Data = new JsonResult(Brads)
            //        });
        }
        #endregion get

        #region operation
        
        [HttpPost]
        public async Task<ActionResult> PostAsync(IFormFile file,[FromForm] CreateUpdateHotProjectDto createUpdatebrade)
        {
            //valid
            
            //add
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Bradresult = await _bradeServices.Add(createUpdatebrade, file);
            return Ok(Bradresult);
            //return Ok(new Response()
            //{
            //    Errors = new List<string>(),
            //    Result = true,
            //    Data = new JsonResult(Bradresult)
            //});
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(IFormFile file,[FromForm] CreateUpdateHotProjectDto updatedBrade)
        {
            //valid id
            if (updatedBrade.id == Guid.Empty)
                return BadRequest(ValidConst.ErrorIdNotVAlid);
                //return BadRequest(
                //    new Response()
                //    {
                //        Errors = new List<string>() { ValidConst.ErrorIdNotVAlid },
                //        Result = false,
                //        Data=null
                //    });

            //exist
            var brad = await _bradeServices.Get(updatedBrade.id);
            if (brad == null)
                return NotFound();
                /*
                  return NotFound(new Response()
                {
                    Errors = new List<string>() { ValidConst.ErrorBradNotExist },
                    Result = false,
                    Data=null
                });
                 */

                //update
            
            var result = await  _bradeServices.Update(updatedBrade, file);
            
            return Ok(result);
            /*
             return Ok(new Response()
            {
                Errors = new List<string>(),
                Result = true,
                Data = new JsonResult(result)
            });*/

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            //valid id
            if (id == Guid.Empty)
                return BadRequest(ValidConst.ErrorIdNotVAlid);
            //return BadRequest(
            //    new Response()
            //    {
            //        Errors = new List<string>() { ValidConst.ErrorIdNotVAlid },
            //        Result = false,
            //        Data=null
            //    });

            //valid exist
            var brad =await _bradeServices.Get(id);
            if (brad == null)
                return NotFound();
            //return NotFound(
            //    new Response()
            //    {
            //        Errors = new List<string>() { ValidConst.ErrorBradNotExist },
            //        Result = false,
            //        Data=null
            //    });

            //valid have category

            //delete
            var result = await _bradeServices.Delete(id);
            return NoContent();
            
            //return Ok(
            //    new Response()
            //        {
            //            Errors = new List<string>(),
            //            Result = true,
            //            Data = new JsonResult(result)
            //        }
            //    );
        }
        #endregion operation
    }
}
