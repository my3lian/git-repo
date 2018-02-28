using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    interface IEnemy
    {
        int Hp { get;}
        void Hurt(int n);
        int Damage { get;}
    }
}
