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
    public class CardSetSO : ScriptableObject
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
        [field: SerializeField]
        public int ID { get; private set; }

        /// <summary>
        /// Le taux d'apparition de chaque rareté
        /// </summary>
        [Tooltip("Le taux d'apparition de chaque rareté")]
        [field: SerializeField]
        public ItemSelectionChance<CardRarity>[] RarityRates { get; private set; }

        /// <summary>
        /// Liste des cartes communes de l'extension
        /// </summary>
        [Tooltip("Liste des cartes communes de l'extension")]
        [field: SerializeField]
        public CardBaseSO[] CommonCards { get; private set; }

        /// <summary>
        /// Liste des cartes peu communes de l'extension
        /// </summary>
        [Tooltip("Liste des cartes communes de l'extension")]
        [field: SerializeField]
        public CardBaseSO[] UnommonCards { get; private set; }

        /// <summary>
        /// Liste des cartes rares de l'extension
        /// </summary>
        [Tooltip("Liste des cartes rares de l'extension")]
        [field: SerializeField]
        public CardBaseSO[] RareCards { get; private set; }

        /// <summary>
        /// Liste des cartes chromatiques de l'extension
        /// </summary>
        [Tooltip("Liste des cartes chromatiques de l'extension")]
        [field: SerializeField]
        public CardBaseSO[] ChromaticCards { get; private set; }
    }
}