using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Apple : Item
    {
        private const int AppleDefaultFrameX = 30;

        private const int AppleDefaultFrameY = 36;

        private const float AppleDefaultSpeedY = 1f;

        private const int AppleHealthPoints = 10;


        public Apple(Texture2D textureImage, int collisionOffset, Point currentFrame, Point sheetSize)
            : base(textureImage,  new Point(AppleDefaultFrameX, AppleDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, AppleDefaultSpeedY), AppleHealthPoints)
        {
        }

        public Apple(Texture2D textureImage, int collisionOffset, Point currentFrame, Point sheetSize, int milliSecondsPerFrame)
            : base(textureImage, new Point(AppleDefaultFrameX, AppleDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, AppleDefaultSpeedY), milliSecondsPerFrame, AppleHealthPoints)
        {
        }
    }
}
