using NUnit.Framework;

using LogAn;

namespace Tests
{
    public class LogAnalyzerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            // set Stub to return true
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager
            {
                WillBeValid = true
            };

            // set Stub as Dependency 
            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeExtensionManager);

            // Act
            bool result = logAnalyzer.IsValidLogFileName("short.ext");

            // Assert
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            //set up the stub to use, make sure it returns true
            var myFakeExtensionManager = new FakeExtensionManager {
                WillBeValid = true
            };

            // set stub into factrory class for this test
            ExtensionManagerFactory.SetManager(myFakeExtensionManager);
            LogAnalyzer logAnalyzer = new LogAnalyzer();

            // Act
            bool result = logAnalyzer.IsValidLogFileName("validFileName.ext");

            // Assert
            Assert.True(result);
        }
    }

    /// The fake extension manager is located in the same file as the test code 
    /// because currently the fake is used only from within this test class.
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;

        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }
}
