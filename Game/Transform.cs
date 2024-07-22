using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Transform
    {
        public Vector2 position;
        public Vector2 Scale;
        public Vector2 Position
        {
            set { }

            get { return position; }
        }
        public float rotation;

        public Transform(Vector2 position, Vector2 scale)
        {
            this.position = position;
            //this.rotation = ang;
            this.Scale = scale;
        }

        public void Translate(Vector2 direction, float speed)
        {
            position.x += direction.x * speed;
            position.y += direction.y * speed;
        }
    }
}
