using Unity.Entities;

namespace Assets.Scripts.ECS.Components
{
    /// <summary>
    /// La rareté de la carte
    /// </summary>
    public struct CardRarityCD : IComponentData
    {
        /// <summary>
        /// La rareté de la carte
        /// </summary>
        public byte Value;
    }
}