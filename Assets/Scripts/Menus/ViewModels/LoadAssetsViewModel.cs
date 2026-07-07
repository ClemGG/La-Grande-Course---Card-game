using System;
using Assets.Scripts.Database;
using UnityEngine;

namespace Assets.Scripts.Menus
{
    /// <summary>
    /// Contrôleur du LoadAssetsView
    /// </summary>
    public class LoadAssetsViewModel : MonoBehaviour
    {
        #region Méthodes publiques

        /// <summary>
        /// Charge les assets du jeu en asynchrone
        /// </summary>
        /// <param name="onComplete">Appelée une fois les assets chargées</param>
        public void LoadAssets(Action onComplete)
        {
            DatabaseHelper.LoadCardsAsync();
            onComplete?.Invoke();
        }

        #endregion
    }
}