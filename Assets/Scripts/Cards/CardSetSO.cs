using Assets.Scripts.ValueTypes;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Représente une extension contenant une liste de cartes
    /// ainsi que les ratios de rareté de chacune
    /// </summary>
    [CreateAssetMenu(fileName = "New Set", menuName = "Scriptable Objects/La Grande Course/Cards/Set")]
    public sealed class CardSetSO : ScriptableObject
    {
        /// <summary>
        /// Le nom de l'extension
        /// </summary>
        [Tooltip("Le nom de l'extension")]
        [field: SerializeField]
        public FixedString128Bytes Name { get; private set; }

        /// <summary>
        /// L'ID de l'extension
        /// </summary>
        [Tooltip("L'ID de l'extension")]
        [field: SerializeField, Min(1)]
        public int ID { get; private set; }

        /// <summary>
        /// Le taux d'apparition de chaque rareté
        /// </summary>
        [Tooltip("Le taux d'apparition de chaque rareté")]
        [field: SerializeField]
        public ItemSelectionChance<CardRarity>[] RarityRates { get; private set; }

        /// <summary>
        /// Liste des cartes peu communes de l'extension
        /// </summary>
        [Tooltip("Liste des paquets de l'extension")]
        [field: SerializeField]
        public CardBoosterSO[] Boosters { get; private set; }
    }
}