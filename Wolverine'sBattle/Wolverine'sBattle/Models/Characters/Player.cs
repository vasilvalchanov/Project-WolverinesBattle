using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;


    public class Player : SpriteBase
    {
        private const float PlayerDefaultSpeedX = 3f;

        private const int PlayerDefaultFrameSizeX = 77;

        private const int PlayerDefaultFrameSizeY = 84;

        private const int PlayerDefaultSheetSizeX = 6;

        private const int PlayerDefaultSheetSizeY = 3;

        private const int PlayerDefaultPossitionX = 25;

        private const int PlayerDefaultPossitionY = 393;

        private const int PlayerDefaultPoints = 0;

        private const int PlayerDefaultHealth = 100;

        private int health;

        public Player(Texture2D textureImage, int collisionOffset, Point currentFrame, int health = PlayerDefaultHealth, int points = PlayerDefaultPoints)
            : base(textureImage, new Vector2(PlayerDefaultPossitionX, PlayerDefaultPossitionY), new Point(PlayerDefaultFrameSizeX, PlayerDefaultFrameSizeY), collisionOffset, currentFrame, new Point(PlayerDefaultSheetSizeX, PlayerDefaultSheetSizeY), new Vector2(PlayerDefaultSpeedX, 0))
        {
            this.Health = health;
            this.Points = points;
        }

        public Player(Texture2D textureImage,  int collisionOffset, Point currentFrame, int milliSecondsPerFrame, int health = PlayerDefaultHealth, int points = PlayerDefaultPoints)
            : base(textureImage, new Vector2(PlayerDefaultPossitionX, PlayerDefaultPossitionY), new Point(PlayerDefaultFrameSizeX, PlayerDefaultFrameSizeY), collisionOffset, currentFrame, new Point(PlayerDefaultSheetSizeX, PlayerDefaultSheetSizeY), new Vector2(PlayerDefaultSpeedX, 0), milliSecondsPerFrame)
        {
            this.Health = health;
            this.Points = points;
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.health = value;
            }
        }

        public int Points { get;  set; }

        public KeyboardState KeyboardState { get; set; }

        // player moving logic
        protected override Vector2 GetDirection()
        {
            Vector2 inputDirection = Vector2.Zero;

            this.KeyboardState = Keyboard.GetState();

            if (this.KeyboardState.IsKeyDown(Keys.Left))
            {
                this.SpriteEffects = SpriteEffects.FlipHorizontally;
                inputDirection.X -= 1;
            }

            if (this.KeyboardState.IsKeyDown(Keys.Right))
            {
                this.SpriteEffects = SpriteEffects.None;
                inputDirection.X += 1;
            }

            return inputDirection * this.Speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            this.Possition += this.Direction;

            if (this.Possition.X < 0)
            {
                this.Possition = new Vector2(0, this.Possition.Y);
            }

            if (this.Possition.X > clientBounds.Width - this.FrameSize.X)
            {
                this.Possition = new Vector2(clientBounds.Width - this.FrameSize.X, this.Possition.Y);
            }

            base.Update(gameTime, clientBounds);
        }

    }
}

