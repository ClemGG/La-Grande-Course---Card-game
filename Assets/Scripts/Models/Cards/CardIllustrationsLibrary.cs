using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Assets.Scripts.Models.Cards
{
    /// <summary>
    /// Rassemble les illustrations alternatives pour chaque carte
    /// </summary>
    [CreateAssetMenu(fileName = "Card Illustrations Library", menuName = "Scriptable Objects/La Grande Course/Card Illustrations Library")]
    public class CardIllustrationsLibrary : ScriptableObject
    {
        /// <summary>
        /// Les illustrations alternatives pour chaque carte
        /// </summary>
        [Tooltip("Les illustrations alternatives pour chaque carte")]
        [field: SerializeField]
        [field: SerializedDictionary("Card", "Alt Arts")]
        public SerializedDictionary<CardBaseSO, Sprite[]> Illustrations { get; private set; }
    }
}