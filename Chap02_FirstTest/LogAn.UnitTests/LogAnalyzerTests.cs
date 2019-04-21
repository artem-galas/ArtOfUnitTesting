using System;

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

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            // Arrange
            LogAnalyzer logAnalyzer = new LogAnalyzer();

            // Act
            bool result = logAnalyzer.IsValidLogFileName("file_with_bad_extention.foo");

            // Assert
            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtentionLowerCase_ReturnsTrue()
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("file_with_good_extention.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtentionUpperCase_ReturnsTrue()
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("file_with_good_extention.SLF");

            Assert.True(result);
        }

        // parameterized test - refactor previous two tests
        [TestCase("file_with_good_extention.SLF")]
        [TestCase("file_with_good_extention.slf")]
        public void IsValidLogFileName_ValidExtention_ReturnTrue(string fileName)
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName(fileName);

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();

            var exception = Assert.Catch<Exception>(() => logAnalyzer.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", exception.Message);
        }

        // fluent syntax in assertion
        [Test]
        public void IsValidLogFileName_EmptyFileName_ThrowsArgumentException()
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();

            var exception = Assert.Throws<ArgumentException>(() => logAnalyzer.IsValidLogFileName(""));

            Assert.That(
                exception.Message,
                Does.Contain("filename has to be provided")
            );
        }

        [TestCase("bad_filename.foo", false)]
        [TestCase("good_filename.slf", true)]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();

            logAnalyzer.IsValidLogFileName(fileName);

            Assert.AreEqual(expected, logAnalyzer.WasLastFileNameValid);
        }
    }
}