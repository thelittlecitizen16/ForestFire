using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class Forest : IForset
    {
        public ITree[,] forestTress { get; private set; }

        public Forest(int num1, int num2)
        {
            forestTress = new Tree[num1, num2];
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    forestTress[i, j] = new Tree(2);
                }
            }
        }


    }
}
