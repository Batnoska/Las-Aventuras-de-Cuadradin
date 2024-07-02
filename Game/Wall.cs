﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class Wall
    {
        protected Animation idle;
        protected Animation currentAnimation;
        private Transform transform;
        private float x;
        private float y;
        public Wall(Vector2 position, float scale_x, float scale_y)
        {
            transform = new Transform(position, new Vector2(90, 90));
            x = scale_x;
            y = scale_y;

            List<Texture> list = new List<Texture>();
            for (int i = 1; i < 4; i++)
            {
                list.Add(Engine.GetTexture($"pared{i}.png"));
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
            Character character = Gameplay.character;
            float distanceX = Math.Abs((character.Transform.Position.x + (character.Transform.Scale.x / 2)) - (transform.Position.x + (transform.Scale.x / 2)));
            float distanceY = Math.Abs((character.Transform.Position.y + (character.Transform.Scale.y / 2)) - (transform.Position.y + (transform.Scale.y / 2)));

            float sumHalfWidth = character.Transform.Scale.x / 2 + transform.Scale.x / 2;
            float sumHalfHeight = character.Transform.Scale.y / 2 + transform.Scale.y / 2;


        }
    }

}