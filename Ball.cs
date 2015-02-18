using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongTut
{
    public class Ball
    {
        public Texture2D Image { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity;

        private Rectangle ScreenBounds { get; set; }

        public Ball(Texture2D image, Vector2 position, Vector2 velocity, Rectangle screenBounds)
        {
            Image = image;
            Position = position;
            Velocity = velocity;
            ScreenBounds = screenBounds;
        }

        private void keepOnScreen()
         {
             //is it off the right side?
             if(Position.X + Image.Width > ScreenBounds.Width)
             {
                 //bounce
                 Velocity.X *= -1;
             }
 
             //is it off the top side?
             if(Position.Y < ScreenBounds.Y)
             {
                 //bounce
                 Velocity.Y *= -1;
             }
 
             //is it off the top side?
             if(Position.Y + Image.Height > ScreenBounds.Height)
             {
                 //bounce
                 Velocity.Y *= -1;
             }
         }

        private void collideWithPlayerCheck(Player player)
         {
             int radius = 24;
             //find the midpoint of the circle
             Vector2 midPoint = new Vector2(Image.Width/2,Image.Height/2) + Position;
  
             //check to see if the ball is in the same X plane as the player
             if(player.BoundingBox.Right > midPoint.X - radius)
             {
                 //could collide, check Y plane
                 if(player.BoundingBox.Top < midPoint.Y + radius 
                   && player.BoundingBox.Bottom > midPoint.Y - radius)
                 {
                     //collided, make it bounce
                     Velocity.X *= -1;
                 }
             }
         }

        public void Update(GameTime gameTime, Player player)
        {
            keepOnScreen();
            collideWithPlayerCheck(player);
            Position += Velocity * gameTime.ElapsedGameTime.Milliseconds / 1000f;
        }

    }
}
