using System;
using System.IO;
using Assets.Scripts.Models.Player;
using Assets.Scripts.ViewModels.Database;
using UnityEngine;

namespace Assets.Scripts.ViewModels.User
{
    /// <summary>
    /// Chargé de l'inscription / connexion du joueur
    /// </summary>
    public class UserLoginViewModel : MonoBehaviour
    {
        #region Propriétés

        /// <summary>
        /// Chemin d'accès complet
        /// </summary>
        private string Path => $"{Constants.DEFAULT_LOGIN_CACHE_DIR_PATH}{Constants.DEFAULT_LOGIN_CACHE_FILE_NAME}";

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Tente d'obtenir les identifiants du joueur depuis le cache
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <returns>true si les données ont été récupérées</returns>
        public bool TryGetCredentials(out string username, out string password, out bool admin)
        {
            if (File.Exists(Path))
            {
                string json = File.ReadAllText(Path, System.Text.Encoding.Unicode);
                UserCredentials credentials = JsonUtility.FromJson<UserCredentials>(json);

                username = credentials.Username;
                password = credentials.Password;
                admin = credentials.Admin;
                return true;
            }

            username = password = string.Empty;
            admin = false;
            return false;
        }

        /// <summary>
        /// Enregistre les identifiants du joueur dans le cache
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        public void SetCredentialsCache(string username, string password, bool admin)
        {
            if (!Directory.Exists(Constants.DEFAULT_LOGIN_CACHE_DIR_PATH))
            {
                Directory.CreateDirectory(Constants.DEFAULT_LOGIN_CACHE_DIR_PATH);
            }

            string json = JsonUtility.ToJson(new UserCredentials(username, password, admin), true);
            File.WriteAllText(Path, json, System.Text.Encoding.Unicode);
        }

        /// <summary>
        /// Enregistre l'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        /// <param name="onError">Appelée quand une exception est levée</param>
        public void Register(string username, string password, bool admin, Action onComplete, Action<Exception> onError)
        {
            DatabaseHelper.RegisterAsync(username, password, admin, onComplete).WaitForResult(onError);
        }

        /// <summary>
        /// Connecte l'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <param name="onError">Appelée quand une exception est levée</param>
        public void Login(string username, string password, bool admin, Action onComplete, Action<Exception> onError)
        {

        }

        #endregion
    }
}