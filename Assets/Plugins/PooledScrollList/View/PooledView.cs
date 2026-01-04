using PooledScrollList.Data;
using UnityEngine;

namespace PooledScrollList.View
{
    public abstract class PooledView : MonoBehaviour
    {
        public IPooledData Data { get; private set; }

        public virtual void SetData(IPooledData data)
        {
            Data = data;
        }
    }
}