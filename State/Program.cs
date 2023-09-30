using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modified=new ModifiedState();
            DeletedState deleted=new DeletedState();
            modified.DoAction(context);
            deleted.DoAction(context);

            Console.WriteLine(context.GetState());
            Console.ReadLine();
        }
    }

    interface IState
    {
        void DoAction(Context context);

    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Stated: Deleted");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Deleted";
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Stated: Added");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Added";
        }
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
}
