using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolverine_sBattle_MyFirstRPGGame.Core
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Wolverine_sBattle_MyFirstRPGGame.Core.Enums;
    using Wolverine_sBattle_MyFirstRPGGame.Models;
    using Wolverine_sBattle_MyFirstRPGGame.Models.Characters;
    using Wolverine_sBattle_MyFirstRPGGame.Models.Items;

    public class Engine : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private Player player;

        private SpriteFont healthFont;

        private SpriteFont gameOverFont;

        private GameState gameState;

        private List<MovableObject> movableObjects;


        public Engine(Game game)
            : base(game)
        {         
        }

        public override void Initialize()
        {
            this.gameState = GameState.Paused;
            this.movableObjects = new List<MovableObject>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.healthFont = this.Game.Content.Load<SpriteFont>("HealthAndPointsFont");
            this.gameOverFont = this.Game.Content.Load<SpriteFont>("GameOverFont");

            this.player = new Player(this.Game.Content.Load<Texture2D>(@"Images/wolverine_sprites.png"), 5, new Point(0, 0));
            this.movableObjects.Add(new Knife(this.Game.Content.Load<Texture2D>(@"Images/knife.png"), 5, new Point(0, 0), new Point(1, 0)));
            this.movableObjects.Add(new Apple(this.Game.Content.Load<Texture2D>(@"Images/red_apple_310910.png"), 5, new Point(0, 0), new Point(1, 0)));
            this.movableObjects.Add(new Poison(this.Game.Content.Load<Texture2D>(@"Images/poison.png"), 5, new Point(0, 0), new Point(1, 0)));
            this.movableObjects.Add(new RedBull(this.Game.Content.Load<Texture2D>(@"Images/red bull.jpg"), 5, new Point(0, 0), new Point(1, 0)));
            this.movableObjects.Add(new BlackDragon(this.Game.Content.Load<Texture2D>(@"Images/BlackDragon.png"), 5, new Point(0, 0), 70, 100, 20));
            this.movableObjects.Add(new MorvaDragon(this.Game.Content.Load<Texture2D>(@"Images/morvaDragon.png"), 5, new Point(0, 0), 70, 120, 25));
            this.movableObjects.Add(new Soldier(this.Game.Content.Load<Texture2D>(@"Images/soldier1.png"), 5, new Point(0, 0), 70, 80, 15));


            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                this.gameState = GameState.Running;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                this.RestarGame();
            }

            if (this.gameState == GameState.Running)
            {
                this.player.Update(gameTime, this.Game.Window.ClientBounds);

                foreach (var movableObject in this.movableObjects)
                {
                    movableObject.Update(gameTime, this.Game.Window.ClientBounds);

                    if (movableObject.CollisionRectangle.Intersects(this.player.CollisionRectangle))
                    {
                        if (movableObject is Character)
                        {
                            this.PerformTheBattle(movableObject as Character);
                            movableObject.Possition = new Vector2(MovableObject.CreateRandomPossitionX(), 0);

                            if (this.player.Health <= 0)
                            {
                                this.gameState = GameState.Paused;
                            }

                            if (this.player.Points >= 500)
                            {
                                this.gameState = GameState.Paused;
                            }
                        }

                        if (movableObject is Item)
                        {
                            this.ApplyItemEffect(movableObject as Item);
                            movableObject.Possition = new Vector2(MovableObject.CreateRandomPossitionX(), 0);

                        }
                    }
                }
            }

            if (this.player.KeyboardState.IsKeyDown(Keys.P))
            {

                this.gameState = GameState.Paused;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            if (this.player.Health > 0 && this.gameState == GameState.Paused && this.player.Points < 500)
            {
                this.spriteBatch.DrawString(this.gameOverFont, "The goal of the game is to defeat enemies and to collect points", new Vector2(5, 70), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "If you reach score 500, you win. If your health is more than", new Vector2(5, 95), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "enemy health, you win the battle and collect points from enemy,", new Vector2(5, 120), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "otherwise you lose the battle and the game is over.", new Vector2(5, 145), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "Black Dragon: Health 100, Points 20", new Vector2(5, 170), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "Grey Dragon: Health 120, Points 25", new Vector2(5, 195), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "Soldier: Health 80, Points 15", new Vector2(5, 220), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "Apple - give you 10 health     Red Bull - give you 30 health", new Vector2(5, 245), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "Knife - take you 15 health     Poison - take you 50 health", new Vector2(5, 270), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "The poison and the knife cannot kill you, even if you have a few", new Vector2(5, 295), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "health points. They only reduce your health.", new Vector2(5, 320), Color.Black);
                this.spriteBatch.DrawString(this.gameOverFont, "Key \"C\" - Continue, Key \"P\" - Pause, Key \"Enter\" Restart", new Vector2(5, 345), Color.Black);
            }

            this.spriteBatch.DrawString(this.healthFont, "Health: " + this.player.Health, new Vector2(1, 1), Color.Black);
            this.spriteBatch.DrawString(this.healthFont, "Score: " + this.player.Points, new Vector2(1, 20), Color.Black);

            if (this.player.Health <= 0)
            {
                this.spriteBatch.DrawString(this.gameOverFont, "             GAME OVER!\n              Your Score: " + this.player.Points + "\nPress \"Enter\" to Restart the Game", new Vector2(180, 200), Color.Black);
            }

            if (this.player.Points >= 500)
            {
                this.spriteBatch.DrawString(this.gameOverFont, "                   You Won!\n              Your Score: " + this.player.Points + "\nPress \"Enter\" to Restart the Game", new Vector2(180, 200), Color.Black);
            }


            this.player.Draw(gameTime, this.spriteBatch);

            foreach (var enemy in this.movableObjects)
            {
                if (enemy.Possition.X >= this.player.Possition.X)
                {
                    enemy.SpriteEffects = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    enemy.SpriteEffects = SpriteEffects.None;
                }

                enemy.Draw(gameTime, this.spriteBatch);
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void PerformTheBattle(Character enemy)
        {

            this.player.Health -= enemy.Health;
            if (this.player.Health > 0)
            {
                this.player.Points += enemy.PointsToGive;
            }
        }

        private void ApplyItemEffect(Item item)
        {
            this.player.Health += item.HealthEffect;

            if (this.player.Health <= 0)
            {
                this.player.Health = 1;
            }
        }

        private void RestarGame()
        {
            this.player.Health = 100;
            this.player.Points = 0;
            this.gameState = GameState.Running;

            foreach (var movableObject in this.movableObjects)
            {
                movableObject.Possition = new Vector2(MovableObject.CreateRandomPossitionX(), 0);
            }
        }
    }
}
