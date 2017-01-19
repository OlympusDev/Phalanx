using System;

namespace Olympus.Phalanx.Controller
{
    public class ButtonPressEventArgs : EventArgs
    {
        public ButtonID buttonID { get; private set; }
        public int instigatorID { get; private set; }

        public ButtonPressEventArgs(ButtonID button,int instigator)
        {
            buttonID = button;
            instigatorID = instigator;
        }
    }
}
