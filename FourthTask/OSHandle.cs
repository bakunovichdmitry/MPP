using System;
using System.Runtime.InteropServices;

namespace FourthTask
{
    class OSHandle : IDisposable
    {
        [DllImport("Kernel32")]
        private static extern bool CloseHandle(IntPtr hObject); 

        public IntPtr hObject;
        private bool _isDisposed;

        public OSHandle(IntPtr hObject)
        {
            if (hObject == IntPtr.Zero)
            {
                throw new ArgumentException("Handle can't be null");
            }

            this.hObject = hObject;
        }

        ~OSHandle()
        {
            Dispose();
            // GC.SuppressFinalize(true);
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                CloseHandle(hObject);
                _isDisposed = true;
            }
        }
    }
}
