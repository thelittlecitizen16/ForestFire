using ForestFire.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Timer = System.Timers.Timer;


namespace ForestFire
{
    public class RunForset
    {
        private ForsetHandler _forsetHandler;

        public RunForset(ForsetHandler forsetHandler)
        {
            _forsetHandler = forsetHandler;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            List<ITree> allOnFireTress = new List<ITree>();

            for (int i = 0; i < _forsetHandler.Forset.forestTress.GetLength(0); i++)
            {
                for (int j = 0; j < _forsetHandler.Forset.forestTress.GetLength(1); j++)
                {
                    if (_forsetHandler.Forset.forestTress[i, j].State == State.OnFire)
                    {
                        allOnFireTress.Add(_forsetHandler.Forset.forestTress[i, j]);
                    }
                }
            }

            allOnFireTress.ForEach(t => t.SetOthersOnFire());
            allOnFireTress.ForEach(t => t.DownHealth());

            Console.WriteLine($"......");
            _forsetHandler.Print();
        }

        public void Bootstrapping()
        {
            _forsetHandler.CreateForset();
            _forsetHandler.ConnectTrees(60);
            ITree tree = _forsetHandler.SetFire(10, 10);
            _forsetHandler.Print();

            var aTimer = new Timer(1000);

            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

    }
}
