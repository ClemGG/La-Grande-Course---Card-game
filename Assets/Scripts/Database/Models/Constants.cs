using UnityEngine;

namespace Assets.Scripts.Database
{
    /// <summary>
    /// Constantes
    /// </summary>
    internal static class Constants
    {
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
        /// Uri d'accès au script de màj des decklists du joueur
        /// </summary>
        internal const string PUT_DECKLISTS_URI = "http://localhost/sqlconnect/put_decklists.php";

        /// <summary>
        /// Uri d'accès au script de récupération des decklists du joueur
        /// </summary>
        internal const string GET_DECKLISTS_URI = "http://localhost/sqlconnect/get_decklists.php";

        /// <summary>
        /// Uri d'accès au script de màj de l'inventaire du joueur
        /// </summary>
        internal const string PUT_CARD_INVENTORY_URI = "http://localhost/sqlconnect/put_card_inventory.php";

        /// <summary>
        /// Uri d'accès au script de récupération de l'inventaire du joueur
        /// </summary>
        internal const string GET_CARD_INVENTORY_URI = "http://localhost/sqlconnect/get_card_inventory.php";

        #endregion
    }
}