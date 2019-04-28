namespace Chap05.LogAn
{
    public class Presenter
    {
        private readonly IView _view;
        private readonly ILogger _logger;

        public Presenter(IView view, ILogger logger)
        {
            _view = view;
            _logger = logger;
            _view.Loaded += OnLoaded;
            _view.ErrorOccured += OnError;
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }

        private void OnError(string text)
        {
            _logger.LogError(text);
        }
    }
}