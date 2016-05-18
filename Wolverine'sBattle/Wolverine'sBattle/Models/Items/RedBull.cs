using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RedBull : Item
    {
        private const int RedBullDefaultFrameX = 24;

        private const int RedBullDefaultFrameY = 60;

        private const float RedBullDefaultSpeedY = 2f;

        private const int RedBullHealthPoints = 30;


        public RedBull(Texture2D textureImage, int collisionOffset, Point currentFrame, Point sheetSize)
            : base(textureImage,  new Point(RedBullDefaultFrameX, RedBullDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, RedBullDefaultSpeedY), RedBullHealthPoints)
        {
        }

        public RedBull(Texture2D textureImage, int collisionOffset, Point currentFrame, Point sheetSize, int milliSecondsPerFrame)
            : base(textureImage,  new Point(RedBullDefaultFrameX, RedBullDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, RedBullDefaultSpeedY), milliSecondsPerFrame, RedBullHealthPoints)
        {
        }
    }
}
