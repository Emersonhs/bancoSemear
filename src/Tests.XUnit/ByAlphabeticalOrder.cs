using Xunit;

namespace XUnit.Project
{
    [TestCaseOrderer("XUnit.Project.Orderers.AlphabeticalOrderer", "XUnit.Tests")]
    public class ByAlphabeticalOrder
    {
        public static bool Test1Called;
        public static bool Test2Called;
        public static bool Test3Called;

        [Fact]
        public void Test1()
        {
            Test2Called = false;
            Test3Called = false;

            Assert.False(Test2Called);
            Assert.False(Test3Called);
        }

        [Fact]
        public void Test2()
        {
            Test2Called = true;
            Test3Called = false;
            Assert.True(Test1Called);
            Assert.False(Test3Called);
        }

        [Fact]
        public void Test3()
        {
            Test1Called = true;
            Test2Called = true;

            Assert.True(Test1Called);
            Assert.True(Test2Called);
        }
    }
}
