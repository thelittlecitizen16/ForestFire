using ForestFire.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ForestFire
{
    public class ForsetHandler
    {
        private IForsetFactory _forsetFactory;
        private Random _rand;
        private Dictionary<State, string> _stateText;
        public IForset Forset;


        public ForsetHandler(IForsetFactory forsetFactory)
        {
            _forsetFactory = forsetFactory;
            _rand = new Random();
            _stateText = new Dictionary<State, string>();
            AddStateText();
        }
        private void AddStateText()
        {
            _stateText.Add(State.Health, "O");
            _stateText.Add(State.OnFire, "X");
            _stateText.Add(State.Dead, ".");
        }

        public void CreateForset(int row = 20, int column = 20)
        {
            Forset = _forsetFactory.CreateForest(row, column);
        }
   
        public void ConnectTrees(int? success = null)
        {
            for (int i = 0; i < Forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < Forset.forestTress.GetLength(1); j++)
                {
                    int number = _rand.Next(1, 101);

                    if (number >= 1 && number <= (success))
                    {
                        if ((i + 1) <= Forset.forestTress.GetLength(0) - 1)
                        {
                            Forset.forestTress[i + 1, j].Subscriber(Forset.forestTress[i, j]);
                        }
                        if ((i -1) >= 0)
                        {
                            Forset.forestTress[i -1, j].Subscriber(Forset.forestTress[i, j]);
                        }

                        if ((j + 1) <= Forset.forestTress.GetLength(1) - 1)
                        {
                            Forset.forestTress[i, j + 1].Subscriber(Forset.forestTress[i, j]);
                        }
                        if ((j - 1) >= 0)
                        {
                            Forset.forestTress[i , j - 1].Subscriber(Forset.forestTress[i, j]);
                        }
                    }
                }
            }
        }

        public ITree SetFire(int index1, int index2)
        {
            if (index1 >= 0 && index1 < Forset.forestTress.GetLength(0) && index2 >= 0 && index2 < Forset.forestTress.GetLength(1))
            {
                Forset.forestTress[index1, index2].TreeSetOnFire();
                return Forset.forestTress[index1, index2];
            }
            else
            {
                Forset.forestTress[0, 0].TreeSetOnFire();
                return Forset.forestTress[0, 0];
            }
        }

        public void Print()
        {
            for (int i = 0; i < Forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < Forset.forestTress.GetLength(1); j++)
                {
                    Console.Write(_stateText[Forset.forestTress[i, j].State]);
                }
                Console.WriteLine();
            }
        }
    }
}
