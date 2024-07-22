using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Collider
    {
        public bool CheckCollisions(Transform transform, Transform transform2)
        {
            float distanceX = Math.Abs((transform2.Position.x + (transform2.Scale.x / 2)) - (transform.Position.x + (transform.Scale.x / 2)));
            float distanceY = Math.Abs((transform2.Position.y + (transform2.Scale.y / 2)) - (transform.Position.y + (transform.Scale.y / 2)));

            float sumHalfWidth = transform2.Scale.x / 2 + transform.Scale.x / 2;
            float sumHalfH = transform2.Scale.y / 2 + transform.Scale.y / 2;

            if (distanceX < sumHalfWidth && distanceY < sumHalfH)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
