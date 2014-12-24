using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using EECEBlockBreaker.Interfaces;

namespace EECEBlockBreaker.Scenes
{
    class WelcomeScene : IScene
    {
        SpriteFont font;
        SpriteFont hsfont;

        public WelcomeScene()
        {
            Completed = false;
        }

        /// <summary>
        /// If the scene has completed and is ready to be swapped out.
        /// </summary>
        public bool Completed
        {
            get;
            private set;
        }

        /// <summary>
        /// Loads the fonts required by the scene.
        /// </summary>
        /// <param name="content">The content manager.</param>
        public void Load(ContentManager content)
        {
            hsfont = content.Load<SpriteFont>("hsfont");
            font = content.Load<SpriteFont>("font");
        }

        /// <summary>
        /// Updates the scene (just checks if we can transition).
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Completed = true;
            }
        }

        /// <summary>
        /// Draw the scene to the spritebatch.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(hsfont, "Block Breaker", new Vector2(87, 140), Color.Red);
            sb.DrawString(font, "Press 'Space' to start...", new Vector2(105, 200), Color.WhiteSmoke);
        }
    }
}
