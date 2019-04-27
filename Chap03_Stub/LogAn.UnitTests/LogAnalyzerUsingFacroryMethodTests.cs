using NUnit.Framework;

using LogAn;

namespace Tests
{
    public class LogAnalyzerUsingFactoryMethodTests
    {
        [Test]
        public void overrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;

            TestableLogAnalyzer logAnalyzer = new TestableLogAnalyzer(stub);

            bool result = logAnalyzer.IsValidLogFileName("file.ext");

            Assert.True(result);
        }
    }

    class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        public IExtensionManager Manager;
        
        public TestableLogAnalyzer(IExtensionManager mgr)
        {
            Manager = mgr;
        }

        protected override IExtensionManager GetManager()
        {
            return Manager;
        }
    }
}