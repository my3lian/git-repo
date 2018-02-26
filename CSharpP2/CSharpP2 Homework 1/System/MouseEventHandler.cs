namespace System
{
    internal class MouseEventHandler
    {
        private Action<object, EventArgs> btnPlay_Click;

        public MouseEventHandler(Action<object, EventArgs> btnPlay_Click)
        {
            this.btnPlay_Click = btnPlay_Click;
        }
    }
}