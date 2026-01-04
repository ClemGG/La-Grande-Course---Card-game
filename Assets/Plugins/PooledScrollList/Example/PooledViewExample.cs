using System;
using PooledScrollList.Data;
using PooledScrollList.View;
using UnityEngine;
using UnityEngine.UI;

namespace PooledScrollList.Example
{
    [Serializable]
    public readonly struct PooledDataExample : IPooledData
    {
        public readonly Color Color;
        public readonly int Number;

        public PooledDataExample(Color color, int number)
        {
            Color = color;
            Number = number;
        }
    }

    public class PooledViewExample : PooledView
    {
        public Image Image;
        public Text Number;

        public override void SetData(IPooledData data)
        {
            base.SetData(data);

            PooledDataExample exampleData = (PooledDataExample)data;
            Image.color = exampleData.Color;
            Number.text = exampleData.Number.ToString();
        }
    }
}