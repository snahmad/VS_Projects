using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

// Assumptions:

public interface IFoo
{
    int GetCount();
}

namespace Cshrap_unit_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.GetCount()).Returns(1);

        }
    }
}
