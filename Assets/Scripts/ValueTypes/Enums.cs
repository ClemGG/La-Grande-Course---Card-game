using System;

namespace Assets.Scripts.ValueTypes
{
    /// <summary>
    /// Indique la ou les factions de la carte
    /// </summary>
    [Flags]
    public enum CardPurity
    {
        Generic = 0,
        Team1 = 1,
        Team2 = 2,
        Team3 = 4,
        Team4 = 8,
        Team5 = 16
    }

    /// <summary>
    /// La liste des types possibles pour une carte Equipement
    /// </summary>
    public enum EquipCardType
    {
        Mode = 0,
        Outfit = 1,
        Module = 2
    }

    /// <summary>
    /// La rareté d'une carte. 
    /// Vu qu'on utilise pas de boosters avec une répartition aléatoire des cartes,
    /// ça offre juste des variantes visuelles d'une carte.
    /// </summary>
    public enum CardRarity
    {
        Common,
        Uncommon,
        Rare,

        /// <summary>
        /// La plus haute rareté pour les cartes distribuée normalement
        /// </summary>
        Chromatic,

        /// <summary>
        /// Distribué uniquement lors d'événements
        /// </summary>
        Promo,

        /// <summary>
        /// Identique à Promo, sauf qu'il n'en existe qu'une seule copie
        /// </summary>
        Unique
    }
}