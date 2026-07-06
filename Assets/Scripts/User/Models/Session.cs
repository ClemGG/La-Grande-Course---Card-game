using System;
using System.Collections.Generic;
using Assets.Scripts.Cards;
using Unity.Collections;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Données de la session active d'un joueur
    /// </summary>
    public static class Session
    {
        #region Propriétés

        /// <summary>
        /// Nom d'utilisateur
        /// </summary>
        public static string UserName { get; private set; }

        /// <summary>
        /// L'ID du deck actif dans la liste de decks du joueur
        /// </summary>
        public static int ActiveDeckID { get; private set; }

        /// <summary>
        /// Les decks du joueur
        /// </summary>
        public static UserDecklists Decks { get; private set; }

        /// <summary>
        /// Mot de passe du joueur
        /// </summary>
        public static string Password
        {
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// true si le compte est un admin
        /// </summary>
        public static bool Admin
        {
            set
            {
                _admin = value;
            }
        }

        /// <summary>
        /// true si le compte vient d'être créé
        /// </summary>
        public static bool NewAccount { get; set; }

        #endregion

        #region Variables statiques

        /// <summary>
        /// Mot de passe du joueur
        /// </summary>
        private static string _password;

        /// <summary>
        /// true si le compte est un admin
        /// </summary>
        private static bool _admin;

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Assigne les données de l'utilisateur pour la session active
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <param name="newAccount">true si le compte vient d'être créé</param>
        internal static void SetUserCredentials(string username, string password, bool admin, bool newAccount = false)
        {
            UserName = username;
            Password = password;
            Admin = admin;
            NewAccount = newAccount;
        }

        /// <summary>
        /// Assigne les données de l'utilisateur pour la session active
        /// </summary>
        /// <param name="decks">Les decks du joueur</param>
        internal static void SetUserDecklists(UserDecklists decks)
        {
            Decks = decks;
        }

        /// <summary>
        /// Assigne les préférences du joueur
        /// </summary>
        /// <param name="preferences">Préférences du joueur</param>
        internal static void SetUserPreferences(UserPreferences preferences)
        {
            ActiveDeckID = preferences.ActiveDeckID;
        }

        #endregion
    }
}