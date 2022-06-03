using System;

namespace P21
{
    //Rutina de tratare a unui eveniment.

    class Program
    {
        static void HandlerEv()
        {
            Console.WriteLine("Evenimentul s-a produs.");
        }

        static void Main()
        {
            MyEvent ev = new MyEvent();
            ev.activare += new MyEventHandlerDelegate(HandlerEv);
            ev.Fire();
        }
    }

    public delegate void MyEventHandlerDelegate();

    class MyEvent
    {
        public event MyEventHandlerDelegate activare;

        public void Fire()
        {
            activare();
        }
    }
}
