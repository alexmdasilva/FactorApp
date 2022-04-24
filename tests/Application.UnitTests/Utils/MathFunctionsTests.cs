using Application.Utils;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Application.UnitTests.Utils
{
    public class MathFunctionsTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(11)]
        [InlineData(23)]
        public void IsPrime_WithGivenPrimeNumber_ShouldReturnTrue(int primeNumber)
        {
            //Act
            var result = MathFunctions.IsPrime(primeNumber);

            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(-1)]
        [InlineData(-5)]
        public void IsPrime_WithGivenCompositeNumber_ShouldReturnFalse(int compositeNumber)
        {
            //Act
            var result = MathFunctions.IsPrime(compositeNumber);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(GetDivisorsTestParameters))]
        public void GetDivisors_WithGivenPositiveNumber_ShouldReturnAllDivisors(int number, List<int> expectedResult)
        {
            //Act
            var result = MathFunctions.GetDivisors(number);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetDivisors_WithGivenNegativeNumber_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var negativeNumber = -5;

            //Act 
            var action = () => MathFunctions.GetDivisors(negativeNumber);

            //Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetDivisors_WithZeroAsArgument_ShouldThrowArgumentOutOfRangeException()
        {
            //Act
            var action = () => MathFunctions.GetDivisors(0);

            //Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        public static IEnumerable<object[]> GetDivisorsTestParameters
        {
            get
            {
                yield return new object[] { 1, new List<int> { 1 } };
                yield return new object[] { 5, new List<int> { 1, 5 } };
                yield return new object[] { 16, new List<int> { 1, 2, 4, 8, 16 } };
                yield return new object[] { 100, new List<int> { 1, 2, 4, 5, 10, 20, 25, 50, 100 } };
            }
        }
    }
}