using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ExceptionData
{
    class LivecoinApiException : Exception
    {
        public LivecoinApiException()
        {
        }

        public LivecoinApiException(string message)
            : base(message)
        {
        }

        public LivecoinApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
