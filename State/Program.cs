﻿using System;
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
            context.SetState(new ModifieldState());

            ModifieldState modifieldState = new ModifieldState();
            modifieldState.DoAction(context);
            DeletedState deletedState = new DeletedState();
            deletedState.DoAction(context);
            AddedState addedState = new AddedState();
            addedState.DoAction(context);

            Console.WriteLine(context.GetState()); // şuanki durumu veriyor.

            Console.ReadLine();
        }
    }

    interface IState //durum arayüzü
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

    class ModifieldState : IState
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
            Console.WriteLine("State: Deleted");
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
            Console.WriteLine("State: Added");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Added";
        }
    }
}
