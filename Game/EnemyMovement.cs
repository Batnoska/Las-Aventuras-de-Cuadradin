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
        private Vector2 direction = new Vector2 (1, 0);

        public EnemyMovement(Transform transform, int v_speed)
        {
            this.transform = transform;
            speed = v_speed;
        }

        public void MoveEnemy()
        {
            if (transform.Position.x > 1557 || transform.Position.x < 0)
            {
                direction.x = direction.x * -1;
            }
            transform.Translate(direction, speed);
        }
    }
}
