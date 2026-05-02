using Assets.Scripts.Models.ValueTypes;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Models.Cards
{
    /// <summary>
    /// Classe mère des SOs des différents types de carte
    /// </summary>
    public abstract class CardBaseSO : ScriptableObject
    {
        /// <summary>
        /// Le nom de la carte
        /// </summary>
        [Tooltip("Le nom de la carte")]
        [field: SerializeField]
        public FixedString128Bytes Name { get; private set; }

        /// <summary>
        /// La description de l'effet de la carte
        /// </summary>
        [Tooltip("La description de l'effet de la carte")]
        [field: SerializeField, TextArea(3, 5)]
        public string EffectDescription { get; private set; }

        /// <summary>
        /// La description du lore de la carte
        /// </summary>
        [Tooltip("La description du lore de la carte")]
        [field: SerializeField, TextArea(3, 3)]
        public string FlavourDescription { get; private set; }

        /// <summary>
        /// Indique la ou les factions de la carte
        /// </summary>
        [Tooltip("Indique la ou les factions de la carte")]
        [field: SerializeField]
        public CardPurity Purity { get; private set; }
    }
}