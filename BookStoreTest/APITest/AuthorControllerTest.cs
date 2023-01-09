using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookStoreAPI;
using OnlineBookStoreAPI.Controllers;
using OnlineBookStoreAPI.Data;
using OnlineBookStoreAPI.Models;
using OnlineBookStoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreTest.APITest
{
    [TestClass]
    class AuthorControllerTest
    {
        private readonly IAuthorRepository _authorRepository;

        [TestMethod]
        public void GetAllAuthors_Success()
        {
            var mockRepository =  new Mock<IAuthorRepository>();
            mockRepository.Setup(x => x.GetAllAuthorAsync());

            var controller = new AuthorController(mockRepository.Object);

            // Act
            Task<IActionResult> actionResult = controller.GetAllAuthors();
            var contentResult = actionResult ;

            // Assert
            Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(42, contentResult.Content.Id);
        }
    }
}
