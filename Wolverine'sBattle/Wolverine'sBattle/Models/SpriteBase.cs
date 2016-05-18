using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class SpriteBase
    {
        private const int DefaultMilliSecondsPerFrame = 50;

        private readonly Texture2D textureImage;

        private readonly int collisionOffset;

        private readonly int milliSecondsPerFrame;

        private Point currentFrame;

        private Point sheetSize;

        private int timeSinceLastFrame = 0;

        protected SpriteBase(Texture2D textureImage, Vector2 possition, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
            : this(textureImage, possition, frameSize, collisionOffset, currentFrame, sheetSize, speed, DefaultMilliSecondsPerFrame)
        {
        }

        protected SpriteBase(Texture2D textureImage, Vector2 possition, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int milliSecondsPerFrame)
        {
            this.textureImage = textureImage;
            this.Possition = possition;
            this.FrameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.Speed = speed;
            this.milliSecondsPerFrame = milliSecondsPerFrame;
            this.SpriteEffects = SpriteEffects.None;
        }


        public Vector2 Speed { get; }

        public Point FrameSize { get; }

        public Vector2 Possition { get; set; }

        public SpriteEffects SpriteEffects { get; set; }

        public Vector2 Direction
        {
            get
            {
                return this.GetDirection();
            }
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return this.CreateCollisionRectangle();
            }
        }

        public bool CanProduceNewItems { get; set; }

        protected abstract Vector2 GetDirection();

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            this.timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            this.ProduceAnimation();
        }

        //animation logic
        protected void ProduceAnimation()
        {
            if (this.timeSinceLastFrame > this.milliSecondsPerFrame)
            {
                this.timeSinceLastFrame -= this.milliSecondsPerFrame;
                ++this.currentFrame.X;

                if (this.currentFrame.X >= this.sheetSize.X)
                {
                    this.currentFrame.X = 0;
                    ++this.currentFrame.Y;

                    if (this.currentFrame.Y >= this.sheetSize.Y)
                    {
                        this.currentFrame.Y = 0;
                    }
                }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.textureImage,
                this.Possition,
                new Rectangle(this.currentFrame.X * this.FrameSize.X, this.currentFrame.Y * this.FrameSize.Y, this.FrameSize.X, this.FrameSize.Y),
                Color.White,
                0,
                Vector2.Zero,
                1,
                this.SpriteEffects,
                0);
        }

        private Rectangle CreateCollisionRectangle()
        {
            var rectangle = new Rectangle((int)this.Possition.X + this.collisionOffset, (int)this.Possition.Y + this.collisionOffset, this.FrameSize.X - (this.collisionOffset * 2), this.FrameSize.Y - (this.collisionOffset * 2));

            return rectangle;
        }

    }
}
