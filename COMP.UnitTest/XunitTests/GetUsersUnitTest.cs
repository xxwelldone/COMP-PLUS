using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP_.Controllers;
using COMP_.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace COMP.UnitTest.XunitTests
{
    public class GetUsersUnitTest : IClassFixture<UsersTestController>
    {
        private readonly UserController _userController;
        public GetUsersUnitTest(UsersTestController testconfig)
        {
            _userController = new UserController(testconfig.UOW);
        }

        [Fact]
        public async Task GetAllUsers_OkResult()
        {
            //Arrange

            //Act
            var data = await _userController.GetAllUsers(); 

            //Assert
            data.Result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeAssignableTo<IEnumerable<User>>();
        }
        [Fact]
        public async Task GetAllUsers_NotFound()
        {
            //Arrange

            //Act
            var data = await _userController.GetAllUsers();

            //Assert
            data.Result.Should().BeOfType<NotFoundObjectResult>();

        }


    }
}
