using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNGX.Engine.Managers;

public static class Events
{
    public enum Action 
    { 
        idle, walk, jump, shoot
    }
    public enum VerrticalMove
    {
        onGround, up, down
    }
    public enum Turn
    {
        Left, Right
    }
}
