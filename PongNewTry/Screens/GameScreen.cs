using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;



namespace PongNewTry.Screens
{
    public partial class GameScreen
    {

        void CustomInitialize()
        {
            PongBallInstance.Velocity.X = 100;
            PongBallInstance.Velocity.Y = 30;
            Player1Instance.MovementInput = InputManager.Keyboard.Get2DInput(Microsoft.Xna.Framework.Input.Keys.None ,Microsoft.Xna.Framework.Input.Keys.None,Microsoft.Xna.Framework.Input.Keys.Up,Microsoft.Xna.Framework.Input.Keys.Down);
            Player2Instance.MovementInput = InputManager.Keyboard.Get2DInput(Microsoft.Xna.Framework.Input.Keys.None, Microsoft.Xna.Framework.Input.Keys.None, Microsoft.Xna.Framework.Input.Keys.W, Microsoft.Xna.Framework.Input.Keys.S);
        }
        void CustomActivity(bool firstTimeCalled)
        {
            VelocityNullifier();
            //pongsound.Play();
            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                if (this.IsPaused)
                {
                    UnpauseThisScreen();
                }
                else
                {
                    PauseThisScreen();
                }
            }
            AIforsingleplayer();
        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }


        
        void VelocityNullifier()// TODO implement a score HUD and that the ball will move vertically as soon as it hits the player so that it will not ba an straightforward game but also the ball will move
         {
            Border1Instance.Velocity.X = 0;
            Border1Instance.Velocity.Y = 0;
            Border2Instance.Velocity.X = 0;
            Border2Instance.Velocity.Y = 0;
            Border3Instance.Velocity.X = 0;
            Border3Instance.Velocity.Y = 0;
            BorderInstance.Velocity.X = 0;
            BorderInstance.Velocity.Y = 0;
            Player1Instance.Velocity.X = 0;
            Player2Instance.Velocity.X = 0;
            if (PongBallInstance.Velocity.X >= 480)
            {
                PongBallInstance.Velocity.X = 450;
            }
            if (PongBallInstance.Velocity.Y >= 300)
            {
                PongBallInstance.Velocity.Y = 290;
            }
        }
        void AIforsingleplayer()
        {
          Player2Instance.Y = PongBallInstance.Y;
        }
    }
}
