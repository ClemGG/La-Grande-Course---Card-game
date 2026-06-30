using Assets.Scripts.Cards;

namespace Assets.Scripts.Database
{
    /// <summary>
    /// Contient l'ensemble des objets présents dans la BDD
    /// (cartes, etc.)
    /// </summary>
    public static class GameAssets
    {
        #region Propriétés

        /// <summary>
        /// Liste de toutes les cartes Coureur
        /// </summary>
        public static RacerCardSO[] RacerCards { get; set; }

        /// <summary>
        /// Liste de toutes les cartes Circuit
        /// </summary>
        public static TrackCardSO[] TrackCards { get; set; }

        /// <summary>
        /// Liste de toutes les cartes Compétence
        /// </summary>
        public static SkillCardSO[] SkillCards { get; set; }

        /// <summary>
        /// Liste de toutes les cartes Equipement
        /// </summary>
        public static EquipmentCardSO[] EquipmentCards { get; set; }

        /// <summary>
        /// Liste de toutes les cartes Ruse
        /// </summary>
        public static RuseCardSO[] RuseCards { get; set; }

        #endregion
    }
}