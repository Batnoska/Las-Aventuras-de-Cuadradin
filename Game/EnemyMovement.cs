using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class EnemyMovement
    {
        private Transform transform;
        private int speed;
        private Vector2 direction;

        public EnemyMovement(Transform transform, int v_speed, int direction_x, int direction_y)
        {
            this.transform = transform;
            speed = v_speed;
            direction = new Vector2 (direction_x, direction_y);
        }

        public void MoveEnemy()
        {
            if (transform.Position.x > 1557 || transform.Position.x < 0)
            {
                direction.x = direction.x * -1;
            }
            if (transform.Position.y > 860 || transform.Position.y < 0)
            {
               direction.y = direction.y * -1;
            }
            transform.Translate(direction, speed);
        }
    }
}
