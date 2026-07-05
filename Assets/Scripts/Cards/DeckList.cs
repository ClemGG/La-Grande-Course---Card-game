using System;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Recette référençant la liste de cartes composant un deck
    /// </summary>
    [Serializable]
    public struct DeckList
    {
        #region Propriétés

        /// <summary>
        /// Le nom du deck
        /// </summary>
        [Tooltip("Le nom du deck")]
        public string Name;

        /// <summary>
        /// Liste de cartes
        /// </summary>
        [Tooltip("Liste de cartes")]
        public CardDecklistInstance[] Cards;

        #endregion
    }
}