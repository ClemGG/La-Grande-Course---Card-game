using Assets.Scripts.Attributes;
using Assets.Scripts.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Classe mère des SOs des différents types de carte
    /// </summary>
    public abstract class CardBaseSO : ScriptableObject
    {
        /// <summary>
        /// L'ID de la carte dans la bdd
        /// </summary>
        [Tooltip("L'ID de la carte dans la bdd")]
        [field: SerializeField, GreyOut]
        public int ID { get; private set; } = -1;

        /// <summary>
        /// Le nom de la carte
        /// </summary>
        [Tooltip("Le nom de la carte")]
        [field: SerializeField]
        public string Name { get; private set; }

        /// <summary>
        /// Les différentes illustrations associées à cette carte
        /// </summary>
        [Tooltip("Les différentes illustrations associées à cette carte")]
        [field: SerializeField]
        public Sprite[] Illustrations { get; private set; }

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