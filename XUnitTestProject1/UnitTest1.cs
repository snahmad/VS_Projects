using System;
using Xunit;
using Moq;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mock_serial = new Mock<ISerial>();
            mock_serial.Setup(x => x.getFirst()).Returns(3);
            mock_serial.Setup(x => x.getSecond()).Returns(2);

            var maths_helper = new MathsHelper();
           var result =  maths_helper.add(mock_serial.Object);
            Assert.Equal(result, 5);


        }
    }
}
