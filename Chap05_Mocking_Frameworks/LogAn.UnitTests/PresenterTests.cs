using System;

using NUnit.Framework;
using NSubstitute;

using Chap05.LogAn;

namespace Chap05.Tests
{
    public class PresenterTests
    {
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();
            var p = new Presenter(mockView, Substitute.For<ILogger>());

            // Trigger the event with NSubstitute
            mockView.Loaded += Raise.Event<Action>();

            // Check that the view was called
            mockView
                .Received()
                .Render(
                    Arg.Is<string>(s => s.Contains("Hello World"))
                );
        }

        [Test]
        public void ctor_WhenViewhasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();
            var p = new Presenter(stubView, mockLogger);

            // Simulate the error
            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

            // Uses mock to check log call
            mockLogger
                .Received()
                .LogError(
                    Arg.Is<string>(s => s.Contains("fake error"))
                );
        }
    }
}