using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public interface ITree
    {
        public event Action AllConnectTree;
        public int Health { get; }
        public State State { get; }
        public void CheckTree(ITree tree);
        public void TreeSetOnFire();
        public void Subscriber(ITree tree);
        public void Unsubscriber(ITree tree);
        public void DownHealth();
        public void SetOthersOnFire();
    }
}
