﻿using System;
using System.Collections.Generic;
using Alkaid;

namespace Rosetta
{
    public class Rosetta : Singleton<Rosetta>
    {
        public bool Init(Callback setupWithUnity)
        {
            if (setupWithUnity == null)
            {
                setupWithUnity = RosettaSetup.Instance.SetupWithUnity;
            }
            FrameworkSetup.Instance.RegisterSetupFromUnity(setupWithUnity);
            FrameworkSetup.Instance.RegisterSetupFromPorject(RosettaSetup.Instance.SetupWithProject);

            return true;
        }

        public void StartApp()
        {
            Framework.Instance.Start();
        }

        public void StopApp()
        {
            Framework.Instance.Stop();
        }























        public int GetRandomNum100()
        {
            Random r = new Random(DateTime.Now.Second);
            return r.Next(100);
        }

        public int GetRandomNum1000()
        {
            MyRandom r = new MyRandom();
            return r.GetRandomNum1000();
        }
    }
}


