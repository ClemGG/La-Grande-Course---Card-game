using Assets.Scripts.Cards;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Inventaire de cartes du joueur
    /// </summary>
    public static class CardInventory
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