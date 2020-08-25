using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire.Interfaces
{
    public interface IForsetFactory
    {
        public IForset CreateForest(int row, int column);
    }
}
