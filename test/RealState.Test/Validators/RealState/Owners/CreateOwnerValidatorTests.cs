using FluentAssertions;
using FluentValidation.TestHelper;
using RealState.Application.UseCase.Owners.Commands.Create;

namespace RealState.Test.Validators.RealState.Owners;

public class CreateOwnerValidatorTests
{
    [Test]
    public void Should_Have_Error_When_Name_Empty()
    {
        var validator = new CreateOwnerValidator();
        var cmd = new CreateOwnerCommand("", null, null, null);

        var result = validator.TestValidate(cmd);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public void Should_Pass_With_Valid_Data()
    {
        var validator = new CreateOwnerValidator();
        var cmd = new CreateOwnerCommand("Jane", "Addr", null, new DateOnly(1990, 1, 1));

        var result = validator.TestValidate(cmd);
        result.IsValid.Should().BeTrue();
    }
}