using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class Forest : IForset
    {
        public ITree[,] forestTress { get; private set; }

        public Forest(int row, int column)
        {
            forestTress = new Tree[row, column
];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    forestTress[i, j] = new Tree(10);
                }
            }
        }


    }
}
