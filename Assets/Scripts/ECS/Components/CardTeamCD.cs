using Unity.Entities;

namespace Assets.Scripts.ECS.Components
{
    /// <summary>
    /// L'équipe (archétype) dont fait partie la carte
    /// </summary>
    public struct CardTeamCD : IComponentData
    {
        /// <summary>
        /// L'ID de l'équipe
        /// </summary>
        public byte Value;
    }
}