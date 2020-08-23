using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class ForestFactory  : IForsetFactory
    {
        public IForset CreateForest(int num1, int num2)
        {
            return new Forest(num1, num2);
        }
    }
}
