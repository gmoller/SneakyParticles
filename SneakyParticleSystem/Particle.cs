using System.Collections.Generic;

namespace SneakyParticleSystem
{
    public struct Particle
    {
        public Position Position { get; private set; }
        public Velocity Velocity { get; private set; }
        public ColorRgba Color { get; private set; }
        public Size Size { get; private set; }
        public LifeSpan Life { get; private set; }

        public ColorRgba StartingColor { get; private set; }
        public ColorRgba EndingColor { get; private set; }

        public bool IsAlive => Life.Current > 0.0f;

        public Particle(Position position, Velocity velocity, ColorRgba color, ColorRgba startingColor, ColorRgba endingColor, Size size, LifeSpan life)
        {
            Position = position;
            Velocity = velocity;
            Color = color;
            StartingColor = startingColor;
            EndingColor = endingColor;
            Size = size;
            Life = life;
        }

        public Particle(Vector2 position, Velocity velocity, ColorRgba color, ColorRgba startingColor, ColorRgba endingColor, float size, float life)
        {
            Position = new Position(position);
            Velocity = velocity;
            Color = color;
            StartingColor = startingColor;
            EndingColor = endingColor;
            Size = new Size(size, 0);
            Life = new LifeSpan(life, life);
        }
    }

    public struct Particle2
    {
        public Position Position { get; private set; }
        public Velocity Velocity { get; private set; }
        public ColorRgba Color { get; private set; }
        public float Size { get; private set; }
        public LifeSpan2 Life { get; private set; }
        public List<IAction> Actions { get; set; } // TODO: convert list into object

        public bool IsAlive => Life.Current > 0.0f;

        public Particle2(Position position, Velocity velocity, ColorRgba color, float size, LifeSpan2 life, List<IAction> actions)
        {
            Position = position;
            Velocity = velocity;
            Color = color;
            Size = size;
            Life = life;
            Actions = actions;
        }
    }
}