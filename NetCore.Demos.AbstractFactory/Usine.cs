using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Demos.AbstractFactory
{
    public abstract class Usine
    {
        public abstract Voiture Produire();
    }
}
