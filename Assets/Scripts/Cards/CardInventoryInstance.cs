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

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="data">Données de la carte</param>=
        /// <param name="rarity">Rareté de la carte</param>
        /// <param name="illustrationID">L'illustration de la carte</param>
        public CardInventoryInstance(CardBaseSO data, CardRarity rarity, uint illustrationID)
        {
            Data = data;
            Rarity = rarity;
            IllustrationID = illustrationID;
        }

        #endregion
    }
}