using Assets.Scripts.Models.Cards;
using Unity.Collections;

namespace Assets.Scripts.Models.Player
{
    /// <summary>
    /// Liste de cartes composant un deck
    /// </summary>
    public sealed class DeckRecipe
    {
        #region Propriétés

        /// <summary>
        /// Le nom du deck
        /// </summary>
        public FixedString128Bytes Name { get; set; }

        /// <summary>
        /// Liste de cartes
        /// </summary>
        public CardInventoryInstance[] Cards { get; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name">Le nom du deck</param>
        /// <param name="cards">Liste de cartes</param>
        public DeckRecipe(FixedString128Bytes name, CardInventoryInstance[] cards)
        {
            Name = name;
            Cards = cards;
        }

        #endregion
    }
}