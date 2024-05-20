using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CharacterController
    {
        private float speed = 2.5f;
        private Transform transform;

        public CharacterController(Transform transform)
        {
            this.transform = transform;
        }

        public void GetInputs()
        {
            if (Engine.GetKey(Keys.A))
            {
                if (transform.Position.x > 0)
                {
                    transform.Translate(new Vector2(-1, 0), speed);
                }
            }

            if (Engine.GetKey(Keys.D))
            {
                if (transform.Position.x < 980)
                {
                    transform.Translate(new Vector2(1, 0), speed);
                }

            }

            if (Engine.GetKey(Keys.W))
            {
                if (transform.Position.y > 0)
                {
                    transform.Translate(new Vector2(0, -1), speed);
                }
            }

            if (Engine.GetKey(Keys.S))
            {
                if (transform.Position.y < 725)
                {
                    transform.Translate(new Vector2(0, 1), speed);
                }
            }
        }
    }
}
