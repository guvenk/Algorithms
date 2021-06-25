﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton() { }

        public static Singleton GetInstance() => _instance ??= new Singleton();
    }
}
