using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EECEBlockBreaker
{
    class BoundryBlock : Block
    {
        /// <summary>
        /// Block constructer.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public BoundryBlock(int x, int y) : base(x, y) 
        {
            color = Color.DarkGray;
        }

        /// <summary>
        /// Checks if the block is a natural part of the level (isn't required to be removed for victory).
        /// </summary>
        public override bool Static
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Handles collision with a ball. Boundry blocks cannot be destroyed.
        /// </summary>
        /// <param name="ball">The ball.</param>
        public override void HandleCollision(Ball ball)
        {
            base.HandleCollision(ball);
            Destroyed = false;
        }
    }
}
