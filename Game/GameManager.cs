using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Game
{
    //public enum LevelType
    //{
    //    Menu,
    //    Game,
    //    Win,
    //    Loose
    //}
    public class GameManager
    {
        private static GameManager instance = new GameManager();
        public static GameManager Instance { get { return instance; } }


        private Dictionary<string,Levels> levels = new Dictionary<string, Levels>();

        private Levels currentLevel = null;


        public GameManager()
        {
            levels.Clear();
            AddNewLevel("Menu", new Menu());
            AddNewLevel("Jugar", new Gameplay());
            AddNewLevel("Nivel 2", new Level2());
            AddNewLevel("Derrota", new Defeat());
            AddNewLevel("Victoria", new Victory());

            SetLevel("Menu");
        }

        public Levels CurrentLevel => currentLevel;

        public void SetLevel(string levelName)
        {
            if (levels.TryGetValue(levelName, out var l_currentLevel))
            {
                currentLevel = l_currentLevel;
                currentLevel.Reset();
            } else
            {
                Console.WriteLine($"El nivel: {levelName} seleccionado no se encuentra registrado");
            }
        }

        //public void SetLevel(LevelType p_level)
        //{
        //    switch (p_level)
        //    {
        //        case LevelType.Menu:
        //            currentLevel = new Menu();
        //            break;
        //        case LevelType.Game:
        //            currentLevel = new Gameplay();
        //            break;
        //    }
        //}

        public void AddNewLevel(string name, Levels level)
        {
            levels.Add(name, level);
        }
    }
}
