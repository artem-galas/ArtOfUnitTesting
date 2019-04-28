using System;

using NUnit.Framework;
using NSubstitute;

using Chap05.LogAn;

namespace Chap05.Tests
{
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            // Arrange
            var logger = Substitute.For<ILogger>();
            var logAnalyzer = new LogAnalyzer(logger)
            {
                MinNameLength = 6
            };

            // Act
            logAnalyzer.Analyze("a.txt");

            // Assert
            logger.Received().LogError($"Filename too short: a.txt");
        }

        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName(Arg.Any<String>()).Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("any.txt"));
        }

        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();
            fakeRules
                .When(x => x.IsValidLogFileName(Arg.Any<string>()))
                .Do(context => throw new Exception("fake exception"));

            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));
        }
    }
}