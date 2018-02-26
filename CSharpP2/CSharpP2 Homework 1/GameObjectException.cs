using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    class GameObjectException : Exception
    {
        public GameObjectException(string msg) : base(msg){}

    }
}
