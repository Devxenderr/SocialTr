using System;

namespace SocialTrading.Tools.Exceptions
{
    public class RepoEditContactNullReferenceException : NullReferenceException
    {
        public RepoEditContactNullReferenceException()
        {
        }

        public RepoEditContactNullReferenceException(string message) : base(message)
        {
        }

        public RepoEditContactNullReferenceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}