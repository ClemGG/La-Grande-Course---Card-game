using System;
using UnityEngine;

namespace Assets.Scripts.Models.Cards
{
    /// <summary>
    /// Les statistiques d'une' carte
    /// </summary>
    [Serializable]
    public struct CardStats
    {
        /// <summary>
        /// La statistique de vitesse de la carte
        /// </summary>
        [field: SerializeField]
        public byte Speed { get; private set; }

        /// <summary>
        /// La statistique de style de la carte
        /// </summary>
        [field: SerializeField]
        public byte Style { get; private set; }

        /// <summary>
        /// La statistique de technique de la carte
        /// </summary>
        [field: SerializeField]
        public byte Technique { get; private set; }
    }
}