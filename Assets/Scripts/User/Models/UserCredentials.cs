using System;
using UnityEngine;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Identifiants d'un joueur
    /// </summary>
    [Serializable]
    public struct UserCredentials
    {
        #region Propriétés

        /// <summary>
        /// Nom d'utilisateur
        /// </summary>
        [field: SerializeField]
        public string Username { get; private set; }

        /// <summary>
        /// Mot de passe
        /// </summary>
        [field: SerializeField]
        public string PasswordHash { get; private set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="passwordHash">Mot de passe chiffré</param>
        public UserCredentials(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        #endregion
    }
}