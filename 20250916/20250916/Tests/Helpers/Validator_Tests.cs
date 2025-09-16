using Presentation.Helpers;
using Presentation.Models;

namespace Tests.Helpers;

public class Validator_Tests
{
    [Fact]
    public void ValidateUser_ShouldReturnTrue_IfUserNotNull()
    {
        // Arrange
        User user = new User();

        // Act
        var result = Validator.ValidateUser(user);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateUser_ShouldReturnFalse_IfUserIsNull()
    {
        // Arrange
        User user = null!;

        // Act
        var result = Validator.ValidateUser(user);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("hans.mattin-lassei@domain.com")]
    [InlineData("hans@domain.com")]
    [InlineData("a@a.a")]
    public void ValidateEmail_ShouldReturnTrue_WhenValid(string email)
    {
        // Act
        var result = Validator.ValidateEmail(email);    

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("hansdomain.com")]
    public void ValidateEmail_ShouldReturnFalse_WhenInValid(string? email)
    {
        // Act
        var result = Validator.ValidateEmail(email!);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("BytMig123!")]
    [InlineData("Mjb7s3DD7!")]
    public void ValidatePassword_ShouldReturnTrue_WhenValid(string password)
    {
        // Act
        var result = Validator.ValidatePassword(password);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("BytMig")]
    public void ValidatePassword_ShouldReturnFalse_WhenInValid(string? password)
    {
        // Act
        var result = Validator.ValidatePassword(password!);

        // Assert
        Assert.False(result);
    }
}
