using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using Xunit;

namespace CSharpFunctionalExtensionsExercise;

public class Tests
{
    //private readonly Cases _sut;
    //public Tests()
    //{
    //    _sut = new Cases();
    //}

    private readonly Solution _sut;
    public Tests()
    {
        _sut = new Solution();
    }

    [Fact]
    public void CaseA_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string, E>(new E("x"));
        
        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();
        
        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseA(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error.Message);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Never);
    }

    [Fact]
    public void CaseA_WhenSecondFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string, E>(new E("x"));

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();

        f2.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseA(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error.Message);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseA_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var expected = Result.Success<string, E>("x");

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();
        
        f2.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseA(f1.Object, f2.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(expected.Value);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseB_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string>("x");

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Func<string>>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseB(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Should().Be(expected.Error);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Never);
    }

    [Fact]
    public void CaseB_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var expected = "x";

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Func<string>>();

        f2.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseB(f1.Object, f2.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(expected);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseC_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string>("x");

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Func<string>>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseC(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Never);
    }

    [Fact]
    public void CaseC_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var expected = "x";

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Func<string>>();

        f2.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseC(f1.Object, f2.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(expected);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseD_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string>("x");

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Action>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseD(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Never);
    }

    [Fact]
    public void CaseD_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var expected = Result.Success<string>("x");

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Action>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseD(f1.Object, f2.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(expected.Value);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseE_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string, E>(new E("x"));

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseE(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error.Message);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Never);
    }

    [Fact]
    public void CaseE_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var expected = Result.Success<string, E>("x");

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseE(f1.Object, f2.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(expected.Value);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseF_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string>("x");

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Func<Result<string, E>>>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseF(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Never);
    }

    [Fact]
    public void CaseF_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var expected = Result.Success<string, E>("x");

        var f1 = new Mock<Func<Result<string>>>();
        var f2 = new Mock<Func<Result<string, E>>>();

        f2.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseF(f1.Object, f2.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(expected.Value);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
    }


    [Fact]
    public void CaseG_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string, E>(new E("x"));

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();
        var f3 = new Mock<Func<string, string, Result<string, E>>>();

        f1.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseG(f1.Object, f2.Object, f3.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error.Message);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Never);
        f3.Verify(f => f(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void CaseG_WhenSecondFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string, E>(new E("x"));

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();
        var f3 = new Mock<Func<string, string, Result<string, E>>>();

        f2.Setup(f => f()).Returns(expected);

        // Act
        var actual = _sut.CaseG(f1.Object, f2.Object, f3.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error.Message);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
        f3.Verify(f => f(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void CaseG_WhenThirdFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var expected = Result.Failure<string, E>(new E("x"));

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();
        var f3 = new Mock<Func<string, string, Result<string, E>>>();

        f3.Setup(f => f(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);

        // Act
        var actual = _sut.CaseG(f1.Object, f2.Object, f3.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(expected.Error.Message);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
        f3.Verify(f => f(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void CaseG_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var f1Value = Result.Success<string, E>("x");
        var f2Value = Result.Success<string, E>("y");
        var f3Value = Result.Success<string, E>("z");

        var f1 = new Mock<Func<Result<string, E>>>();
        var f2 = new Mock<Func<Result<string, E>>>();
        var f3 = new Mock<Func<string, string, Result<string, E>>>();

        f1.Setup(f => f()).Returns(f1Value);
        f2.Setup(f => f()).Returns(f2Value);
        f3.Setup(f => f(f1Value.Value, f2Value.Value)).Returns(f3Value);

        // Act
        var actual = _sut.CaseG(f1.Object, f2.Object, f3.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(f3Value.Value);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(), Times.Once);
        f3.Verify(f => f(f1Value.Value, f2Value.Value), Times.Once);
    }

    [Fact]
    public void CaseH_WhenFirstFuncReturnsFailure_ThenReturnsThatFailure()
    {
        // Arrange
        var err1 = Result.Failure<string>("x");
        var err2 = Result.Failure<string>("y");
        var err = new List<Result<string>> { err1, err2 };

        var f1 = new Mock<Func<IEnumerable<Result<string>>>>();

        f1.Setup(f => f()).Returns(err);

        // Act
        var actual = _sut.CaseH(f1.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be($"{err1.Error}, {err2.Error}");
        f1.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseH_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var value1 = Result.Success("x");
        var value2 = Result.Success("y");
        var values = new List<Result<string>> { value1, value2 };

        var f1 = new Mock<Func<IEnumerable<Result<string>>>>();

        f1.Setup(f => f()).Returns(values);

        // Act
        var actual = _sut.CaseH(f1.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().HaveCount(values.Count);
        actual.Value.ToList()[0].Should().Be(value1.Value);
        actual.Value.ToList()[1].Should().Be(value2.Value);
        f1.Verify(f => f(), Times.Once);
    }

    [Fact]
    public void CaseI_WhenFirstFuncReturnFailures_ThenReturnsThatFailures()
    {
        // Arrange
        var err = Result.Failure<IEnumerable<string>>("x");

        var f1 = new Mock<Func<Result<IEnumerable<string>>>>();
        var f2 = new Mock<Func<string, UnitResult<E>>>();

        f1.Setup(f => f()).Returns(err);

        // Act
        var actual = _sut.CaseI(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be(err.Error);
        f2.Verify(f => f(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void CaseI_WhenSecondFuncReturnFailures_ThenReturnsThatFailures()
    {
        // Arrange
        var f1Value1 = "x";
        var f1Value2 = "y";
        var f1Value3 = "z";
        var f1Values = new List<string> { f1Value1, f1Value2, f1Value3 };
        var f2Value1 = UnitResult.Success<E>();
        var f2Err1 = "err1";
        var f2Err2 = "err2";

        var f1 = new Mock<Func<Result<IEnumerable<string>>>>();
        var f2 = new Mock<Func<string, UnitResult<E>>>();

        f1.Setup(f => f()).Returns(Result.Success<IEnumerable<string>>(f1Values));
        f2.SetupSequence(f => f(It.IsAny<string>()))
            .Returns(f2Value1)
            .Returns(UnitResult.Failure(new E(f2Err1)))
            .Returns(UnitResult.Failure(new E(f2Err2)));

        // Act
        var actual = _sut.CaseI(f1.Object, f2.Object);

        // Assert
        actual.IsFailure.Should().BeTrue();
        actual.Error.Message.Should().Be($"{f2Err1}, {f2Err2}");
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(f1Value1), Times.Once);
        f2.Verify(f => f(f1Value2), Times.Once);
        f2.Verify(f => f(f1Value3), Times.Once);
    }

    [Fact]
    public void CaseI_WhenAllFuncsReturnSuccess_ThenReturnsSuccess()
    {
        // Arrange
        var f1Value1 = "x";
        var f1Value2 = "y";
        var f1Value3 = "z";
        var f1Values = new List<string> { f1Value1, f1Value2, f1Value3 };
        var f2Value = UnitResult.Success<E>();

        var f1 = new Mock<Func<Result<IEnumerable<string>>>>();
        var f2 = new Mock<Func<string, UnitResult<E>>>();

        f1.Setup(f => f()).Returns(Result.Success<IEnumerable<string>>(f1Values));
        f2.Setup(f => f(It.IsAny<string>())).Returns(f2Value);

        // Act
        var actual = _sut.CaseI(f1.Object, f2.Object);

        // Assert
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().HaveCount(f1Values.Count);
        actual.Value.ToList()[0].Should().Be(f1Value1);
        actual.Value.ToList()[1].Should().Be(f1Value2);
        actual.Value.ToList()[2].Should().Be(f1Value3);
        f1.Verify(f => f(), Times.Once);
        f2.Verify(f => f(f1Value1), Times.Once);
        f2.Verify(f => f(f1Value2), Times.Once);
        f2.Verify(f => f(f1Value3), Times.Once);
    }
}
