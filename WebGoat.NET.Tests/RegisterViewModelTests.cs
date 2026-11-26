using System.ComponentModel.DataAnnotations;//Giver adgang til valideringsfunktioner
using WebGoatCore.ViewModels;//Giver adgang til RegisterViewModel-klassen

namespace WebGoat.NET.Tests;

public class RegisterViewModelTests
{
    [Fact]//Fortæller xUnit, at dette er en testmetode
    public void Username_IsRequired()//Tester, at brugernavn er påkrævet
    {
        // Arrange
        var model = new RegisterViewModel
        {
            Username = "",
            Email = "test@company.com",
            CompanyName = "Test Company",
            Password = "Password123!",
            ConfirmedPassword = "Password123!"
        };

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
    }


}
