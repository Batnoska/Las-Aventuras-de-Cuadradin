using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character
    {
        public int coins = 0;
        private Transform transform;
        public Transform Transform => transform;
        private Collider collider = new Collider();
        private CharacterController controller;
        public Action<Character> OnDeath;
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
                IEnemies enemy = Program.EnemyList[i];
                if (collider.CheckCollisions(enemy.GetTransform(), this.transform))
                {
                    OnDeath?.Invoke(this);
                }
            }
        }

        public void Update()
        {
            controller.GetInputs();
            CheckCollisions();
        }

        public void Death(Character character)
        {
            GameManager.Instance.SetLevel("Derrota");
        }
    }
}
