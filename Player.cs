using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongTut
{
    public class Player
    {
        public Texture2D Image { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; set; }

        public Player(Texture2D image, Vector2 position)
        {
            Image = image;
            Position = position;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
        }

        public void Move(Vector2 motion)
        {
            Position += motion;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
        }
    }
}
