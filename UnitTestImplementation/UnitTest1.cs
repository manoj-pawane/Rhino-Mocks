using BasicMockTestingDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace UnitTestImplementation
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Stub example
        /// </summary>
        [TestMethod]
        public void ProcessDataSource()
        {
            var mockDataSource = MockRepository.GenerateStub<IDataSource>();
            mockDataSource.Stub(x => x.DataAvailable()).Return(true);
            Controller target = new Controller();
            target.DataSource = mockDataSource;

            mockDataSource.Expect(x => x.DataAvailable()).Return(false);

            target.Process();
            mockDataSource.VerifyAllExpectations();
        }

        



        [TestMethod()]
        public void ProcessTest_DataAvailableReturnsFalse()
        {
            var mockDataSource = MockRepository.GenerateMock<IDataSource>();

            Controller target = new Controller();
            target.DataSource = mockDataSource;

            mockDataSource.Expect(x => x.DataAvailable()).Return(false);

            target.Process();
            mockDataSource.VerifyAllExpectations();
        }

        [TestMethod()]
        public void ProcessTest_DataAvailableReturnsTrue()
        {
            var mockDataSource = MockRepository.GenerateMock<IDataSource>();

            Controller target = new Controller();
            target.DataSource = mockDataSource;

            mockDataSource.Expect(x => x.DataAvailable()).Return(true);
            var data = new int[] { 1, 2, 3 };
            mockDataSource.Expect(x => x.GetData()).Return(data);

            target.Process();
            mockDataSource.VerifyAllExpectations();
            Assert.AreEqual(data, target.Data);
        }

    }
}
