using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        public static float deltaTime = 0;
        public static int HEIGHT = 900;
        public static int WIDTH = 1600;
        static DateTime lastFrameTime = DateTime.Now;
        static public string previousLevel;

        static public List<Coin> coinList = new List<Coin>();
        static public List<IEnemies> EnemyList = new List<IEnemies>();
        //static public List<Wall> WallList = new List<Wall>();

        static void Main(string[] args)
        {
            Engine.Initialize("Las aventuras de Cuadradin", HEIGHT, WIDTH);
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

        public static void CalcDeltaTime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

        

        
        // public static void CreateWall()
        //{
        //   WallList.Clear();
        //    WallList.Add(new Wall(new Vector2(300, 300), .1f, .1f));
        //}
    }
}