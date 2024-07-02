using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        public Transform transform;
        public Texture texture;

        public void Render()
        {
            Engine.Draw(texture, transform.Position.x, transform.Position.y, transform.Scale.x, transform.Scale.y);
        }
        public Renderer(Transform transform)
        {
            this.transform = transform;
        }
    }
}
