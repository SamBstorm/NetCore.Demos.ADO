using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Demos.AbstractFactory
{
    public sealed class UsineAudi : Usine
    {
        public override Voiture Produire()
        {
            return new VoitureAudi();
        }
    }
}
