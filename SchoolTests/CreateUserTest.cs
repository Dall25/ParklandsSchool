using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using ParklandsSchool.Controllers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTests
{
    public class UserControllerTest
    {

        private readonly Mock<UserController> _controller;
        private readonly Mock<IUserService> _userService;
        private readonly Mock<ILogger<UserController>> _logger;

        
        public UserControllerTest()
        {
            _userService = new Mock<IUserService>();
            _logger = new Mock<ILogger<UserController>>();
            _controller = new Mock<UserController>();
        }
        
        [Fact]
        public async void AddUser()
        {
            mock.Setup(p => p.AddUser.AddAsync);
            UserController user = new UserController(mock.Object);
            user result = user.Create;
            
        }
    }
}
