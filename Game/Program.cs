using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        public static float deltaTime = 0;
        static DateTime lastFrameTime = DateTime.Now;


        static public List<Coin> coinList = new List<Coin>();
        static public List<Enemy> EnemyList = new List<Enemy>();
        static public List<Wall> WallList = new List<Wall>();

        static void Main(string[] args)
        {
            Engine.Initialize("Las aventuras de Cuadradin");
            Console.WriteLine(GameManager.Instance.CurrentLevel);

            while (true)
            {
                Input();
                Update();
                Render();

                
                CalcDeltaTime();
            }
        }

        static void Input()
        {
            GameManager.Instance.CurrentLevel.Input();
        }
        static void Render()
        {
            Engine.Clear();
            GameManager.Instance.CurrentLevel.Draw();

            

            Engine.Show();
        }

        static void Update()
        {
            GameManager.Instance.CurrentLevel.Update();
        }

        private static void CalcDeltaTime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

        public static void CreateEnemies()
        {
            EnemyList.Clear();
            EnemyList.Add(new Enemy(new Vector2(50, 500), .10f, .10f));
            EnemyList.Add(new Enemy(new Vector2(50, 300), .10f, .10f));
            EnemyList.Add(new Enemy(new Vector2(50, 100), .10f, .10f));
        }

        public static void CreateCoins()
        {
            coinList.Clear();
            coinList.Add(new Coin(new Vector2(200, 200), .1f, .1f));
        }
         public static void CreateWall()
        {
           WallList.Clear();
            WallList.Add(new Wall(new Vector2(300, 300), .1f, .1f));
        }
    }
}