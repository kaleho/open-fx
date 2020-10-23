using System;
using Xunit;

namespace Open.Fx.Tests
{
    public class TryCatchTests
    {
        [Fact]
        public void TryCatchIgnore_Func_Will_Return_False_When_Exception()
        {
            var result = 0.TryCatchIgnore(x => 1/x, out var value);

            Assert.False(result);
            Assert.Equal(0, value);
        }

        [Fact]
        public void TryCatchIgnore_Func_Will_Return_True_When_No_Exception()
        {
            var result = 1.TryCatchIgnore(x => 1/x, out var value);

            Assert.True(result);
            Assert.Equal(1, value);
        }

        [Fact]
        public void TryCatchDefault_Func_Will_Return_False_When_Exception()
        {
            var result = 0.TryCatchDefault(x => 1 / x, 2, out var value);

            Assert.False(result);
            Assert.Equal(2, value);
        }

        [Fact]
        public void TryCatchDefault_Func_Will_Return_True_When_No_Exception()
        {
            var result = 1.TryCatchDefault(x => 1 / x, 2, out var value);

            Assert.True(result);
            Assert.Equal(1, value);
        }
    }
}
