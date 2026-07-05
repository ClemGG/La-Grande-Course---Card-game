using System.Collections.Generic;
using Assets.Scripts.Cards;
using UnityEngine;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Liste des decks d'un joueur
    /// </summary>
    public struct UserDecklists
    {
        #region Propriétés

        /// <summary>
        /// Les decks du joueur
        /// </summary>
        [SerializeField]
        public List<DeckList> Value;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public UserDecklists(List<DeckList> value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="decklists">Les decks du joueur</param>
        public UserDecklists(DeckList[] decklists)
        {
            Value = new List<DeckList>(decklists);
            Value.AddRange(decklists);
        }

        #endregion
    }
}