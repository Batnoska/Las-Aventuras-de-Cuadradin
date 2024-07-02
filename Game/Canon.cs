using MyGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Canon : IEnemies
    {
        public Pool<Bullet> bullets = new Pool<Bullet>();
        public Transform transform;
        public Transform Transform => transform;
        private float x;
        private float y;

        private float timer;
        private float timeBetweenShots = 1f;

        public Canon(Vector2 position, float scale_x, float scale_y) 
        {
            transform = new Transform(position, new Vector2(50, 50));
            x = scale_x;
            y = scale_y;
        }

        public void Update()
        {
            timer += Program.deltaTime;
            if (timer >= timeBetweenShots)
            {
                Shoot();
                timer = 0;
            }
            for (int i = 0; i < bullets.inUse.Count; i++)
            {
                bullets.inUse[i].Update();
            }
        }

        public void Render()
        {
            Engine.Draw("canon.png", transform.Position.x, transform.Position.y, x, y);
            for (int i = 0; i < bullets.inUse.Count; i++)
            {
                bullets.inUse[i].Render();
            }
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Shoot()
        {
            Engine.Debug("hola");
            Bullet bullet = bullets.Pull();

            if (bullet == null)
            {
                bullet = new Bullet(transform.Position, transform.Scale.x, transform.Scale.y, 1, 0, -1);
                bullet.OnDestroy += bullets.Return;
                bullets.Push(bullet);
            }
            else
            {
                bullet.Transform.Position = new Vector2(transform.Position.x, transform.Position.y);
            }

        }
    }
    
}
