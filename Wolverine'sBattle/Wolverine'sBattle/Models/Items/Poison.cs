using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Poison : Item
    {
        private const int PoisonDefaultFrameX = 30;

        private const int PoisonDefaultFrameY = 54;

        private const float PoisonDefaultSpeedY = 2f;

        private const int PoisonHealthPoints = -50;


        public Poison(Texture2D textureImage, int collisionOffset, Point currentFrame, Point sheetSize)
            : base(textureImage,  new Point(PoisonDefaultFrameX, PoisonDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, PoisonDefaultSpeedY), PoisonHealthPoints)
        {
        }

        public Poison(Texture2D textureImage, int collisionOffset, Point currentFrame, Point sheetSize, int milliSecondsPerFrame)
            : base(textureImage, new Point(PoisonDefaultFrameX, PoisonDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, PoisonDefaultSpeedY), milliSecondsPerFrame, PoisonHealthPoints)
        {
        }
    }
}
