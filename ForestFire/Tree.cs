using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class Tree : ITree
    {
        public event Action<ITree> AllConnectTree;
        public int Health { get; private set; }
        public State State { get; private set; }

        public Tree(int health )
        {
            Health = health;
            State = State.Health;

        }
        public void CheckTree(ITree tree)
        { 
            if (tree.State == State.OnFire)
            {
               State = State.OnFire;
            }
            if (State == State.OnFire)
            {
                if (Health > 0)
                {
                    Health--;
                }  
            }
            if (Health == 0)
            {
                State = State.Dead;
            }

            AllConnectTree?.Invoke(this);
        }
        public void TreeSetOnFire()
        {
            State = State.OnFire;
        }
        public void Subscriber(ITree tree)
        {
            tree.AllConnectTree += CheckTree;
        }

       
    }
}
