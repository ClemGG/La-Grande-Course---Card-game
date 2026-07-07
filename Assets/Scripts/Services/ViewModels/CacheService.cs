using System.IO;
using Assets.Scripts.User;
using Assets.Scripts.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// Chargé de la lecture/écriture des fichiers de cache
    /// </summary>
    public static class CacheService
    {
        /// <summary>
        /// Tente d'obtenir les identifiants du joueur depuis le cache
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="passwordHash">Mot de passe chiffré</param>
        /// <returns>true si les données ont été récupérées</returns>
        public static bool TryGetCredentialsInCache(out string username, out string passwordHash)
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
        public static bool TryGetPreferencesInCache(out UserPreferences preferences)
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
        public static void SetCredentialsCache(string username, string password)
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
        public static void SetPreferencesCache(UserPreferences preferences)
        {
            if (!Directory.Exists(Constants.DEFAULT_USER_CACHE_DIR_PATH))
                Directory.CreateDirectory(Constants.DEFAULT_USER_CACHE_DIR_PATH);

            string json = JsonUtility.ToJson(preferences, true);
            File.WriteAllText(Constants.PREFERENCES_PATH, json, System.Text.Encoding.Unicode);
        }
    }
}