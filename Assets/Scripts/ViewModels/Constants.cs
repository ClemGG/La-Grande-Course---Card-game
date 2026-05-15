using UnityEngine;

namespace Assets.Scripts.ViewModels
{
    /// <summary>
    /// Constantes
    /// </summary>
    public static class Constants
    {
        #region Login

        /// <summary>
        /// Chemin d'accès par défaut du fichier contenant les infos de login du joueur
        /// </summary>
        internal static readonly string DEFAULT_LOGIN_CACHE_DIR_PATH = $"{Application.streamingAssetsPath}/User/Login/";

        /// <summary>
        /// Chemin d'accès par défaut du fichier contenant les infos de login du joueur
        /// </summary>
        internal const string DEFAULT_LOGIN_CACHE_FILE_NAME = "LoginCache.txt";

        #endregion

        #region SQL

        /// <summary>
        /// Uri d'accès au script d'inscription du joueur
        /// </summary>
        public const string REGISTER_URI = "http://localhost/sqlconnect/register.php";

        /// <summary>
        /// Uri d'accès au script de connexion du joueur
        /// </summary>
        public const string LOGIN_URI = "http://localhost/sqlconnect/login.php";

        /// <summary>
        /// Uri d'accès au script de déconnexion du joueur
        /// </summary>
        public const string LOGOUT_URI = "http://localhost/sqlconnect/logout.php";

        #endregion
    }
}