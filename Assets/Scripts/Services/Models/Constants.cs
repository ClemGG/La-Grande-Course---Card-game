using UnityEngine;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Constantes
    /// </summary>
    internal class Constants
    {
        #region IO

        /// <summary>
        /// Chemin d'accès par défaut du fichier contenant les infos du joueur (login, préférences...)
        /// </summary>
        internal static readonly string DEFAULT_USER_CACHE_DIR_PATH = $"{Application.streamingAssetsPath}/User/";

        /// <summary>
        /// Chemin d'accès par défaut du fichier contenant les infos de login du joueur
        /// </summary>
        internal const string DEFAULT_CREDENTIALS_CACHE_FILE_NAME = "CredentialsCache.txt";

        /// <summary>
        /// Chemin d'accès par défaut du fichier contenant les préférences du joueur
        /// </summary>
        internal const string DEFAULT_PREFERENCES_CACHE_FILE_NAME = "PreferencesCache.txt";

        /// <summary>
        /// Chemin d'accès complet
        /// </summary>
        internal static readonly string CREDENTIALS_PATH = $"{Constants.DEFAULT_USER_CACHE_DIR_PATH}{Constants.DEFAULT_CREDENTIALS_CACHE_FILE_NAME}";

        /// <summary>
        /// Chemin d'accès complet
        /// </summary>
        internal static readonly string PREFERENCES_PATH = $"{Constants.DEFAULT_USER_CACHE_DIR_PATH}{Constants.DEFAULT_PREFERENCES_CACHE_FILE_NAME}";

        #endregion
    }
}