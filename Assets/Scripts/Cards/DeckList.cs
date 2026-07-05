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
        [field: SerializeField]
        public string Name { get; private set; }

        /// <summary>
        /// Liste de cartes
        /// </summary>
        [Tooltip("Liste de cartes")]
        [field: SerializeField]
        public CardDecklistInstance[] Cards { get; private set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name">Le nom du deck</param>
        /// <param name="cards">Liste de cartes</param>
        public DeckList(string name, CardDecklistInstance[] cards)
        {
            Name = name;
            Cards = cards;
        }

        #endregion
    }
}