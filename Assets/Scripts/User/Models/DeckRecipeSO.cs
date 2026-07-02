using Assets.Scripts.Cards;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Recette référençant la liste de cartes composant un deck
    /// </summary>
    [CreateAssetMenu(fileName = "New Deck Recipe", menuName = "Scriptable Objects/La Grande Course/Cards/Deck Recipe")]
    public sealed class DeckRecipeSO : ScriptableObject
    {
        #region Propriétés

        /// <summary>
        /// Le nom du deck
        /// </summary>
        [Tooltip("Le nom du deck")]
        [field: SerializeField]
        public FixedString128Bytes Name { get; set; }

        /// <summary>
        /// Liste de cartes
        /// </summary>
        [Tooltip("Liste de cartes")]
        [field: SerializeField]
        public CardInventoryInstance[] Cards { get; private set; }

        #endregion
    }
}