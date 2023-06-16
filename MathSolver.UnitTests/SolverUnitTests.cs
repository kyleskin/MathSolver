using FluentAssertions;

namespace MathSolver.UnitTests;

public class SolverUnitTests
{
    private readonly Service.MathSolver _solver;
    
    public SolverUnitTests()
    {
        _solver = new("");
    }
    
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GivenAnEmptyOrNullExpression_ThrowsNewNullArgumentException(string? emptyExpression)
    {
        // Act
        Action act = () => _solver.Solve(emptyExpression);
        
        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("2 + 3")]
    [InlineData("2 + a =")]
    [InlineData("2 3 =")]
    [InlineData("2a + 3 =")]
    public void GivenAnInvalidExpression_ThrowsNewArgumentOutOfRangeException(string invalidExpression)
    {
        // Act
        Action act = () => _solver.Solve(invalidExpression);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenAnAdditionProblem_ReturnsCorrectAnswer()
    {
        // Arrange
        string expression = "2 + 3 =";
        
        // Act
        string result = _solver.Solve(expression);
        
        // Assert
        result.Should().Be("5");
    }
    
    [Fact]
    public void GivenASubtractionProblem_ReturnsCorrectAnswer()
    {
        // Arrange
        string expression = "2 - 3 =";
        
        // Act
        string result = _solver.Solve(expression);
        
        // Assert
        result.Should().Be("-1");
    }
    
    [Fact]
    public void GivenAMultiplicationProblem_ReturnsCorrectAnswer()
    {
        // Arrange
        string expression = "2 * 3 =";
        
        // Act
        string result = _solver.Solve(expression);
        
        // Assert
        result.Should().Be("6");
    }
    
    [Fact]
    public void GivenADivisionProblem_ReturnsCorrectAnswer()
    {
        // Arrange
        string expression = "10 / 5 =";
        
        // Act
        string result = _solver.Solve(expression);
        
        // Assert
        result.Should().Be("2");
    }
}