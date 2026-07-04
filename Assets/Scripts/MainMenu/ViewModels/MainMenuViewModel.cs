using System;
using Assets.Scripts.Database;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    /// <summary>
    /// Chargé de la gestion du menu d'accueil
    /// </summary>
    public class MainMenuViewModel : MonoBehaviour
    {
        #region Méthodes publiques

        /// <summary>
        /// Déconnecte l'utilisateur
        /// </summary>
        /// <param name="onComplete">Appelée une fois la déconnexion réussie</param>
        /// <param name="onError">Appelée si une erreur se produit pendant une opération</param>
        public void Logout(Action onComplete, Action<Exception> onError)
        {
            // TAF: Déconnecter l'utilisateur
            // et enregistrer ses changements
            DatabaseHelper.LogoutAsync(onComplete).WaitForResult(onError);
        }

        #endregion
    }
}