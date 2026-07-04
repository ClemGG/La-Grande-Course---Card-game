using System.Collections.Generic;
using Assets.Scripts.Cards;

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
        public List<DecklistSO> Decklists { get; private set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="decklists">Les decks du joueur</param>
        public UserDecklists(DecklistSO[] userDecklists)
        {
            Decklists = new List<DecklistSO>(userDecklists);
        }

        #endregion
    }
}