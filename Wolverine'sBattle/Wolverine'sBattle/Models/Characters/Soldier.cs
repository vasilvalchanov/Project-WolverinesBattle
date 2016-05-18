using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Soldier : Character
    {

        private const float SoldierDefaultSpeedY = 2f;

        private const int SoldierDefaultFrameSizeX = 46;

        private const int SoldierDefaultFrameSizeY = 70;

        private const int SoldierDefaultSheetSizeX = 7;

        private const int SoldierDefaultSheetSizeY = 1;


        public Soldier(Texture2D textureImage, int collisionOffset, Point currentFrame, int health, int points)
            : base(textureImage, new Point(SoldierDefaultFrameSizeX, SoldierDefaultFrameSizeY), collisionOffset, currentFrame, new Point(SoldierDefaultSheetSizeX, SoldierDefaultSheetSizeY), new Vector2(0, SoldierDefaultSpeedY), health, points)
        {
        }

        public Soldier(Texture2D textureImage, int collisionOffset, Point currentFrame, int milliSecondsPerFrame, int health, int points)
            : base(textureImage, new Point(SoldierDefaultFrameSizeX, SoldierDefaultFrameSizeY), collisionOffset, currentFrame, new Point(SoldierDefaultSheetSizeX, SoldierDefaultSheetSizeY), new Vector2(0, SoldierDefaultSpeedY), milliSecondsPerFrame, health, points)
        {
        }
    }
}
