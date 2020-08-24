﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class Tree : ITree
    {
        public event Action AllConnectTree;
        public int Health { get; private set; }
        public State State { get; private set; }
        private bool _isFiratTime;

        public Tree(int health )
        {
            Health = health;
            State = State.Health;
            _isFiratTime = true;
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
            if (_isFiratTime)
            {
                _isFiratTime = false;
            }
            else
            {
                AllConnectTree?.Invoke();
            }
        }
        public void DownHealth()
        {
            if (Health == 0)
            {
                State = State.Dead;
            }
            else if (State == State.OnFire)
            {
                Health--;
            }   
        }
        public void SetOthersOnFire()
        {
            AllConnectTree?.Invoke();
        }
        public void TreeSetOnFire()
        {
            if (State == State.Health)
            {
                State = State.OnFire;

            }
        }
        public void Subscriber(ITree tree)
        {
            tree.AllConnectTree += TreeSetOnFire;
        }
        public void Unsubscriber(ITree tree)
        {
            tree.AllConnectTree -= TreeSetOnFire;
        }


    }
}
