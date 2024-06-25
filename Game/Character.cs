using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character
    {
        public static int coins = 0;
        private Transform transform;
        public Transform Transform => transform;
        private CharacterController controller;
        private float x;
        private float y;


        public Character(Vector2 position, float scale_x, float scale_y)
        {
            transform = new Transform(position, new Vector2(50, 50));
            controller = new CharacterController(transform);
            x = scale_x; 
            y = scale_y;
        }

        public void Render()
        {
            Engine.Draw("cuadrado.png", transform.Position.x, transform.Position.y, x, y);
        }

        private void CheckCollisions()
        {

            for (int i = 0; i < Program.EnemyList.Count; i++)
            {
                Enemy enemy = Program.EnemyList[i];
                float distanceX = Math.Abs((enemy.Transform.Position.x + (enemy.Transform.Scale.x / 2)) - (transform.Position.x + (transform.Scale.x / 2)));
                float distanceY = Math.Abs((enemy.Transform.Position.y + (enemy.Transform.Scale.y / 2)) - (transform.Position.y + (transform.Scale.y / 2)));

                float sumHalfWidth = enemy.Transform.Scale.x / 2 + transform.Scale.x / 2;
                float sumHalfH = enemy.Transform.Scale.y / 2 + transform.Scale.y / 2;

                if (distanceX < sumHalfWidth && distanceY < sumHalfH) // hay colision
                {
                    GameManager.Instance.SetLevel("Derrota");
                }
            }
        }

        public void Update()
        {
            controller.GetInputs();
            CheckCollisions();
        }
    }
}
