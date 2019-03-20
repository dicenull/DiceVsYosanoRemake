﻿using DxLibUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceVsYosanoRemake.Scenes
{
    struct MyData
    {
        public Mode GameMode { get; set; }

        public int Winner { get; set; }

        public Audio TitleMusic { get; set; }

        public Audio MainMusic { get; set; }
    }
}
