using System;
using Android.Content;
using Toast.Abstractions;

namespace Toast.Service
{
    public sealed class ServiceInitializer : IServiceInit
    {
        private static  IServiceInit _serviceInit;
        public Context Context { get; private set; }

        public static IServiceInit Instance
        {
            get
            {
                if (_serviceInit == null)
                {
                    _serviceInit = new ServiceInitializer();
                }

                return _serviceInit;
            }
        }

        private ServiceInitializer()
        {
            
        }

        public void Initialize(Context context)
        {
            Context = context;
        }
    }
}
