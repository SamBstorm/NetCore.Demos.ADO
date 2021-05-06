using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Demos.Ado
{
    public class Disposable : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Ciao! Tout le monde!");
        }
    }
}
