using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Win : IVictory
    {
        private Transform transform;
        private Collider collider = new Collider();
        private int condition;
        Character character;
        private float x;
        private float y;

        public Win(Vector2 position, float scale_x, float scale_y, int condition)
        {
            transform = new Transform(position, new Vector2(110, 110));
            x = scale_x;
            y = scale_y;
            this.condition = condition;
        }

        public void Render()
        {
            Engine.Draw("banderin.png", transform.Position.x, transform.Position.y, x, y);
        }

        public void Update()
        {
            CheckCollisions();
        }

        private void CheckCollisions()
        {
            if (GameManager.Instance.CurrentLevel.ToString() == "Game.Gameplay")
            {
                character = Gameplay.character;
                if (collider.CheckCollisions(character.Transform, this.transform))
                {
                    if (character.coins >= condition)
                    {
                        NextLevel();
                    } else
                    {
                        Console.WriteLine("Te faltan monedas");
                    }
                }
            }

            if (GameManager.Instance.CurrentLevel.ToString() == "Game.Level2")
            {
                character = Level2.character;
                if (collider.CheckCollisions(character.Transform, this.transform))
                {
                    if (character.coins >= condition)
                    {
                        Winn();
                    }
                    else
                    {
                        Console.WriteLine("Te faltan monedas");
                    }
                }
            }
        }

        public void Winn()
        {
            GameManager.Instance.SetLevel("Victoria");
        }

        public void NextLevel()
        {
            GameManager.Instance.SetLevel("Nivel 2");
        }
    }
    
}
