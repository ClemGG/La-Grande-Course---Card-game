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
        [field: SerializeField]
        public List<Decklist> Value { get; private set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public UserDecklists(List<Decklist> value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="decklists">Les decks du joueur</param>
        public UserDecklists(Decklist[] decklists)
        {
            Value = new List<Decklist>(decklists);
            Value.AddRange(decklists);
        }

        #endregion
    }
}