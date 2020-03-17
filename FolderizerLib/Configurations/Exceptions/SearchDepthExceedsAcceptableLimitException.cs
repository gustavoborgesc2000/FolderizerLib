using System;

namespace FolderizerLib.Configuration
{
    public class SearchDepthExceedsAcceptableLimitException : ArgumentException
    {
        public SearchDepthExceedsAcceptableLimitException(string message) : base(message) { }

    }
}