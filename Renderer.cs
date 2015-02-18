using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PongTut
{
    public class Renderer
    {
        private Texture2D background { get; set; }
        public Player player { get; set; }
        public Ball ball { get; set; }

        public Renderer(ContentManager cm, SpriteBatch batch)
        {
            LoadContent(cm, batch);
        }

        private void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            background = content.Load<Texture2D>("Textures/background");

            player = new Player(content.Load<Texture2D>("Textures/paddle"),
                new Vector2(0, 50));

            ball = new Ball(content.Load<Texture2D>("Textures/ball"),
                new Vector2(700, 300), new Vector2(-60,-60), new Rectangle(0,0, spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height));
        }

        private void drawBackground(SpriteBatch batch)
        {
            batch.Draw(background, Vector2.Zero, Color.White);
        }

        private void drawPlayer(SpriteBatch batch)
        {
            batch.Draw(player.Image, player.Position, Color.White);
        }

        private void drawBall(SpriteBatch batch)
        {
            batch.Draw(ball.Image, ball.Position, Color.White);
        }

        public void DrawScene(SpriteBatch batch)
        {
            batch.Begin();
            {
                drawBackground(batch);
                drawPlayer(batch);
                drawBall(batch);
            }
            batch.End();
        }
    }
}
