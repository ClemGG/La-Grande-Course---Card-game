using System;
using System.IO;
using Assets.Scripts.Database;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Chargé de l'inscription / connexion du joueur
    /// </summary>
    public class UserLoginViewModel : MonoBehaviour
    {
        #region Méthodes publiques

        /// <summary>
        /// Tente d'obtenir les identifiants du joueur depuis le cache
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="passwordHash">Mot de passe chiffré</param>
        /// <returns>true si les données ont été récupérées</returns>
        internal bool TryGetCredentialsInCache(out string username, out string passwordHash)
        {
            if (File.Exists(Constants.CREDENTIALS_PATH))
            {
                string json = File.ReadAllText(Constants.CREDENTIALS_PATH, System.Text.Encoding.Unicode);
                UserCredentials credentials = JsonUtility.FromJson<UserCredentials>(json);

                username = credentials.Username;
                passwordHash = credentials.PasswordHash;
                return true;
            }

            username = passwordHash = string.Empty;
            return false;
        }

        /// <summary>
        /// Tente d'obtenir les préférences du joueur depuis le cache
        /// </summary>
        /// <param name="preferences">Préférences du joueur</param>
        /// <returns>true si les données ont été récupérées</returns>
        internal bool TryGetPreferencesInCache(out UserPreferences preferences)
        {
            if (File.Exists(Constants.PREFERENCES_PATH))
            {
                string json = File.ReadAllText(Constants.PREFERENCES_PATH, System.Text.Encoding.Unicode);
                preferences = JsonUtility.FromJson<UserPreferences>(json);
                return true;
            }

            preferences = default;
            return false;
        }

        /// <summary>
        /// Enregistre les identifiants du joueur dans le cache
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        internal void SetCredentialsCache(string username, string password)
        {
            if (!Directory.Exists(Constants.DEFAULT_USER_CACHE_DIR_PATH))
                Directory.CreateDirectory(Constants.DEFAULT_USER_CACHE_DIR_PATH);

            string json = JsonUtility.ToJson(new UserCredentials(username, password), true);
            File.WriteAllText(Constants.CREDENTIALS_PATH, json, System.Text.Encoding.Unicode);
        }

        /// <summary>
        /// Enregistre les préférences du joueur dans le cache
        /// </summary>
        /// <param name="preferences">Préférences du joueur</param>
        internal void SetPreferencesCache(UserPreferences preferences)
        {
            if (!Directory.Exists(Constants.DEFAULT_USER_CACHE_DIR_PATH))
                Directory.CreateDirectory(Constants.DEFAULT_USER_CACHE_DIR_PATH);

            string json = JsonUtility.ToJson(preferences, true);
            File.WriteAllText(Constants.PREFERENCES_PATH, json, System.Text.Encoding.Unicode);
        }

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
            DatabaseHelper.RegisterAsync(username, password, admin, onComplete).WaitForResult(onError);
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
            DatabaseHelper.LoginAsync(username, password, onComplete).WaitForResult(onError);
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