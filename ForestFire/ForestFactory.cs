using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class ForestFactory  : IForsetFactory
    {
        public IForset CreateForest(int row, int column)
        {
            return new Forest(row, column);
        }
    }
}
