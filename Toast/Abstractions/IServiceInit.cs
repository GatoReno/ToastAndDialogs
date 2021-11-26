using System;
using Android.Content;

namespace Toast.Abstractions
{
    /// <summary>
    /// This class should be in the specific platform
    /// to catch the context
    /// </summary>
    public interface IServiceInit
    {
        void Initialize(Context context);
        Context Context { get; }
    }
}
