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
        private DateTime timeLastShoot;
        private float timeBetweenShoots = 1;

        public CharacterController(Transform transform)
        {
            this.transform = transform;
        }

        public void GetInputs()
        {
            if (Engine.GetKey(Keys.A))
            {
                transform.Translate(new Vector2(-1, 0), speed);
            }

            if (Engine.GetKey(Keys.D))
            {
                transform.Translate(new Vector2(1, 0), speed);
            }

            if (Engine.GetKey(Keys.W))
            {
                transform.Translate(new Vector2(0, -1), speed);
            }

            if (Engine.GetKey(Keys.S))
            {
                transform.Translate(new Vector2(0, 1), speed);
            }
        }
    }
}
