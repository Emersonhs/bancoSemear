using Xunit;
using XUnit.Project.Attributes;

namespace XUnit.Project
{
    [TestCaseOrderer("XUnit.Project.Orderers.PriorityOrderer", "Tests.XUnit")]
    public class ByPriorityOrder
    {
        public static bool Test1Called;
        public static bool Test2ACalled;
        public static bool Test2BCalled;
        public static bool Test3Called;

        [Fact, TestPriority(5)]
        public void Test3()
        {
            Test1Called = true;
            Test2ACalled = true;
            Test3Called = true;

            Assert.True(Test1Called);
            Assert.True(Test2ACalled);
            Assert.True(Test3Called);
        }

        [Fact, TestPriority(0)]
        public void Test2B()
        {
            Test2ACalled = true;
            Test1Called = true;

            Assert.True(Test1Called);
            Assert.True(Test2ACalled);
            Assert.False(Test3Called);
        }

        [Fact]
        public void Test2A()
        {
            Test1Called = true;
            
            Assert.True(Test1Called);
            Assert.False(Test2BCalled);
            Assert.False(Test3Called);
        }

        [Fact, TestPriority(-5)]
        public void Test1()
        {
           // Test1Called = true;

            Assert.False(Test2ACalled);
            Assert.False(Test2BCalled);
            Assert.False(Test3Called);
        }
    }
}