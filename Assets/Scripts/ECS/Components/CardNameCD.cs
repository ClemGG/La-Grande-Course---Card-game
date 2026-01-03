using Unity.Collections;
using Unity.Entities;

namespace Assets.Scripts.ECS.Components
{
    /// <summary>
    /// Le nom de la carte
    /// </summary>
    public struct CardNameCD : IComponentData
    {
        /// <summary>
        /// Le nom de la carte
        /// </summary>
        public FixedString128Bytes Value;
    }
}