using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Wolverine_sBattle_MyFirstRPGGame.Models.Items;

    public abstract class Character : MovableObject
    {

        protected Character(Texture2D textureImage, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int health,  int pointsToGive)
            : base(textureImage, frameSize, collisionOffset, currentFrame, sheetSize, speed)
        {
            this.Health = health;
            this.PointsToGive = pointsToGive;
        }

        protected Character(Texture2D textureImage, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,  int milliSecondsPerFrame, int health, int pointsToGive)
            : base(textureImage, frameSize, collisionOffset, currentFrame, sheetSize, speed, milliSecondsPerFrame)
        {
            this.Health = health;
            this.PointsToGive = pointsToGive;
        }


        public int PointsToGive { get; protected set; }

        public int Health { get; protected set; }

    }
}
