using UnityEngine;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// Constantes
    /// </summary>
    internal class Constants
    {
        #region Log Msgs

        /// <summary>
        /// Chemin d'accès par défaut du fichier contenant les infos du joueur (login, préférences...)
        /// </summary>
        internal const string CARD_TYPE_NOT_IMPLEMENTED_ERR = "Erreur: La carte \"{0}\" ne peut pas être msie en ligne car son type \"{1}\" n'est pas encore implémenté.";

        #endregion

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

        #region SQL

        /// <summary>
        /// Uri d'accès au script d'inscription du joueur
        /// </summary>
        internal const string REGISTER_URI = "http://localhost/sqlconnect/register.php";

        /// <summary>
        /// Uri d'accès au script de connexion du joueur
        /// </summary>
        internal const string LOGIN_URI = "http://localhost/sqlconnect/login.php";

        /// <summary>
        /// Uri d'accès au script de déconnexion du joueur
        /// </summary>
        internal const string LOGOUT_URI = "http://localhost/sqlconnect/logout.php";

        /// <summary>
        /// Uri d'accès au script de màj de l'inventaire du joueur
        /// </summary>
        internal const string CREATE_OR_UPDATE_CARD_URI = "http://localhost/sqlconnect/createOrUpdateCard.php";

        /// <summary>
        /// Nom de la table des cartes Coureur
        /// </summary>
        internal const string RACERS_CARDS_TABLE_NAME = "racer_cards_table";

        /// <summary>
        /// Nom de la table des cartes Piste
        /// </summary>
        internal const string TRACK_CARDS_TABLE_NAME = "track_cards_table";

        /// <summary>
        /// Nom de la table des cartes Compétence
        /// </summary>
        internal const string SKILL_CARDS_TABLE_NAME = "skill_cards_table";

        /// <summary>
        /// Nom de la table des cartes Equipement
        /// </summary>
        internal const string EQUIP_CARDS_TABLE_NAME = "equip_cards_table";

        /// <summary>
        /// Nom de la table des cartes Ruse
        /// </summary>
        internal const string RUSE_CARDS_TABLE_NAME = "ruse_cards_table";

        #endregion
    }
}