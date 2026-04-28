using Assets.Scripts.Models.Cards;
using Assets.Scripts.Models.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Models.Decks
{
    /// <summary>
    /// Liste de cartes composant un deck
    /// </summary>
    [CreateAssetMenu(fileName = "New Deck List", menuName = "Scriptable Objects/La Grande Course/Deck List")]
    public class DeckList : ScriptableObject
    {
        /// <summary>
        /// Le nom du deck
        /// </summary>
        [field: SerializeField]
        public string Name { get; private set; }

        /// <summary>
        /// Liste de cartes
        /// </summary>
        [field: SerializeField]
        public CardBaseSO[] Cards { get; private set; }

        /// <summary>
        /// Liste de raretés par carte
        /// </summary>
        [field: SerializeField]
        public CardRarity[] Rarities { get; private set; }

        /// <summary>
        /// Les IDs des illustrations de chaque carte
        /// </summary>
        [field: SerializeField]
        public uint[] IllustrationsIDs { get; private set; }
    }
}