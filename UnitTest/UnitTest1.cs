using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VectorToStringIsOk()
        {
            int x = 2;
            int y = 3;

            var vector = new Vector2(x, y);

            var resultado = vector.ToString();

            var resultadoEsperado = $"X : {x} / Y : {y}";

            Assert.AreEqual(resultado, resultadoEsperado);
        }

        [TestMethod]
        public void CheckCollisionIsOk()
        {
            var cuadradin = new Transform(new Vector2(200, 200), new Vector2(1, 1));
            var cuadradoMalo = new Transform(new Vector2(200, 200), new Vector2(.5f, .5f));
            Collider collider = new Collider();

            Assert.IsTrue(collider.CheckCollisions(cuadradin, cuadradoMalo), "La colision deberia devolver true ya que estan en contacto");
        }

        [TestMethod]
        public void ContadorMoneda()
        {
            Collider collider = new Collider();
            float resultadoEsperado = 1;

            Character character = new Character(new Vector2(300, 300), 1, 1);
            Transform coin = new Transform(new Vector2(300, 300), new Vector2(.5f, .5f));

            if (collider.CheckCollisions(character.Transform, coin))
            {
                character.coins += 1;
            }

            float resultado = character.coins;

            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}
