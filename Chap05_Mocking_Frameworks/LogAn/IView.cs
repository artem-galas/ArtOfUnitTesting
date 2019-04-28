using System;

namespace Chap05.LogAn
{
    public interface IView
    {
        event Action Loaded;
        event Action<string> ErrorOccured;
        void Render(string text);
    }
}