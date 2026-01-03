using Unity.Entities;

namespace Assets.Scripts.ECS.Components
{
    /// <summary>
    /// Les statistiques de course de la carte: Vitesse, Style, Technique
    /// </summary>
    public struct CardStatsCD : IComponentData
    {
        /// <summary>
        /// La stat de vitesse de la carte
        /// </summary>
        public byte Speed;

        /// <summary>
        /// La stat de style de la carte
        /// </summary>
        public byte Style;

        /// <summary>
        /// La stat de technique de la carte
        /// </summary>
        public byte Technique;
    }
}