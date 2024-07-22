using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    
    public class Coin : IGrababble
    {
        protected Animation idle;
        protected Animation currentAnimation;
        private Transform transform;
        private Collider collider = new Collider();
        private float x;
        private float y;
        private Character character;
        public Coin(Vector2 position, float scale_x, float scale_y)
        {
            transform = new Transform(position, new Vector2(90, 90));
            x = scale_x;
            y = scale_y;

            List<Texture> list = new List<Texture>();
            for (int i = 1; i < 5; i++)
            {
                list.Add(Engine.GetTexture($"{i}.png"));
            }
            idle = new Animation("idle", list, .25f, true);

            currentAnimation = idle;
        }
        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y, x, y);
        }
        public void Update()
        {
            CheckCollisions();
            currentAnimation.Update();
        }
        private void CheckCollisions()
        {

            if (GameManager.Instance.CurrentLevel.ToString() == "Game.Gameplay")
            {
                character = Gameplay.character;
                if (collider.CheckCollisions(character.Transform, this.transform))
                {
                    Grab();
                }
            }

            if (GameManager.Instance.CurrentLevel.ToString() == "Game.Level2")
            {
                character = Level2.character;
                if (collider.CheckCollisions(character.Transform, this.transform))
                {
                    Grab();
                }
            }
        }

        public void Grab()
        {
            Program.coinList.Remove(this);
            Console.WriteLine(character.coins);
            character.coins += 1;
            Console.WriteLine(character.coins);
        }
    }

}
