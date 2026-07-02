using Assets.Scripts.Cards;
using Unity.Collections;
using UnityEngine;

/// <summary>
/// Représente un paquet de cartes d'une extension
/// </summary>
[CreateAssetMenu(fileName = "New Card Booster", menuName = "Scriptable Objects/La Grande Course/Cards/Booster")]
public sealed class CardBoosterSO : ScriptableObject
{
    /// <summary>
    /// Le nom du paquet
    /// </summary>
    [Tooltip("Le nom du paquet")]
    [field: SerializeField]
    public FixedString128Bytes Name { get; private set; }

    /// <summary>
    /// Liste des cartes contenues dans le paquet.
    /// Les cartes sont prédéterminées pour chaque paquet ; il n'y a pas d'aléatoire.
    /// </summary>
    [Tooltip("Liste des cartes contenues dans le paquet.\nLes cartes sont prédéterminées pour chaque paquet ; il n'y a pas d'aléatoire.")]
    [field: SerializeField]
    public CardBaseSO[] Cards { get; private set; }
}
