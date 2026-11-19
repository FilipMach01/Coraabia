using Xunit;

namespace Coraabia.Tests;

public class ParameterParserTests
{
    [Fact]
    public void Parse_LowercaseName_ReturnsParameter()
    {
        var parameter = ParameterParser.Parse("danger");

        Assert.Equal(Parameter.Danger, parameter);
    }

    [Fact]
    public void Parse_UnknownName_ReturnsNull()
    {
        var parameter = ParameterParser.Parse("banana");

        Assert.Null(parameter);
    }

    [Fact]
    public void Parse_NumberText_ReturnsNull()
    {
        var parameter = ParameterParser.Parse("1");

        Assert.Null(parameter);
    }
}
