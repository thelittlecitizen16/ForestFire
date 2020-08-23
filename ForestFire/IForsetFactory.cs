using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public interface IForsetFactory
    {
        public IForset CreateForest(int num1, int num2);

    }
}
