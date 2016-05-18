using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Models.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BlackDragon : Character
    {
        
        private const float DragonDefaultSpeedY = 3f;

        private const int DragonDefaultFrameSizeX = 122; 

        private const int DragonDefaultFrameSizeY = 105;  

        private const int DragonDefaultSheetSizeX = 4;

        private const int DragonDefaultSheetSizeY = 2;


        public BlackDragon(Texture2D textureImage, int collisionOffset, Point currentFrame, int health, int points)
            : base(textureImage, new Point(DragonDefaultFrameSizeX, DragonDefaultFrameSizeY), collisionOffset, currentFrame, new Point(DragonDefaultSheetSizeX, DragonDefaultSheetSizeY), new Vector2(0, DragonDefaultSpeedY), health, points)
        {
        }

        public BlackDragon(Texture2D textureImage, int collisionOffset, Point currentFrame, int milliSecondsPerFrame, int health, int points)
            : base(textureImage, new Point(DragonDefaultFrameSizeX, DragonDefaultFrameSizeY), collisionOffset, currentFrame, new Point(DragonDefaultSheetSizeX, DragonDefaultSheetSizeY), new Vector2(0, DragonDefaultSpeedY), milliSecondsPerFrame, health, points)
        {
        }
    }
}
