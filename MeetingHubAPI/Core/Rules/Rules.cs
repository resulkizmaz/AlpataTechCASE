using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Rules
{
    public sealed class Rules
    {
        private static readonly Rules instance = new Rules();

        public static Rules Instance { get { return instance; } }

        private Rules()
        {

        }
    }
}
