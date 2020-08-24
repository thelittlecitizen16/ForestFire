using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public interface IForsetFactory
    {
        public IForset CreateForest(int row, int column);

    }
}
