using Unity.Entities;

namespace Assets.Scripts.ECS.Components
{
    /// <summary>
    /// L'ID de la carte
    /// </summary>
    public struct CardIDCD : IComponentData
    {
        /// <summary>
        /// L'ID de la carte
        /// </summary>
        public int Value;
    }
}