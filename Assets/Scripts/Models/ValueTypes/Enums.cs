using System;

namespace Assets.Scripts.Models.ValueTypes
{
    /// <summary>
    /// Indique la ou les factions de la carte
    /// </summary>
    [Flags]
    public enum CardPurity : long
    {
        Generic = 0,
        Team1 = 1,
        Team2 = 2,
        Team3 = 3,
        Team4 = 4,
        Team5 = 5
    }

    /// <summary>
    /// La liste des types possibles pour une carte Equipement
    /// </summary>
    public enum EquipCardType : byte
    {
        Mode,
        Outfit,
        Module
    }
}