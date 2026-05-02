using Assets.Scripts.Models.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Models.Cards
{
    /// <summary>
    /// Représente une carte de type Ruse
    /// </summary>
    [CreateAssetMenu(fileName = "New Ruse Card", menuName = "Scriptable Objects/La Grande Course/Cards/Ruse Card")]
    public sealed class RuseCardSO : CardBaseSO
    {
        /// <summary>
        /// Les statistiques de la carte
        /// </summary>
        [Tooltip("Les statistiques de la carte")]
        [field: SerializeField]
        public CardStats Stats { get; private set; }
    }
}