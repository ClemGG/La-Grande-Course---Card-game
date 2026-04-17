using System;

namespace Assets.Scripts.Models.ValueTypes
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
        Mode,
        Outfit,
        Module
    }
}