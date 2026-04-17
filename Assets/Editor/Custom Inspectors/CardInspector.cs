using Assets.Scripts.Models.Cards;
using UnityEngine;

namespace Assets.Editor.CustomInspectors
{
    /// <summary>
    /// Inspecteur personnalisé pour les cartes
    /// </summary>
    public abstract class CardInspector<T> : UnityEditor.Editor where T : CardBaseSO
    {
        #region Propriétés

        /// <summary>
        /// Sprite vide à afficher par défaut quand aucune illustration n'est assignée à la carte
        /// </summary>
        protected Sprite _defaultSprite;

        /// <summary>
        /// Obtient le ScriptableObject inspecté
        /// </summary>
        protected T Card => target as T;

        #endregion

        #region Méthodes Unity

        /// <summary>
        /// Appelée à l'ouverture de l'inspecteur
        /// </summary>
        protected virtual void OnEnable()
        {
            _defaultSprite = Sprite.Create(new Texture2D(1, 1), new Rect(0.0f, 0.0f, 1, 1), new Vector2(0.5f, 0.5f), 100.0f);
        }

        #endregion
    }
}