using Assets.Scripts.Models.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Models.Cards
{
    /// <summary>
    /// Représente une carte de type Coureur
    /// </summary>
    [CreateAssetMenu(fileName = "New Racer Card", menuName = "Scriptable Objects/Cards/Racer Card")]
    public class RacerCardSO : CardBaseSO
    {
        /// <summary>
        /// Les statistiques de la carte
        /// </summary>
        [field: SerializeField]
        public CardStats Stats { get; private set; }
    }
}