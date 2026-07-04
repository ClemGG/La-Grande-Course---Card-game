using UnityEngine;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Recette référençant la liste de cartes composant un deck
    /// </summary>
    [CreateAssetMenu(fileName = "New Deck List", menuName = "Scriptable Objects/La Grande Course/Cards/Deck List")]
    public sealed class DecklistSO : ScriptableObject
    {
        #region Propriétés

        /// <summary>
        /// Le nom du deck
        /// </summary>
        [Tooltip("Le nom du deck")]
        [field: SerializeField]
        public string Name { get; set; }

        /// <summary>
        /// Liste de cartes
        /// </summary>
        [Tooltip("Liste de cartes")]
        [field: SerializeField]
        public CardDecklistInstance[] Cards { get; private set; }

        #endregion
    }
}