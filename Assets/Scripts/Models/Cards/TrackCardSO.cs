using Assets.Scripts.Models.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Models.Cards
{
    /// <summary>
    /// Représente une carte de type Circuit
    /// </summary>
    [CreateAssetMenu(fileName = "New Terrain Card", menuName = "Scriptable Objects/Cards/Terrain Card")]
    public sealed class TrackCardSO : CardBaseSO
    {
        /// <summary>
        /// Les statistiques de la carte
        /// </summary>
        [field: SerializeField]
        public CardStats Stats { get; private set; }
    }
}