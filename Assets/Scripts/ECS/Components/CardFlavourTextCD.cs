using Unity.Collections;
using Unity.Entities;

namespace Assets.Scripts.ECS.Components
{
    /// <summary>
    /// La description du lore de la carte
    /// </summary>
    public struct CardFlavourTextCD : IComponentData
    {
        /// <summary>
        /// La description du lore de la carte
        /// </summary>
        public FixedString512Bytes Value;
    }
}