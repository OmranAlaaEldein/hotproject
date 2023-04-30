using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shopping.Controllers.Admin;
using Shopping.Data;
using Shopping.Models;
using Shopping.Models.ViewModels;
using Shopping.Services.Admin.BradeSer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HotProjectTest.HotProjectControllerTest
{
    public class HotProjectControllerTest
    {
        private readonly HotProjectController _controller;
        
        public HotProjectControllerTest(HotProjectServices service)
        {
            _controller = new HotProjectController(service);
        }

        [Fact]
        public async Task GetAsync_GetData_ReturnListHotProjectDto()
        {
            //Arrange
            //Act
            var OkResult =await _controller.GetAsync() as OkObjectResult;
            var items = OkResult.Value;

            //Assert
            Assert.IsType<List<HotProjectDto>>(items as HotProjectDto);
            
        }

        [Fact]
        public async Task Post_AddElement_ReturnList()
        {
            //Arrange
            var id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");
            var addItem = new CreateUpdateHotProjectDto() {
                Name = "test",
                pathImage = "",
            };

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("Hello World from a Fake File");
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", "test.pdf");


            //Act
            var OkResult = await _controller.PostAsync(file,addItem) as OkObjectResult;
            var item = OkResult.Value;

            //Assert
            Assert.IsType<HotProjectDto>(item);
        }

        [Fact]
        public async Task Post_AddElementErrorValid_ReturnBadRequest()
        {
            //Arrange
            var id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");
            var addItem = new CreateUpdateHotProjectDto()
            {
                pathImage = "",
            };

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("Hello World from a Fake File");
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", "test.pdf");

            _controller.ModelState.AddModelError("Name", "Required");
            //Act
            var OkResult = await _controller.PostAsync(file, addItem) as BadRequestObjectResult;
            
            //Assert
            Assert.IsType<BadRequestObjectResult>(OkResult);
        }

        [Fact]
        public async Task GetAsyncId_GetDataExist_ReturnItemHotProjectDto()
        {
            //Arrange
            var id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");

            //Act
            var OkResult = await _controller.GetAsync(id) as OkObjectResult;
            var item = OkResult.Value;

            //Assert
            Assert.IsType<HotProjectDto>(item);
        }

        [Fact]
        public async Task GetAsyncId_GetDataNotExist_ReturnNotFound()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var OkResult = await _controller.GetAsync(id) as OkObjectResult;
            var item = OkResult.Value;

            //Assert
            Assert.IsType<HotProjectDto>(item);
        }

        [Fact]
        public async Task SearchAsync_SearchElementByName_ReturnListHotProjectDto()
        {
            //Arrange
            string name = "test";

            //Act
            var OkResult = await _controller.SearchAsync(name) as OkObjectResult;
            var item = OkResult.Value as List<HotProjectDto>;

            //Assert
            Assert.IsType<List<HotProjectDto>> (item);
            Assert.NotEmpty(item);
        }

        [Fact]
        public void Filter_FilterElementByMulti_ReturnList()
        {
            //Arrange
            string name = "test";

            //Act
            var OkResult = _controller.Filter(name,0,10) as OkObjectResult;
            var item = OkResult.Value as List<HotProjectDto>;

            //Assert
            Assert.IsType<List<HotProjectDto>>(item);
            Assert.NotEmpty(item);
        }

        [Fact]
        public async Task Put_EditElementById_ReturnItemHotProjectDto()
        {
            //Arrange
            var id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");
            var editItem = new CreateUpdateHotProjectDto()
            {
                Name = "test2",
                pathImage = "",
            };

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("");
            writer.Flush();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", "test.pdf");

            //Act
            var OkResult = await _controller.PutAsync(file,editItem) as OkObjectResult;
            var item = OkResult.Value as HotProjectDto;
            //Assert
            Assert.IsType<HotProjectDto>(item);
            Assert.Equal("test2",item.Name);
        }

        [Fact]
        public async Task Delete_DeleteElementById_ReturnNoContentResult()
        {
            //Arrange
            var id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");

            //Act
            var OkResult = await _controller.DeleteAsync(id) as NoContentResult;

            //Assert
            Assert.IsType<NoContentResult>(OkResult);
        }

        [Fact]
        public async Task Delete_DeleteElementNoExistById_ReturnNotFound()
        {
            //Arrange
            var id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");

            //Act
            var OkResult = await _controller.DeleteAsync(id) as NotFoundObjectResult;

            //Assert
            Assert.IsType<NotFoundObjectResult>(OkResult);
        }
    }
}
