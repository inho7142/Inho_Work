using System;
using System.Collections.Generic;

namespace Destruction
{
    public class Disposable : IDisposable
    {
        // Disposed
        private bool disposed;
        private List<IDisposable> items;
        
        public Disposable()
        {
            this.items = new List<IDisposable>();
        }

         ~Disposable()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            try
            {
                if (disposing)
                {
                    // IDisposable 인터페이스를 구현하는 멤버들을 여기서 정리합니다.
                    IDisposable[] targetList = new IDisposable[this.items.Count];
                    this.items.CopyTo(targetList);
                    foreach (IDisposable eachItem in targetList)
                    {
                        try
                        {
                            eachItem.Dispose();
                        }
                        catch (Exception ex)
                        {
                            /* 예외 처리를 수행합니다. */
                            Console.WriteLine(ex.ToString());
                        }
                        finally
                        {
                            /* 정리 작업을 수행합니다. */
                        }
                    }

                    this.items.Clear();
                }
                try
                {
                    /* .NET Framework에 의하여 관리되지 않는 외부 리소스들을 여기서 정리합니다. */
                }
                catch
                {
                    /* 예외 처리를 수행합니다. */
                }
                finally
                {
                    /* 정리 작업을 수행합니다.  */
                    this.disposed = true;
                }
            }
            finally { /* 정리 작업을 수행합니다. */ }
        }
    }
}
