using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyMobile.Demo
{
    public static class TextureGenerator
    {
        public static Texture2D GenerateRandomTexture2D(int width, int height, Color[] randomColors)
        {
            var texture = new Texture2D(width, height);
            var colors = texture.GetPixels();

            for (var x = 0; x < texture.width; x++)
            for (var y = 0; y < texture.height; y++)
            {
                var index = x + y * texture.width;
                var color = randomColors[UnityEngine.Random.Range(0, randomColors.Length)];
                colors[index] = color;
            }

            texture.SetPixels(colors);
            texture.Apply();
            return texture;
        }
    }
}