using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy
    {
        private Transform transform;
        public Transform Transform => transform;
        private EnemyMovement enemyMovement;
        private float scale_x;
        private float scale_y;


        public Enemy(Vector2 pos, float x, float y, int speed, int direction_x, int direction_y)
        {
            transform = new Transform(pos, new Vector2(50, 50));
            enemyMovement = new EnemyMovement(transform, speed, direction_x, direction_y);
            scale_x = x;
            scale_y = y;
        }

        public void Render()
        {
            Engine.Draw("cuadrado_malo.png", transform.Position.x, transform.Position.y, scale_x, scale_y);
        }

        public void Update()
        {
            enemyMovement.MoveEnemy();
        }
    }
}
