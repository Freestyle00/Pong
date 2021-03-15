using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using PongNewTry.Entities;
using PongNewTry.Screens;
namespace PongNewTry.Screens
{
    public partial class GameScreen
    {
        void OnPlayer1InstanceVsPongBallInstanceCollisionOccurredTunnel (PongNewTry.Entities.Player1 first, PongNewTry.Entities.PongBall second) 
        {
            if (this.Player1InstanceVsPongBallInstanceCollisionOccurred != null)
            {
                Player1InstanceVsPongBallInstanceCollisionOccurred(first, second);
            }
        }
        void OnPongBallInstanceVsPlayer2InstanceCollisionOccurredTunnel (PongNewTry.Entities.PongBall first, PongNewTry.Entities.Player2 second) 
        {
            if (this.PongBallInstanceVsPlayer2InstanceCollisionOccurred != null)
            {
                PongBallInstanceVsPlayer2InstanceCollisionOccurred(first, second);
            }
        }
        void OnPongBallInstanceVsBorder1InstanceCollisionOccurredTunnel (PongNewTry.Entities.PongBall first, PongNewTry.Entities.Border1 second) 
        {
            if (this.PongBallInstanceVsBorder1InstanceCollisionOccurred != null)
            {
                PongBallInstanceVsBorder1InstanceCollisionOccurred(first, second);
            }
        }
        void OnPongBallInstanceVsBorder2InstanceCollisionOccurredTunnel (PongNewTry.Entities.PongBall first, PongNewTry.Entities.Border2 second) 
        {
            if (this.PongBallInstanceVsBorder2InstanceCollisionOccurred != null)
            {
                PongBallInstanceVsBorder2InstanceCollisionOccurred(first, second);
            }
        }
        void OnPongBallInstanceVsBorder3InstanceCollisionOccurredTunnel (PongNewTry.Entities.PongBall first, PongNewTry.Entities.Border3 second) 
        {
            if (this.PongBallInstanceVsBorder3InstanceCollisionOccurred != null)
            {
                PongBallInstanceVsBorder3InstanceCollisionOccurred(first, second);
            }
        }
        void OnPongBallInstanceVsBorderInstanceCollisionOccurredTunnel (PongNewTry.Entities.PongBall first, PongNewTry.Entities.Border second) 
        {
            if (this.PongBallInstanceVsBorderInstanceCollisionOccurred != null)
            {
                PongBallInstanceVsBorderInstanceCollisionOccurred(first, second);
            }
        }
    }
}
