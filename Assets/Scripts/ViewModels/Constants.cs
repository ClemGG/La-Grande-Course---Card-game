using UnityEngine;

namespace Assets.Scripts.ViewModels
{
    /// <summary>
    /// Constantes
    /// </summary>
    internal static class Constants
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
        /// Nom du serveur contenant la BDD
        /// </summary>
        internal const string SERVER_NAME = "localhost";

        /// <summary>
        /// Pseudo admin de la BDD
        /// </summary>
        internal const string SERVER_LOGIN = "root";

        /// <summary>
        /// Mdp de la BDD
        /// </summary>
        internal const string SERVER_PASSWORD = "root";

        /// <summary>
        /// Nom de la BDD
        /// </summary>
        internal const string DATABASE_NAME = "la_grande_course";

        /// <summary>
        /// Nom de la table
        /// </summary>
        internal const string CARD_BASE_TABLE = "card_base_table";

        /// <summary>
        /// Nom de la table
        /// </summary>
        internal const string USERS_TABLE = "users_table";

        /// <summary>
        /// Uri d'accès au script d'inscription du joueur
        /// </summary>
        internal const string REGISTER_URI = "http://localhost/php/register.php";

        /// <summary>
        /// Uri d'accès au script de connexion du joueur
        /// </summary>
        internal const string LOGIN_URI = "http://localhost/php/login.php";

        /// <summary>
        /// Uri d'accès au script de déconnexion du joueur
        /// </summary>
        internal const string LOGOUT_URI = "http://localhost/ph/logout.php";

        #endregion
    }
}