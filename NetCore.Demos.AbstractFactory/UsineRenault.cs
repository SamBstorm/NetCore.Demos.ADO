using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Demos.AbstractFactory
{
    public sealed class UsineRenault : Usine
    {
        public override Voiture Produire() {
            return new VoitureRenault();
        }

    }
}
