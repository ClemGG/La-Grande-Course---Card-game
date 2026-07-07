using UnityEngine;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Asset référençant la liste de cartes composant un deck
    /// </summary>
    [CreateAssetMenu(fileName = "New Deck List", menuName = "Scriptable Objects/La Grande Course/Cards/Deck List")]
    public sealed class DecklistSO : ScriptableObject
    {
        #region Propriétés

        /// <summary>
        /// La recette
        /// </summary>
        [Tooltip("La recette")]
        [field: SerializeField]
        public Decklist Value { get; private set; }

        #endregion
    }
}