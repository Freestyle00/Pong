#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace PongNewTry.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static Microsoft.Xna.Framework.Audio.SoundEffect pongsound;
        
        private PongNewTry.Entities.PongBall PongBallInstance;
        private PongNewTry.Entities.Border1 Border1Instance;
        private PongNewTry.Entities.Border2 Border2Instance;
        private PongNewTry.Entities.Border3 Border3Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border1> PongBallInstanceVsBorder1Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border2> PongBallInstanceVsBorder2Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border3> PongBallInstanceVsBorder3Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border> PongBallInstanceVsBorderInstance;
        private PongNewTry.Entities.Player1 Player1Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.Player1, PongNewTry.Entities.PongBall> Player1InstanceVsPongBallInstance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.Player1, PongNewTry.Entities.Border2> Player1InstanceVsBorder2Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.Player1, PongNewTry.Entities.Border3> Player1InstanceVsBorder3Instance;
        private PongNewTry.Entities.Player2 Player2Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.Player2, PongNewTry.Entities.Border2> Player2InstanceVsBorder2Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.Player2, PongNewTry.Entities.Border3> Player2InstanceVsBorder3Instance;
        private FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.PongBall, PongNewTry.Entities.Player2> PongBallInstanceVsPlayer2Instance;
        private PongNewTry.Entities.HUD HUDInstance;
        private PongNewTry.Entities.HUD2 HUD2Instance;
        public event System.Action<PongNewTry.Entities.Player1, PongNewTry.Entities.PongBall> Player1InstanceVsPongBallInstanceCollisionOccurred;
        public event System.Action<PongNewTry.Entities.PongBall, PongNewTry.Entities.Player2> PongBallInstanceVsPlayer2InstanceCollisionOccurred;
        public event System.Action<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border1> PongBallInstanceVsBorder1InstanceCollisionOccurred;
        public event System.Action<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border2> PongBallInstanceVsBorder2InstanceCollisionOccurred;
        public event System.Action<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border3> PongBallInstanceVsBorder3InstanceCollisionOccurred;
        public event EventHandler PongBallInstanceVsBorderInstanceCollisionOccurred;
        public GameScreen () 
        	: base ("GameScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            PongBallInstance = new PongNewTry.Entities.PongBall(ContentManagerName, false);
            PongBallInstance.Name = "PongBallInstance";
            Border1Instance = new PongNewTry.Entities.Border1(ContentManagerName, false);
            Border1Instance.Name = "Border1Instance";
            Border2Instance = new PongNewTry.Entities.Border2(ContentManagerName, false);
            Border2Instance.Name = "Border2Instance";
            Border3Instance = new PongNewTry.Entities.Border3(ContentManagerName, false);
            Border3Instance.Name = "Border3Instance";
            Player1Instance = new PongNewTry.Entities.Player1(ContentManagerName, false);
            Player1Instance.Name = "Player1Instance";
            Player2Instance = new PongNewTry.Entities.Player2(ContentManagerName, false);
            Player2Instance.Name = "Player2Instance";
            HUDInstance = new PongNewTry.Entities.HUD(ContentManagerName, false);
            HUDInstance.Name = "HUDInstance";
            HUD2Instance = new PongNewTry.Entities.HUD2(ContentManagerName, false);
            HUD2Instance.Name = "HUD2Instance";
            // Not instantiating for  Border1Instance2 in Screens\GameScreen (Screen) because properties on the object prevent it
                PongBallInstanceVsBorder1Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(PongBallInstance, Border1Instance);
    PongBallInstanceVsBorder1Instance.Name = "PongBallInstanceVsBorder1Instance";
    PongBallInstanceVsBorder1Instance.SetBounceCollision(0f, 1f, 2f);

                PongBallInstanceVsBorder2Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(PongBallInstance, Border2Instance);
    PongBallInstanceVsBorder2Instance.Name = "PongBallInstanceVsBorder2Instance";
    PongBallInstanceVsBorder2Instance.SetBounceCollision(0f, 1f, 2f);

                PongBallInstanceVsBorder3Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(PongBallInstance, Border3Instance);
    PongBallInstanceVsBorder3Instance.Name = "PongBallInstanceVsBorder3Instance";
    PongBallInstanceVsBorder3Instance.SetBounceCollision(0f, 1f, 2f);

            PongBallInstanceVsBorderInstance = new FlatRedBall.Math.Collision.CollisionRelationship<PongNewTry.Entities.PongBall, PongNewTry.Entities.Border>();
            PongBallInstanceVsBorderInstance.Name = "PongBallInstanceVsBorderInstance";
                Player1InstanceVsPongBallInstance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(Player1Instance, PongBallInstance);
    Player1InstanceVsPongBallInstance.Name = "Player1InstanceVsPongBallInstance";
    Player1InstanceVsPongBallInstance.SetBounceCollision(1f, 0f, 2f);

                Player1InstanceVsBorder2Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(Player1Instance, Border2Instance);
    Player1InstanceVsBorder2Instance.Name = "Player1InstanceVsBorder2Instance";
    Player1InstanceVsBorder2Instance.SetMoveCollision(0f, 1f);

                Player1InstanceVsBorder3Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(Player1Instance, Border3Instance);
    Player1InstanceVsBorder3Instance.Name = "Player1InstanceVsBorder3Instance";
    Player1InstanceVsBorder3Instance.SetMoveCollision(0f, 1f);

                Player2InstanceVsBorder2Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(Player2Instance, Border2Instance);
    Player2InstanceVsBorder2Instance.Name = "Player2InstanceVsBorder2Instance";
    Player2InstanceVsBorder2Instance.SetMoveCollision(0f, 1f);

                Player2InstanceVsBorder3Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(Player2Instance, Border3Instance);
    Player2InstanceVsBorder3Instance.Name = "Player2InstanceVsBorder3Instance";
    Player2InstanceVsBorder3Instance.SetMoveCollision(0f, 1f);

                PongBallInstanceVsPlayer2Instance = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(PongBallInstance, Player2Instance);
    PongBallInstanceVsPlayer2Instance.Name = "PongBallInstanceVsPlayer2Instance";
    PongBallInstanceVsPlayer2Instance.SetBounceCollision(0f, 1f, 2f);

            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            PongBallInstance.AddToManagers(mLayer);
            Border1Instance.AddToManagers(mLayer);
            Border2Instance.AddToManagers(mLayer);
            Border3Instance.AddToManagers(mLayer);
            Player1Instance.AddToManagers(mLayer);
            Player2Instance.AddToManagers(mLayer);
            HUDInstance.AddToManagers(mLayer);
            HUD2Instance.AddToManagers(mLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                PongBallInstance.Activity();
                Border1Instance.Activity();
                Border2Instance.Activity();
                Border3Instance.Activity();
                Player1Instance.Activity();
                Player2Instance.Activity();
                HUDInstance.Activity();
                HUD2Instance.Activity();
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            pongsound = null;
            
            if (PongBallInstance != null)
            {
                PongBallInstance.Destroy();
                PongBallInstance.Detach();
            }
            if (Border1Instance != null)
            {
                Border1Instance.Destroy();
                Border1Instance.Detach();
            }
            if (Border2Instance != null)
            {
                Border2Instance.Destroy();
                Border2Instance.Detach();
            }
            if (Border3Instance != null)
            {
                Border3Instance.Destroy();
                Border3Instance.Detach();
            }
            if (Player1Instance != null)
            {
                Player1Instance.Destroy();
                Player1Instance.Detach();
            }
            if (Player2Instance != null)
            {
                Player2Instance.Destroy();
                Player2Instance.Detach();
            }
            if (HUDInstance != null)
            {
                HUDInstance.Destroy();
                HUDInstance.Detach();
            }
            if (HUD2Instance != null)
            {
                HUD2Instance.Destroy();
                HUD2Instance.Detach();
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            Player1InstanceVsPongBallInstance.CollisionOccurred += OnPlayer1InstanceVsPongBallInstanceCollisionOccurred;
            Player1InstanceVsPongBallInstance.CollisionOccurred += OnPlayer1InstanceVsPongBallInstanceCollisionOccurredTunnel;
            PongBallInstanceVsPlayer2Instance.CollisionOccurred += OnPongBallInstanceVsPlayer2InstanceCollisionOccurred;
            PongBallInstanceVsPlayer2Instance.CollisionOccurred += OnPongBallInstanceVsPlayer2InstanceCollisionOccurredTunnel;
            PongBallInstanceVsBorder1Instance.CollisionOccurred += OnPongBallInstanceVsBorder1InstanceCollisionOccurred;
            PongBallInstanceVsBorder1Instance.CollisionOccurred += OnPongBallInstanceVsBorder1InstanceCollisionOccurredTunnel;
            PongBallInstanceVsBorder2Instance.CollisionOccurred += OnPongBallInstanceVsBorder2InstanceCollisionOccurred;
            PongBallInstanceVsBorder2Instance.CollisionOccurred += OnPongBallInstanceVsBorder2InstanceCollisionOccurredTunnel;
            PongBallInstanceVsBorder3Instance.CollisionOccurred += OnPongBallInstanceVsBorder3InstanceCollisionOccurred;
            PongBallInstanceVsBorder3Instance.CollisionOccurred += OnPongBallInstanceVsBorder3InstanceCollisionOccurredTunnel;
            PongBallInstanceVsBorderInstance.CollisionOccurred += OnPongBallInstanceVsBorderInstanceCollisionOccurred;
            PongBallInstanceVsBorderInstance.CollisionOccurred += OnPongBallInstanceVsBorderInstanceCollisionOccurredTunnel;
            if (PongBallInstance.Parent == null)
            {
                PongBallInstance.X = 0f;
            }
            else
            {
                PongBallInstance.RelativeX = 0f;
            }
            if (PongBallInstance.Parent == null)
            {
                PongBallInstance.Y = 0f;
            }
            else
            {
                PongBallInstance.RelativeY = 0f;
            }
            if (PongBallInstance.Parent == null)
            {
                PongBallInstance.Z = 0f;
            }
            else
            {
                PongBallInstance.RelativeZ = 0f;
            }
            if (Border1Instance.Parent == null)
            {
                Border1Instance.X = -250f;
            }
            else
            {
                Border1Instance.RelativeX = -250f;
            }
            if (Border1Instance.Parent == null)
            {
                Border1Instance.Y = 0f;
            }
            else
            {
                Border1Instance.RelativeY = 0f;
            }
            if (Border2Instance.Parent == null)
            {
                Border2Instance.Y = 125f;
            }
            else
            {
                Border2Instance.RelativeY = 125f;
            }
            if (Border3Instance.Parent == null)
            {
                Border3Instance.Y = -125f;
            }
            else
            {
                Border3Instance.RelativeY = -125f;
            }
            if (Player1Instance.Parent == null)
            {
                Player1Instance.X = 110f;
            }
            else
            {
                Player1Instance.RelativeX = 110f;
            }
            if (Player2Instance.Parent == null)
            {
                Player2Instance.X = -110f;
            }
            else
            {
                Player2Instance.RelativeX = -110f;
            }
            if (HUDInstance.Parent == null)
            {
                HUDInstance.X = 40f;
            }
            else
            {
                HUDInstance.RelativeX = 40f;
            }
            if (HUDInstance.Parent == null)
            {
                HUDInstance.Y = 80f;
            }
            else
            {
                HUDInstance.RelativeY = 80f;
            }
            if (HUD2Instance.Parent == null)
            {
                HUD2Instance.X = -90f;
            }
            else
            {
                HUD2Instance.RelativeX = -90f;
            }
            if (HUD2Instance.Parent == null)
            {
                HUD2Instance.Y = 80f;
            }
            else
            {
                HUD2Instance.RelativeY = 80f;
            }
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            PongBallInstance.RemoveFromManagers();
            Border1Instance.RemoveFromManagers();
            Border2Instance.RemoveFromManagers();
            Border3Instance.RemoveFromManagers();
            Player1Instance.RemoveFromManagers();
            Player2Instance.RemoveFromManagers();
            HUDInstance.RemoveFromManagers();
            HUD2Instance.RemoveFromManagers();
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                PongBallInstance.AssignCustomVariables(true);
                Border1Instance.AssignCustomVariables(true);
                Border2Instance.AssignCustomVariables(true);
                Border3Instance.AssignCustomVariables(true);
                Player1Instance.AssignCustomVariables(true);
                Player2Instance.AssignCustomVariables(true);
                HUDInstance.AssignCustomVariables(true);
                HUD2Instance.AssignCustomVariables(true);
            }
            if (PongBallInstance.Parent == null)
            {
                PongBallInstance.X = 0f;
            }
            else
            {
                PongBallInstance.RelativeX = 0f;
            }
            if (PongBallInstance.Parent == null)
            {
                PongBallInstance.Y = 0f;
            }
            else
            {
                PongBallInstance.RelativeY = 0f;
            }
            if (PongBallInstance.Parent == null)
            {
                PongBallInstance.Z = 0f;
            }
            else
            {
                PongBallInstance.RelativeZ = 0f;
            }
            if (Border1Instance.Parent == null)
            {
                Border1Instance.X = -250f;
            }
            else
            {
                Border1Instance.RelativeX = -250f;
            }
            if (Border1Instance.Parent == null)
            {
                Border1Instance.Y = 0f;
            }
            else
            {
                Border1Instance.RelativeY = 0f;
            }
            if (Border2Instance.Parent == null)
            {
                Border2Instance.Y = 125f;
            }
            else
            {
                Border2Instance.RelativeY = 125f;
            }
            if (Border3Instance.Parent == null)
            {
                Border3Instance.Y = -125f;
            }
            else
            {
                Border3Instance.RelativeY = -125f;
            }
            if (Player1Instance.Parent == null)
            {
                Player1Instance.X = 110f;
            }
            else
            {
                Player1Instance.RelativeX = 110f;
            }
            if (Player2Instance.Parent == null)
            {
                Player2Instance.X = -110f;
            }
            else
            {
                Player2Instance.RelativeX = -110f;
            }
            if (HUDInstance.Parent == null)
            {
                HUDInstance.X = 40f;
            }
            else
            {
                HUDInstance.RelativeX = 40f;
            }
            if (HUDInstance.Parent == null)
            {
                HUDInstance.Y = 80f;
            }
            else
            {
                HUDInstance.RelativeY = 80f;
            }
            if (HUD2Instance.Parent == null)
            {
                HUD2Instance.X = -90f;
            }
            else
            {
                HUD2Instance.RelativeX = -90f;
            }
            if (HUD2Instance.Parent == null)
            {
                HUD2Instance.Y = 80f;
            }
            else
            {
                HUD2Instance.RelativeY = 80f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            PongBallInstance.ConvertToManuallyUpdated();
            Border1Instance.ConvertToManuallyUpdated();
            Border2Instance.ConvertToManuallyUpdated();
            Border3Instance.ConvertToManuallyUpdated();
            Player1Instance.ConvertToManuallyUpdated();
            Player2Instance.ConvertToManuallyUpdated();
            HUDInstance.ConvertToManuallyUpdated();
            HUD2Instance.ConvertToManuallyUpdated();
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            pongsound = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/screens/gamescreen/pongsound", contentManagerName);
            PongNewTry.Entities.PongBall.LoadStaticContent(contentManagerName);
            PongNewTry.Entities.Border1.LoadStaticContent(contentManagerName);
            PongNewTry.Entities.Border2.LoadStaticContent(contentManagerName);
            PongNewTry.Entities.Border3.LoadStaticContent(contentManagerName);
            PongNewTry.Entities.Player1.LoadStaticContent(contentManagerName);
            PongNewTry.Entities.Player2.LoadStaticContent(contentManagerName);
            PongNewTry.Entities.HUD.LoadStaticContent(contentManagerName);
            PongNewTry.Entities.HUD2.LoadStaticContent(contentManagerName);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "pongsound":
                    return pongsound;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "pongsound":
                    return pongsound;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "pongsound":
                    return pongsound;
            }
            return null;
        }
    }
}
