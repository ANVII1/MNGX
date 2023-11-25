using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Managers;
using MNGX.Engine.Renderer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static MNGX.Engine.Managers.Events;
using System;
using System.Runtime.CompilerServices;

namespace MNGX.Engine.models
{
    public class Hero : AnimatedGameObject
    {
        private Events.Action actionState;
        private Events.Turn turn;
        private Events.VerrticalMove verticalMoveState;
        public Hero(Vector2 position) 
            : base(position, new Vector2(2, 2))
        {
            colision = true;
            animations = new AnimationManager();

            Texture2D texture = Globals.Content.Load<Texture2D>("textures/HeroAnim");

            animations.AddAnimation("walkLeft", new Animation(texture,6, 4,0.2f, 2));
            animations.AddAnimation("walkRight", new Animation(texture, 6, 4, 0.2f, 4));

            animations.AddAnimation("idleLeft", new Animation(texture, 6, 4, 0.2f,1));
            animations.AddAnimation("idleRight", new Animation(texture, 6, 4, 0.2f, 3));

            this.position = position;

            speed = Vector2.Zero;
            speedlimit.X = 3;
            speedlimit.Y = 20;
            weight = 1.0f;

            verticalMoveState = Events.VerrticalMove.down;
        }
        
        public override void update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                actionState = Events.Action.walk;
                turn = Turn.Left;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                actionState = Events.Action.walk;
                turn = Turn.Right;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (verticalMoveState == Events.VerrticalMove.onGround) {
                    speed.Y = 10.0f;
                    verticalMoveState = Events.VerrticalMove.up;
                }
                    
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                
            }


            if (actionState == Events.Action.walk)
            {
                speed.X += 0.2f;
                    
                if (turn == Events.Turn.Left) {
                    animations.update("walkLeft");
                    position.X -= speed.X;
                }

                if (turn == Events.Turn.Right) {
                    animations.update("walkRight");
                    position.X += speed.X;
                }
            }

// ////////////////////// IDLE
            if (Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D))
                actionState = Events.Action.idle;

            if (actionState == Events.Action.idle) {
                if (turn == Events.Turn.Left)
                    animations.update("idleLeft");
                
                if (turn == Events.Turn.Right)
                    animations.update("idleRight");

                // inert
                if (speed.X > 0)
                    speed.X -= 0.1f;

                // inert cut
                if (speed.X <= 0.2)
                {
                    speed.X = 0;
                }
            }

// ////////////////////// Check Physic
            if (verticalMoveState == Events.VerrticalMove.up)
            {
                position.Y -= speed.Y;
                speed.Y -= 0.3f;
                if (speed.Y <= 0)
                    verticalMoveState = Events.VerrticalMove.down;
            }
            else if (verticalMoveState == Events.VerrticalMove.down)
            {
                speed.Y += 0.3f;
                position.Y += speed.Y;
            }
            else if (verticalMoveState == Events.VerrticalMove.onGround)
                speed.Y = 0;


            if (position.Y >= 350)
                verticalMoveState = Events.VerrticalMove.onGround;

// //////////////////////  Calc limits
            if (speed.X > speedlimit.X)
                speed.X = speedlimit.X;

            if (speed.Y > speedlimit.Y)
                speed.Y = speedlimit.Y;
        }
        void shoot() 
        {
            
        }

    }
}
 