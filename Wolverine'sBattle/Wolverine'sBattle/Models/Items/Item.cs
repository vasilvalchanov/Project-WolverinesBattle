using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Items
{
    using System.Runtime.CompilerServices;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Item : MovableObject
    {
        private const int ItemDefaultPossitionY = 0;


        protected Item(Texture2D textureImage, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int healthEffect)
            : base(textureImage, frameSize, collisionOffset, currentFrame, sheetSize, speed)
        {
            this.HealthEffect = healthEffect;
        }

        protected Item(Texture2D textureImage, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int milliSecondsPerFrame, int healthEffect)
            : base(textureImage, frameSize, collisionOffset, currentFrame, sheetSize, speed, milliSecondsPerFrame)
        {
            this.HealthEffect = healthEffect;
        }

        public int HealthEffect { get; protected set; }

    }
}
