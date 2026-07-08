using System;
using Assets.Scripts.Extensions;
using Assets.Scripts.Services;
using Assets.Scripts.User;
using Assets.Scripts.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Menus
{
    /// <summary>
    /// Chargé de l'inscription / connexion du joueur
    /// </summary>
    public class UserLoginViewModel : MonoBehaviour
    {
        #region Méthodes publiques

        /// <summary>
        /// Enregistre l'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        /// <param name="onError">Appelée quand une exception est levée</param>
        internal void Register(string username, string password, bool admin, Action onComplete, Action<Exception> onError)
        {
            DatabaseService.RegisterAsync(username, password, admin, onComplete).WaitForResult(onError);
        }

        /// <summary>
        /// Connecte l'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        /// <param name="onError">Appelée quand une exception est levée</param>
        internal void Login(string username, string password, Action<string> onComplete, Action<Exception> onError)
        {
            DatabaseService.LoginAsync(username, password, onComplete).WaitForResult(onError);
        }

        /// <summary>
        /// Ecrit les données dans le cache
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="preferences">Préférences du joueur</param>
        internal void WriteToCache(string username, string password, out UserPreferences preferences)
        {
            if (!CacheService.TryGetPreferencesInCache(out preferences))
            {
                CacheService.SetPreferencesCache(preferences);
            }

            CacheService.SetCredentialsCache(username, PasswordEncryptionService.Encrypt(password, username));
        }

        /// <summary>
        /// Assigne les données de la session
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <param name="newAccount">true si le compte vient d'être créé</param>
        /// <param name="userDecklists">Les decks du joueur</param>
        /// <param name="preferences">Préférences du joueur</param>
        internal void SetSessionUserData(string username, string password, bool admin, bool newAccount, UserDecklists userDecklists, UserPreferences preferences)
        {
            Session.SetUserCredentials(username, password, admin, newAccount);
            Session.SetUserDecklists(userDecklists);
            Session.SetUserPreferences(preferences);
        }

        #endregion
    }
}