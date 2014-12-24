using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using EECEBlockBreaker.Interfaces;
using EECEBlockBreaker.Scenes;

namespace EECEBlockBreaker
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player();
        int nextLevel = 1;
        IScene scene;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Block Breaker";

            graphics.PreferredBackBufferWidth = 460;
            graphics.PreferredBackBufferHeight = 415;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            scene = new WelcomeScene();// new GameScene(player, level);
            scene.Load(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();


            scene.Update(gameTime);

            if (scene.Completed)
            {
                // Check if they were successful.
                if (player.Lives > 0)
                {
                    // Yep, load a new level.
                    Level lvl = Level.FromFile(@"levels/" + nextLevel++ + ".txt");
                    if (lvl != null)
                    {
                        scene = new GameScene(player, lvl);
                        scene.Load(Content);
                    }
                    else
                    {
                        // No more levels, they finished. Display highscores.
                        nextLevel = 1;
                        scene = new HighScoreScene(player);
                        scene.Load(Content);
                        player = new Player();
                    }
                }
                else
                {
                    // They lost, display highscores.
                    nextLevel = 1;
                    scene = new HighScoreScene(player);
                    scene.Load(Content);
                    player = new Player();
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            // TODO: Add your drawing code here
            scene.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
