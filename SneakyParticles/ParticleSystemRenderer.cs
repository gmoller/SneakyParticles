using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SneakyParticleSystem;

namespace SneakyParticles
{
    internal class ParticleSystemRenderer
    {
        private Texture2D _texture;

        internal Particle[] Particles { get; set; }
        internal int ParticleCount { get; set; }

        internal void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("circle");
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < ParticleCount; ++i)
            {
                var particle = Particles[i];
                var color = new Color(particle.Color.R, particle.Color.G, particle.Color.B, particle.Color.A);
                var size = particle.Size.Current;
                spriteBatch.Draw(_texture, new Microsoft.Xna.Framework.Vector2(particle.Position.X, particle.Position.Y), _texture.Bounds, color, 0.0f, new Microsoft.Xna.Framework.Vector2(_texture.Width / 2, _texture.Height / 2), size, SpriteEffects.None, 0.0f);
            }
        }
    }
}