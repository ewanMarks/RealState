using FluentValidation.TestHelper;
using RealState.Application.UseCase.Properties.Queries.GetAll;

namespace RealState.Test.Validators.RealState.Properties;

public class GetPropertiesValidatorTests
{
    [Test]
    public void Should_Fail_When_Page_Is_Less_Than_1()
    {
        var validator = new GetPropertiesValidator();
        var q = new GetAllPropertiesQuery(null, null, null, null, null, null, null, null, null, null, 0, 10, null, null);

        var result = validator.TestValidate(q);
        result.ShouldHaveValidationErrorFor(x => x.Page);
    }
}
