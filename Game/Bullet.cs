using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Bullet : IEnemies
    {
        private Transform transform;
        public Action<Bullet> OnDestroy;
        public Transform Transform => transform;
        private Collider collider = new Collider();
        private float x;
        private float y;
        private int velocidad;
        private Vector2 direction;

        public Bullet(Vector2 position, float scale_x, float scale_y, int speed, int direccion_x, int direccion_y) 
        {
            transform = new Transform(position, new Vector2(50, 50));
            x = scale_x;
            y = scale_y;
            velocidad = speed;
            direction = new Vector2(direccion_x, direccion_y);
        }

        public void Update()
        {
            if (transform.Position.x < 0 || transform.Position.x > 1557 || transform.Position.y < 0 || transform.Position.y > 860)
            {
                OnDestroy?.Invoke(this);
            }
            transform.Translate(direction, velocidad);
            CheckCollisions();
        }

        public Transform GetTransform()
        {
            return transform;
        }

        private void CheckCollisions()
        {
               Character character;
            if (GameManager.Instance.CurrentLevel.ToString() == "Game.Gameplay")
            {
                character = Gameplay.character;
                if (collider.CheckCollisions(character.Transform, this.transform))
                {
                    character.OnDeath?.Invoke(character);
                }
            }

            if (GameManager.Instance.CurrentLevel.ToString() == "Game.Level2")
            {
                character = Level2.character;
                if (collider.CheckCollisions(character.Transform, this.transform))
                {
                    character.OnDeath?.Invoke(character);
                }
            }

        }

        public void Render()
        {
            Engine.Draw("bullet.png", transform.Position.x, transform.Position.y, x, y);
        }
    }
}
