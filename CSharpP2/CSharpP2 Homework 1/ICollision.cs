using System.Drawing;

namespace CSharpP2_Homework_1
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
