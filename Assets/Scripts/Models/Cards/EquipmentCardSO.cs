using Assets.Scripts.Models.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Models.Cards
{
    /// <summary>
    /// Représente une carte de type Equipement
    /// </summary>
    [CreateAssetMenu(fileName = "New Equipement Card", menuName = "Scriptable Objects/La Grande Course/Cards/Equipement Card")]
    public sealed class EquipmentCardSO : CardBaseSO
    {
        /// <summary>
        /// Le type d'équipement de la carte
        /// </summary>
        [field: SerializeField]
        public EquipCardType Type { get; private set; }

        /// <summary>
        /// Les statistiques de la carte
        /// </summary>
        [field: SerializeField]
        public CardStats Stats { get; private set; }
    }
}