using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PongTut
{
    public class IO
    {
        Player player { get; set; }

        public IO(Player player)
        {
            this.player = player;
        }   

        public void HandleIO(KeyboardState state, GameTime gametime)
        {
            if(state.IsKeyDown(Keys.W))
            {
                Vector2 motion = new Vector2(0, -100);
                motion = motion * (gametime.ElapsedGameTime.Milliseconds / 1000f);
                player.Move(motion);
            }

            if (state.IsKeyDown(Keys.S))
            {
                Vector2 motion = new Vector2(0, 100);
                motion = motion * (gametime.ElapsedGameTime.Milliseconds / 1000f);
                player.Move(motion);
            }
        }
    }
}
