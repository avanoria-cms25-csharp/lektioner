using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services;

namespace Tests.Services;

public class UserService_Tests
{
    [Fact]
    public void AddUserToList_ShouldReturnTrue_WhenUserIsAddedToList()
    {
        // Arrange - förberedelser
        IUserService userService = new UserService();
        User user = new User()
        {
            Email = "hans@domain.com",
            Password = "BytMig123!"
        };


        // Act - utförandet
        UserServiceResponse result = userService.AddUserToList(user);

        // Assert - result / utfall
        Assert.True(result.Succeeded);
    }

    [Fact]
    public void AddUserToList_ShouldReturnFalseWidthError_WhenUserIsNull()
    {
        // Arrange - förberedelser
        IUserService userService = new UserService();
        User user = null!;


        // Act - utförandet
        UserServiceResponse result = userService.AddUserToList(user);


        // Assert - result / utfall
        Assert.False(result.Succeeded);
        Assert.Equal("User is Null", result.Error);
    }

    [Fact]
    public void AddUserToList_ShouldReturnFalseWidthError_WhenEmailIsInvalid()
    {
        // Arrange - förberedelser
        IUserService userService = new UserService();
        User user = new User { Email = "" };


        // Act - utförandet
        UserServiceResponse result = userService.AddUserToList(user);


        // Assert - result / utfall
        Assert.False(result.Succeeded);
        Assert.Equal("Email is invalid", result.Error);
    }

    [Fact]
    public void AddUserToList_ShouldReturnFalseWidthError_WhenPasswordIsInvalid()
    {
        // Arrange - förberedelser
        IUserService userService = new UserService();
        User user = new User { Email = "hans@domain.com", Password = "" };


        // Act - utförandet
        UserServiceResponse result = userService.AddUserToList(user);


        // Assert - result / utfall
        Assert.False(result.Succeeded);
        Assert.Equal("Password is invalid", result.Error);
    }

    [Fact]
    public void UserExistsInList_ShouldReturnTrue_WhenListContainsUser()
    {
        // Arrange
        IUserService userService = new UserService();
        User user = new User() { Email = "hans@domain.com", Password = "BytMig123!" };
        userService.AddUserToList(user);    

        // Act
        bool result = userService.UserExistsInList(user);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UserExistsInList_ShouldReturnFalse_WhenListDoNotContainsUser()
    {
        // Arrange
        IUserService userService = new UserService();
        User user = new User() { Email = "hans@domain.com", Password = "BytMig123!" };

        // Act
        bool result = userService.UserExistsInList(user);

        // Assert
        Assert.False(result);
    }
}
