using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EECEBlockBreaker
{
    class Player
    {
        /// <summary>
        /// Lives left.
        /// </summary>
        public int Lives
        {
            get;
            set;
        }

        /// <summary>
        /// Current score.
        /// </summary>
        public int Score
        {
            get;
            private set;
        }

        public Player()
        {
            Score = 0;
            Lives = 5;
        }

        /// <summary>
        /// Add a value to the score.
        /// </summary>
        /// <param name="seconds"></param>
        public void AddToScore(double seconds)
        {
            Score += (int)Math.Floor(seconds);
        }
    }
}
