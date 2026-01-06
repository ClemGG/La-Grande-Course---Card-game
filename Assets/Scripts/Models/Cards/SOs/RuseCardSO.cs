using UnityEngine;

namespace Assets.Scripts.Models.Cards.SOs
{
    /// <summary>
    /// Représente une carte de type Ruse
    /// </summary>
    [CreateAssetMenu(fileName = "New Ruse Card", menuName = "Scriptable Objects/Cards/Ruse Card")]
    public class RuseCardSO : ScriptableObject
    {
        /// <summary>
        /// Les statistiques de la carte
        /// </summary>
        [field: SerializeField]
        public CardStats Stats { get; private set; }

        /// <summary>
        /// TRUE si la carte possède des stats
        /// </summary>
        public bool HasStats => Stats.Speed == 0 && Stats.Style == 0 && Stats.Technique == 0;
    }
}