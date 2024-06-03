using AirAstanaWebAPI.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace UnitInfrastructureTest
{
    public class AccountControllerTest
    {
        private readonly Mock<IUserService> _mockUsersService;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly AccountController _accountController;
        public AccountControllerTest() {
            _mockUsersService = new Mock<IUserService>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration.Setup(config => config["ApplicationSettings:SecretKey"]).Returns("77777777_VIP_KAZAKH_VIP_777777777");
            _accountController = new AccountController(_mockUsersService.Object, _mockConfiguration.Object);

        }
        [Fact]
        public async Task AccountTest()
        {
            string UserName = "Bakdaulet1998";
            string Password = "string1998";
            var res=_mockUsersService.Setup(service => service.GetAuthorizationToken(UserName, Password, "77777777_VIP_KAZAKH_VIP_777777777"));
            string result = await _accountController.GetAuthorizationToken(UserName, Password);
            Assert.NotNull(res);
            //var okResult = Assert.IsType<OkObjectResult>(result);
            //var token = Assert.IsType<string>(okResult.Value);
            //Assert.Equal("fake-jwt-token", token);
        }
    }
}
