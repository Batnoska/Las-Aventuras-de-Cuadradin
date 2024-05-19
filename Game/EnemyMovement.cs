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
        private int speed = 4;
        private Vector2 direction = new Vector2 (1, 0);

        public EnemyMovement (Transform transform)
        {
            this.transform = transform;
        }

        public void MoveEnemy()
        {
            if (transform.Position.x > 980 || transform.Position.x < 0)
            {
                direction.x = direction.x * -1;
            }
            transform.Translate(direction, speed);
        }
    }
}
