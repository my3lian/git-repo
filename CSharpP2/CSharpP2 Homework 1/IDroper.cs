using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    interface IDroper
    {
        GameObject Item { get; set; }

        void SetDrop();

        void Drop();

    }
}
