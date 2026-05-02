using System;
using UnityEngine;

namespace Assets.Scripts.Models.Player
{
    /// <summary>
    /// Identifiants d'un joueur
    /// </summary>
    [Serializable]
    public struct UserCredentials
    {
        /// <summary>
        /// Nom d'utilisateur
        /// </summary>
        [field: SerializeField]
        public string Username { get; private set; }

        /// <summary>
        /// Mot de passe
        /// </summary>
        [field: SerializeField]
        public string Password { get; private set; }

        /// <summary>
        /// true si l'utilisateur est un admin
        /// </summary>
        [field: SerializeField]
        public bool Admin { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur est un admin</param>
        public UserCredentials(string username, string password, bool admin)
        {
            Username = username;
            Password = password;
            Admin = admin;
        }
    }
}