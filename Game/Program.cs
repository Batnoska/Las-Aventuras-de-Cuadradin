using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        public static float deltaTime = 0;
        static public List<Enemy> EnemyList = new List<Enemy>();
        static DateTime lastFrameTime = DateTime.Now;


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
            Program.EnemyList.Add(new Enemy(new Vector2(50, 500), .10f, .10f));
            Program.EnemyList.Add(new Enemy(new Vector2(50, 300), .10f, .10f));
            Program.EnemyList.Add(new Enemy(new Vector2(50, 100), .10f, .10f));
        }

    }
}