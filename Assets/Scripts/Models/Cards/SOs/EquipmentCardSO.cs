using UnityEngine;

namespace Assets.Scripts.Models.Cards.SOs
{
    /// <summary>
    /// Représente une carte de type Equipement
    /// </summary>
    [CreateAssetMenu(fileName = "New Equipement Card", menuName = "Scriptable Objects/Cards/Equipement Card")]
    public class EquipmentCardSO : ScriptableObject
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