using Assets.Scripts.ValueTypes;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Instance d'une carte dans l'inventaire du joueur
    /// </summary>
    public readonly struct CardInventoryInstance
    {
        #region Propriétés

        /// <summary>
        /// Données de la carte
        /// </summary>
        public readonly CardBaseSO Data { get; }

        /// <summary>
        /// Rareté de la carte
        /// </summary>
        public readonly CardRarity Rarity { get; }

        /// <summary>
        /// L'illustration de la carte
        /// </summary>
        public readonly uint IllustrationID { get; }

        /// <summary>
        /// L'ID de l'extension d'où provient la carte
        /// </summary>
        public readonly uint SetID { get; }

        /// <summary>
        /// La position de la carte dans son extension correspondante
        /// </summary>
        public readonly uint SetSlotID { get; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="data">Données de la carte</param>=
        /// <param name="rarity">Rareté de la carte</param>
        /// <param name="illustrationID">L'illustration de la carte</param>
        /// <param name="setID">L'ID de l'extension d'où provient la carte</param>
        /// <param name="setSlotID">La position de la carte dans son extension correspondante</param>
        public CardInventoryInstance(CardBaseSO data, CardRarity rarity, uint illustrationID, uint setID, uint setSlotID)
        {
            Data = data;
            Rarity = rarity;
            IllustrationID = illustrationID;
            SetID = setID;
            SetSlotID = setSlotID;
        }

        #endregion
    }
}