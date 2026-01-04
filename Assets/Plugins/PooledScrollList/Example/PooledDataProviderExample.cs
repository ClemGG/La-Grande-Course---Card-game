using System.Collections.Generic;
using JetBrains.Annotations;
using PooledScrollList.Controller;
using PooledScrollList.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PooledScrollList.Example
{
    public class PooledDataProviderExample : PooledDataProvider
    {
        public PooledScrollRectBase ScrollRectController;
        public InputField InputField;
        public int Count;
        public List<Color> Colors;

        private void Awake()
        {
            InputField.text = Count.ToString();
        }

        public override List<IPooledData> GetData()
        {
            var data = new List<IPooledData>(Count);

            for (var i = 0; i < Count; i++)
            {
                data.Add(new PooledDataExample(Colors[Random.Range(0, Colors.Count)], i + 1));
            }

            return data;
        }

        [UsedImplicitly]
        public void Apply()
        {
            if (InputField != null && !string.IsNullOrEmpty(InputField.text))
            {
                if (int.TryParse(InputField.text, out int result))
                {
                    Count = result;
                }
            }

            var data = GetData();

            if (ScrollRectController != null)
            {
                ScrollRectController.Initialize(data);
            }
        }
    }
}