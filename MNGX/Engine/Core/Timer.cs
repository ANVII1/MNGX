using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace MNGX.Engine.Core
{
    public class anTimer
    {
        private float delay;
        private float lastCall;
        public anTimer(float sec) 
        {
            delay = sec;
            lastCall = Globals.TotalGameTime;
        }
        public bool checkDelay() {
            if (delay + lastCall > Globals.TotalGameTime)
                return false;
                
            lastCall = Globals.TotalGameTime;
            return true;    
        } 
    }
}
