using Assets.Scripts.Models.Cards;

namespace Assets.Scripts.Models.Player
{
    /// <summary>
    /// Inventaire de cartes du joueur
    /// </summary>
    public static class CardInventory
    {
        /// <summary>
        /// Liste de cartes
        /// </summary>
        public static CardInstance[] Cards { get; }

        /// <summary>
        /// Nombre de copies par carte, pour éviter d'avoir à dupliquer les données
        /// </summary>
        public static int[] NbCopiesPerCard { get; }
    }
}