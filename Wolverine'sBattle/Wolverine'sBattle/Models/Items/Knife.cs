using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Knife : Item
    {
        private const int KnifeDefaultFrameX = 20;

        private const int KnifeDefaultFrameY = 57;

        private const float KnifeDefaultSpeedY = 1f;

        private const int KnifeHealthPoints = -15;


        public Knife(Texture2D textureImage,  int collisionOffset, Point currentFrame, Point sheetSize)
            : base(textureImage,  new Point(KnifeDefaultFrameX, KnifeDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, KnifeDefaultSpeedY), KnifeHealthPoints)
        {
        }

        public Knife(Texture2D textureImage, int collisionOffset, Point currentFrame, Point sheetSize, int milliSecondsPerFrame)
            : base(textureImage, new Point(KnifeDefaultFrameX, KnifeDefaultFrameY), collisionOffset, currentFrame, sheetSize, new Vector2(0, KnifeDefaultSpeedY), milliSecondsPerFrame, KnifeHealthPoints)
        {
        }
      
    }
}
