using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class MovableObject : SpriteBase
    {
        private const int ItemDefaultPossitionY = 0;

        protected MovableObject(Texture2D textureImage, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureImage, new Vector2(CreateRandomPossitionX(), ItemDefaultPossitionY), frameSize, collisionOffset, currentFrame, sheetSize, speed)
        {
        }

        protected MovableObject(Texture2D textureImage, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int milliSecondsPerFrame)
            : base(textureImage, new Vector2(CreateRandomPossitionX(), ItemDefaultPossitionY), frameSize, collisionOffset, currentFrame, sheetSize, speed, milliSecondsPerFrame)
        {
        }

        protected override Vector2 GetDirection()
        {
            return this.Speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            if (this.CanProduceNewItems)
            {
                this.Possition = new Vector2(CreateRandomPossitionX(), ItemDefaultPossitionY);
                this.CanProduceNewItems = false;
            }

            this.Possition += this.Direction;

            if (this.Possition.Y > clientBounds.Height - this.FrameSize.Y)
            {
                this.CanProduceNewItems = true;
            }

            base.Update(gameTime, clientBounds);
        }

        public static int CreateRandomPossitionX()
        {
            var randomGenerator = new Random(Guid.NewGuid().GetHashCode());

            var possitionX = randomGenerator.Next(0, 780);

            return possitionX;
        }
    }
}
