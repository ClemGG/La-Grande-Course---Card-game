using System;

namespace Assets.Scripts.Models.Cards
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
}