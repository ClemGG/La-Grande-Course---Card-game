using System;
using Assets.Scripts.ValueTypes;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    /// <summary>
    /// Instance d'une carte dans une recette de deck
    /// </summary>
    [Serializable]
    public struct CardDecklistInstance
    {
        #region Propriétés

        /// <summary>
        /// L'ID de l'extension d'où provient la carte
        /// </summary>
        [Tooltip("L'ID de l'extension d'où provient la carte")]
        [field: SerializeField, Min(1)]
        public uint SetID { get; private set; }

        /// <summary>
        /// La position de la carte dans son extension correspondante
        /// </summary>
        [Tooltip("La position de la carte dans son extension correspondante")]
        [field: SerializeField, Min(1)]
        public uint SetSlotID { get; private set; }

        /// <summary>
        /// L'illustration de la carte
        /// </summary>
        [Tooltip("L'illustration de la carte")]
        [field: SerializeField]
        public uint IllustrationID { get; private set; }

        /// <summary>
        /// Rareté de la carte
        /// </summary>
        [Tooltip("Rareté de la carte")]
        [field: SerializeField]
        public CardRarity Rarity { get; private set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="rarity">Rareté de la carte</param>
        /// <param name="illustrationID">L'illustration de la carte</param>
        /// <param name="setID">L'ID de l'extension d'où provient la carte</param>
        /// <param name="setSlotID">La position de la carte dans son extension correspondante</param>
        public CardDecklistInstance(CardRarity rarity, uint illustrationID, uint setID, uint setSlotID)
        {
            Rarity = rarity;
            IllustrationID = illustrationID;
            SetID = setID;
            SetSlotID = setSlotID;
        }

        #endregion
    }
}