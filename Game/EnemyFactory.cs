using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class EnemyFactory
    {
        public enum Enemies
        {
            cuadrado,
            canion
        }

        public static IEnemies CreateEnemies( Enemies enemies, Vector2 pos, float x, float y, int speed, int direccion_x, int direccion_y, int bulletSpeed  )
        {
            switch ( enemies )
            {
                case Enemies.cuadrado:
                    return new Enemy(pos, x, y, speed, direccion_x, direccion_y);
                case Enemies.canion:
                    return new Canon(pos, x, y, bulletSpeed);
            }
            return null;
        }
    }
}
