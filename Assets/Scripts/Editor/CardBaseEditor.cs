using System;
using Assets.Scripts.Cards;
using Assets.Scripts.Extensions;
using Assets.Scripts.Services;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    /// <summary>
    /// CustomInspector pour pouvoir envoyer les cartes dans la bdd
    /// depuis leur inspecteur
    /// </summary>
    [CustomEditor(typeof(CardBaseSO), true)]
    public sealed class CardBaseEditor : UnityEditor.Editor
    {
        #region Méthodes publiques

        /// <summary>
        /// Affiche le contenu de l'inspector
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Upload to Database"))
            {
                OnSendBtnClick();
            }
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Appelée quand on clique sur le bouton
        /// </summary>
        private void OnSendBtnClick()
        {
            try
            {
                DatabaseService.CreateOrUpdateCardAsync(target as CardBaseSO, OnCreateOrUpdateCardComplete).WaitForResult(OnExceptionThrown);
            }
            catch (Exception e)
            {
                OnExceptionThrown(e);
            }
        }

        /// <summary>
        /// Appelée si la mise en ligne de la carte est un succès
        /// </summary>
        private void OnCreateOrUpdateCardComplete()
        {
            UnityEngine.Debug.Log(Constants.CARD_UPLOADED_SUCCESS_MSG);
        }

        /// <summary>
        /// Appelée si une erreur se produit
        /// </summary>
        private void OnExceptionThrown(Exception exception)
        {
            UnityEngine.Debug.LogException(exception);
        }

        #endregion
    }
}