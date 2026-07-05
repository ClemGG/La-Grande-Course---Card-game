using UnityEngine;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Asset référençant la liste de cartes composant un deck
    /// </summary>
    [CreateAssetMenu(fileName = "New Deck List", menuName = "Scriptable Objects/La Grande Course/Cards/Deck List")]
    public sealed class DeckListSO : ScriptableObject
    {
        #region Propriétés

        /// <summary>
        /// La recette
        /// </summary>
        [Tooltip("La recette")]
        [SerializeField]
        public DeckList Value;

        #endregion
    }
}