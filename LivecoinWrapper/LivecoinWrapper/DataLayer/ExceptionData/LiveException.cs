using System;

namespace LivecoinWrapper.DataLayer.ExceptionData
{
    class LiveException : Exception
    {
        public LiveException()
        {
        }

        public LiveException(string message)
            : base(message)
        {
        }

        public LiveException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
