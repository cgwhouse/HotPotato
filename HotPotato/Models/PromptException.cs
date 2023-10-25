using System;

namespace HotPotato.Models;

public class PromptException : Exception
{
    public PromptException() { }

    public PromptException(string message)
        : base(message) { }

    public PromptException(string message, Exception inner)
        : base(message, inner) { }
}
