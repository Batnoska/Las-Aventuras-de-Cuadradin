using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Transform
    {
        private Vector2 position;
        private Vector2 scale;
        public Vector2 Scale => scale;
        public Vector2 Position
        {
            set { }

            get { return position; }
        }

        public Transform(Vector2 position, Vector2 scale)
        {
            this.position = position;
            this.scale = scale;
        }

        public void Translate(Vector2 direction, float speed)
        {
            position.x += direction.x * speed;
            position.y += direction.y * speed;
        }
    }
}
