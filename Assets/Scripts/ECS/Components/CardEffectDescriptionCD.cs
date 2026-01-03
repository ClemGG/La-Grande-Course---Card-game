using Unity.Collections;
using Unity.Entities;

namespace Assets.Scripts.ECS.Components
{
    /// <summary>
    /// La description de l'effet de la carte
    /// </summary>
    public struct CardEffectDescriptionCD : IComponentData
    {
        /// <summary>
        /// La description de l'effet de la carte
        /// </summary>
        public FixedString4096Bytes Value;
    }
}