using System;

namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Context context =new Context();
          ModifiedState modifiedstate = new ModifiedState();
          modifiedstate.DoAction(context);
          Console.WriteLine(context.GetState());
        }
        interface IState
        {
            void DoAction(Context context);
        }

        class Context
        {
            private IState _state;
            
            public void SetState(IState state)
            {
                _state = state;
            }
            public IState GetState()
            {
                return _state;
            }
        }
        class ModifiedState : IState
        {
            public void DoAction(Context context)
            {
                context.SetState(this);
                Console.WriteLine("State : Modified");
            }
        }
        class DeletedState : IState
        {
            public void DoAction(Context context)
            {
                context.SetState(this);
                Console.WriteLine("State : Deleted");
            }
        }
    }
}
