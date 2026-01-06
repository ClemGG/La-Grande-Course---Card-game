using UnityEngine;

namespace Assets.Scripts.Models.Cards.SOs
{
    /// <summary>
    /// Représente une carte de type Supporter
    /// </summary>
    [CreateAssetMenu(fileName = "New Supporter Card", menuName = "Scriptable Objects/Cards/Supporter Card")]
    public class SupporterCardSO : ScriptableObject
    {
        /// <summary>
        /// La durée en nb de tours de la carte
        /// </summary>
        [field: SerializeField]
        public byte DurationInNbTurns { get; private set; }
    }
}