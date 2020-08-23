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
        private int _num1;
        private int _num2;
        private int _interval;
        private Dictionary<State, string> _stateText;
        IForset forset;


        public ForsetHandler(IForsetFactory forsetFactory)
        {
            _forsetFactory = forsetFactory;
            _rand = new Random();
            _stateText = new Dictionary<State, string>();
            _stateText.Add(State.Health, "O");
            _stateText.Add(State.OnFire, "X");
            _stateText.Add(State.Dead, ".");
        }

        public void Bootstrapping()
        {
            CreateForset();
            ConnectTrees(100);
            SetFire(0, 0);
            SetInterval(1000);
            int count = 0;

            while (true)
            {
                Console.WriteLine($"{count}: ");
                Print();

                forset.forestTress[0, 0].CheckTree(new Tree(10));
                count++;
                Thread.Sleep(_interval);
            }
        }
            

        public void CreateForset(int num1 = 20, int num2 = 20)
        {
            _num1 = num1;
            _num2 = num2;
            forset = _forsetFactory.CreateForest(num1, num2);
        }

        public void ConnectTrees(int success)
        {
            for (int i = 0; i <_num1; i++)
            {
                for (int j = 0; j < _num2; j++)
                {
                    int number = _rand.Next(1, 101);

                    if (number >= 1 && number <= success)
                    {
                        if (j < _num2 -1)
                        {
                            forset.forestTress[i, j +1].Subscriber(forset.forestTress[i, j]);
                        }
                    }
                }

            }   
        }

        public void SetFire(int index1, int index2)
        {
            if (index1 >= 0 && index1 < _num1 && index2 >= 0 && index2< _num2)
            {
                forset.forestTress[index1, index2].TreeSetOnFire();
            }
        }

        public void SetInterval(int interval)
        {
            _interval = interval;
        }

        public void Print()
        {
            for (int i = 0; i < _num1; i++)
            {
                for (int j = 0; j < _num2; j++)
                {
                    Console.Write(_stateText[forset.forestTress[i, j].State]);          
                }
                Console.WriteLine();
            }
        }
    }
}
