using Domain.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
        }
    }
}