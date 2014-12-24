using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EECEBlockBreaker
{
    class GhostBlock : Block
    {
        /// <summary>
        /// Block constructer.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public GhostBlock(int x, int y) : base(x, y) 
        {
            color = Color.LightBlue;
        }

        float alpha = 1.0f;

        /// <summary>
        /// Checks if the ball has collided with the block.
        /// </summary>
        /// <param name="ball">The ball.</param>
        /// <returns></returns>
        public override bool CollidesWith(Ball ball)
        {
            // Can only collide if we are 'visible'.
            if (alpha > 0.8)
            {
                return base.CollidesWith(ball);
            }
            return false;
        }

        /// <summary>
        /// Updates the blocks state for dynamic blocks.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Change transparency based on time.
            alpha = (float)Math.Abs(Math.Sin(gameTime.TotalGameTime.TotalSeconds / 3.0));
            color = Color.Lerp(Color.Transparent, Color.LightBlue, alpha);
            base.Update(gameTime);
        }
    }
}
