﻿using System;
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
        public static Coin coin;
        private string backgroundImage = "background.jpg";
        public Gameplay()
        {
            Initialize();
        }

        public override void Draw()
        {
            Engine.Draw(backgroundImage);
            character.Render();
            for (int i = 0; i < Program.EnemyList.Count; i++)
            {
                Program.EnemyList[i].Render();
            }
            for (int i = 0; i < Program.coinList.Count; i++)
            {
                Program.coinList[i].Render();
            }
            //for (int i = 0; i < Program.WallList.Count; i++)
            //{
            //    Program.WallList[i].Render();
            //}
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
            for (int i = 0; i < Program.coinList.Count; i++)
            {
                Program.coinList[i].Update();
            }
            //for (int i = 0; i < Program.WallList.Count; i++)
            //{
            //    Program.WallList[i].Update();
            //}
            victory.Update();
        }

        

        private void Initialize()
        {
            character = new Character(new Vector2(200, 800), .10f, .10f);
            Character.coins = 0;
            victory = new Win(new Vector2(1420,-50), 1.5f, 1.5f, 2);
            CreateEnemies();
            CreateCoins();
            //Program.CreateWall();
        }

        private void CreateEnemies()
        {
            Program.EnemyList.Clear();
            //movimiento horizontal
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado,new Vector2(50, 500), .10f, .10f, 4, 1, 0));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(50, 300), .10f, .10f, 6, 1, 0));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(50, 100), .10f, .10f, 8, 1, 0));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(50, 700), .10f, .10f, 8, 1, 0));

            //movimiento vertical
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(600, 100), .10f, .10f, 6, 0, 1));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(400, 100), .10f, .10f, 10, 0, 1));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(800, 100), .10f, .10f, 12, 0, 1));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(1000, 100), .10f, .10f, 5, 0, 1));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(100, 100), .10f, .10f, 7, 0, 1));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(300, 100), .10f, .10f, 9, 0, 1));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(1200, 100), .10f, .10f, 9, 0, 1));
            Program.EnemyList.Add(EnemyFactory.CreateEnemies(EnemyFactory.Enemies.cuadrado, new Vector2(1400, 100), .10f, .10f, 9, 0, 1));
        }

        public static void CreateCoins()
        {
            Program.coinList.Clear();
            Program.coinList.Add(new Coin(new Vector2(200, 200), .1f, .1f));
            Program.coinList.Add(new Coin(new Vector2(1100, 600), .1f, .1f));
        }
    }

    public class Menu : Levels
    {
        private string backgroundImage = "inicio.png";


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
        }

        public override void Reset()
        {
        }
    }

    public class Defeat : Levels
    {
        private string backgroundImage = "lose.png";

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
        }

        public override void Reset()
        {
        }
    }

    public class Victory : Levels
    {
        private string backgroundImage = "win.png";

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
        }

        public override void Reset()
        {

        }
    }
}
