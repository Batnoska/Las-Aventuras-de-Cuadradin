using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Levels
    {
        public abstract void Input();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Reset();
    }

    public class Gameplay : Levels
    {
        public static Character character;
        public static Win victory;

        public Gameplay()
        {
            Initialize();
        }

        public override void Draw()
        {
            character.Render();
            for (int i = 0; i < Program.EnemyList.Count; i++)
            {
                Program.EnemyList[i].Render();
            }
            victory.Render();
        }

        public override void Input()
        {
            
        }

        public override void Reset()
        {
            Initialize();
        }

        public override void Update()
        {
            character.Update();
            for (int i = 0; i < Program.EnemyList.Count; i++)
            {
                Program.EnemyList[i].Update();
            }
            victory.Update();
        }

        

        private void Initialize()
        {
            character = new Character(new Vector2(400, 400), .10f, .10f);
            victory = new Win(new Vector2(935,0), .2f, .2f);
            Program.EnemyList.Clear();
            Program.CreateEnemies();
        }
    }

    public class Menu : Levels
    {
        private string backgroundImage = "fondo.png";
        private string messageImage = "mensaje menu.png";


        public Menu()
        {

        }

        public override void Input()
        {
            if (Engine.GetKey(Keys.SPACE))
            {
                GameManager.Instance.SetLevel("Jugar");
            }
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
            Engine.Draw(backgroundImage);
            Engine.Draw(messageImage, 150, 350);
        }

        public override void Reset()
        {
        }
    }

    public class Defeat : Levels
    {
        private string backgroundImage = "you died.jpg";
        private string messageImage = "mensaje muerte.png";

        public Defeat()
        {

        }

        public override void Input()
        {
            if (Engine.GetKey(Keys.SPACE))
            {
                GameManager.Instance.SetLevel("Jugar");
            }
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            Engine.Draw(backgroundImage);
            Engine.Draw(messageImage, 150, 100);
        }

        public override void Reset()
        {
        }
    }

    public class Victory : Levels
    {
        private string backgroundImage = "victoria.jpg";
        private string messageImage = "texto victoria.png";

        public Victory()
        {

        }
        public override void Input()
        {
            if (Engine.GetKey(Keys.RETURN))
            {
                GameManager.Instance.SetLevel("Menu");
            }
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            Engine.Draw(backgroundImage);
            Engine.Draw(messageImage, 0, 200);
        }

        public override void Reset()
        {

        }
    }
}
