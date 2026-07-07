using Assets.Scripts.Cards;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Inventaire du joueur
    /// </summary>
    public static class UserInventory
    {
        /// <summary>
        /// Liste de cartes
        /// </summary>
        public static CardInventoryInstance[] Cards { get; }

        /// <summary>
        /// Nombre de copies par carte, pour éviter d'avoir à dupliquer les données
        /// </summary>
        public static int[] NbCopiesPerCard { get; }
    }
}