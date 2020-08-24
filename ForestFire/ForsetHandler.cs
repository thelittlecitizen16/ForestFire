using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Timer = System.Timers.Timer;

namespace ForestFire
{
    public class ForsetHandler
    {
        private IForsetFactory _forsetFactory;
        private Random _rand;
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
        private  void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            List<ITree> allOnFireTress = new List<ITree>();

            for (int i = 0; i < forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < forset.forestTress.GetLength(1); j++)
                {
                    if (forset.forestTress[i, j].State == State.OnFire)
                    {
                        allOnFireTress.Add(forset.forestTress[i, j]);
                    }
                }
            }

            allOnFireTress.ForEach(t => t.SetOthersOnFire());
            allOnFireTress.ForEach(t => t.DownHealth());

            Console.WriteLine($"......");
            Print();
        }

        public void Bootstrapping()
        {
            int count = 1;
            CreateForset();
            ConnectTrees2(70);
            ITree tree = SetFire(10, 10);
            Print();

            var aTimer = new Timer(1000);

            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            count++;
        }
        //public void Bootstrapping()
        //{
        //    CreateForset();
        //    ConnectTrees2(100);
        //    ITree tree = SetFire(10, 10);
        //    SetInterval(1000);
        //    int count = 1;
        //    Console.WriteLine($"{count}: ");
        //    Print();

        //    while (true)
        //    {
        //        Console.WriteLine($"{count}: ");
        //        List<ITree> allOnFireTress = new List<ITree>();

        //        for (int i = 0; i < forset.forestTress.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < forset.forestTress.GetLength(1); j++)
        //            {
        //                if (forset.forestTress[i,j].State == State.OnFire)
        //                {
        //                    allOnFireTress.Add(forset.forestTress[i, j]);
        //                }
        //            }
        //        }

        //        allOnFireTress.ForEach(t => t.SetOthersOnFire());
        //        allOnFireTress.ForEach(t => t.DownHealth());
        //        Print();

        //        count++;
        //        Thread.Sleep(_interval);
        //    }
        //}

        public void CreateForset(int row = 20, int column = 20)
        {
            forset = _forsetFactory.CreateForest(row, column);
        }

        public void ConnectTrees(int row, int column, int? success = null)
        {
            for (int i = 0; i < forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < forset.forestTress.GetLength(1); j++)
                {
                    int number = _rand.Next(1, 101);

                    if (number >= 1 && number <= (success))
                    {
                        if (i < forset.forestTress.GetLength(0) - 1)
                        {
                            forset.forestTress[i + 1, j].Subscriber(forset.forestTress[i, j]);
                        }
                        if (j < forset.forestTress.GetLength(1) - 1)
                        {
                            forset.forestTress[i, j + 1].Subscriber(forset.forestTress[i, j]);
                        }
                    }
                }
            }
        }
        public void ConnectTrees2(int? success = null)
        {
            for (int i = 0; i < forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < forset.forestTress.GetLength(1); j++)
                {
                    int number = _rand.Next(1, 101);

                    if (number >= 1 && number <= (success))
                    {
                        if ((i + 1) <= forset.forestTress.GetLength(0) - 1)
                        {
                            forset.forestTress[i + 1, j].Subscriber(forset.forestTress[i, j]);
                        }
                        if ((i -1) >= 0)
                        {
                            forset.forestTress[i -1, j].Subscriber(forset.forestTress[i, j]);
                        }

                        if ((j + 1) <= forset.forestTress.GetLength(1) - 1)
                        {
                            forset.forestTress[i, j + 1].Subscriber(forset.forestTress[i, j]);
                        }
                        if ((j - 1) >= 0)
                        {
                            forset.forestTress[i , j - 1].Subscriber(forset.forestTress[i, j]);
                        }
                    }
                }
            }
        }

        public void UnConnectTrees(int? success = null)
        {
            for (int i = 0; i < forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < forset.forestTress.GetLength(1); j++)
                {
                    int number = _rand.Next(1, 101);

                    if (number >= 1 && number <= (success))
                    {
                        if (j < forset.forestTress.GetLength(1) - 1)
                        {
                            forset.forestTress[i, j + 1].Unsubscriber(forset.forestTress[i, j]);
                        }
                    }
                }
            }
        }

        public ITree SetFire(int index1, int index2)
        {
            if (index1 >= 0 && index1 < forset.forestTress.GetLength(0) && index2 >= 0 && index2 < forset.forestTress.GetLength(1))
            {
                forset.forestTress[index1, index2].TreeSetOnFire();
                return forset.forestTress[index1, index2];
            }
            else
            {
                forset.forestTress[0, 0].TreeSetOnFire();
                return forset.forestTress[0, 0];
            }
        }

       
        public void Print()
        {
            for (int i = 0; i < forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < forset.forestTress.GetLength(1); j++)
                {
                    Console.Write(_stateText[forset.forestTress[i, j].State]);
                }
                Console.WriteLine();
            }
        }
    }
}
