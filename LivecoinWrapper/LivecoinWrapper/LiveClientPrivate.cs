using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LivecoinWrapper
{
    public class LiveClientPrivate :LiveClient
    {
        private static LiveClientPrivate instance;
        private static object syncRoot = new Object();

        private readonly string publicKey;
        private readonly string secretKey;

        protected LiveClientPrivate(string publicKey, string secretKey):base()
        {
            this.publicKey = publicKey;
            this.secretKey = secretKey;
        }

        public LiveClientPrivate Set (string pubKiy, string secKey)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new LiveClientPrivate(pubKiy, secKey);
                }
            }

            return instance;
        }
    }
}
