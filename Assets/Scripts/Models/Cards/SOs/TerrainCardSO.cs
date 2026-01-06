using UnityEngine;

namespace Assets.Scripts.Models.Cards.SOs
{
    /// <summary>
    /// Représente une carte de type Terrain
    /// </summary>
    [CreateAssetMenu(fileName = "New Terrain Card", menuName = "Scriptable Objects/Cards/Terrain Card")]
    public class TerrainCardSO : ScriptableObject
    {
        /// <summary>
        /// Les statistiques de la carte
        /// </summary>
        [field: SerializeField]
        public CardStats Stats { get; private set; }
    }
}