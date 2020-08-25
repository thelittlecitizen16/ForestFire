using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire.Interfaces
{
    public interface ITree
    {
        public event Action AllConnectTree;
        public int Health { get; }
        public State State { get; }
        public void DownHealth();
        public void SetOthersOnFire();
        public void TreeSetOnFire();
        public void Subscriber(ITree tree);
        public void Unsubscriber(ITree tree);
    }
}
