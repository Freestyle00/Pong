using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;

namespace PongNewTry.Entities
{
    public partial class Player1
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        /// 
        public I2DInput MovementInput { get; set; }
        public IPressableInput BoostInput { get; set; }
        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {
            if (MovementInput != null)
            {
                float movementSpeed = 290;
                //this.XVelocity = MovementInput.X * movementSpeed;
                this.YVelocity = MovementInput.Y * movementSpeed;
            }

        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}
