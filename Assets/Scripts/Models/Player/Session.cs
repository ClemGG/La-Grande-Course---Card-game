using Unity.Collections;

namespace Assets.Scripts.Models.Player
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
        public static FixedString128Bytes UserName { get; set; }

        /// <summary>
        /// Les decks du joueur
        /// </summary>
        public static DeckRecipe[] DeckRecipes { get; set; }

        /// <summary>
        /// Mot de passe du joueur
        /// </summary>
        public static FixedString64Bytes Password
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

        #endregion

        #region Variables statiques

        /// <summary>
        /// Mot de passe du joueur
        /// </summary>
        private static FixedString64Bytes _password;

        /// <summary>
        /// true si le compte est un admin
        /// </summary>
        private static bool _admin;

        #endregion
    }
}