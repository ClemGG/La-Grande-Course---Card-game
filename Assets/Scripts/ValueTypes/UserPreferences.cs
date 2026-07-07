using System;
using UnityEngine;

namespace Assets.Scripts.ValueTypes
{
    /// <summary>
    /// Préférences d'un joueur
    /// </summary>
    [Serializable]
    public struct UserPreferences
    {
        #region Propriétés

        /// <summary>
        /// L'ID du deck actif dans la liste de decks du joueur
        /// </summary>
        [field: SerializeField]
        public int ActiveDeckID { get; private set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="activeDeckID">L'ID du deck actif dans la liste de decks du joueur</param>
        public UserPreferences(int activeDeckID)
        {
            ActiveDeckID = activeDeckID;
        }

        #endregion
    }
}