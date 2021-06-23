using System;

namespace NetCoreSummary.Services
{
    public class DisposableServiceSample : IDisposable
    {
        private bool disposed;

        public void Action() => Console.WriteLine("Disposable service action");

        // Note:
        //  that dispose called after each service call, beacause service registered as scoped
        //  dispose pattern
        public void Dispose() 
        {
            if (disposed)
                return;
            
            Console.WriteLine($"Dispose service {nameof(DisposableServiceSample)}");
            
            disposed = true;
        }
    }
}
