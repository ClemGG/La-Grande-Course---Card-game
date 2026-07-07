using System;
using Assets.Scripts.Scenes;
using Assets.Scripts.User;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    /// <summary>
    /// Vue de l'écran d'accueil après la connexion du joueur
    /// </summary>
    [RequireComponent(typeof(MainMenuViewModel))]
    public class MainMenuView : MonoBehaviour
    {
        #region Variables Unity

        /// <summary>
        /// Label du nom du joueur
        /// </summary>
        [SerializeField, Tooltip("Label du nom du joueur")]
        private TextMeshProUGUI _usernameLabel;

        /// <summary>
        /// Label du message d'erreur
        /// </summary>
        [SerializeField, Tooltip("Label du message d'erreur")]
        private TextMeshProUGUI _logoutErrorMsgLabel;

        /// <summary>
        /// Canvas de progression
        /// </summary>
        [SerializeField, Tooltip("Canvas de progression")]
        private Canvas _progressCanvas;

        /// <summary>
        /// Canvas du popup de confirmation de déconnexion
        /// </summary>
        [SerializeField, Tooltip("Canvas du popup de confirmation de déconnexion")]
        private Canvas _loginPopupConfirmationCanvas;

        /// <summary>
        /// Canvas du popup de confirmation de fermeture
        /// </summary>
        [SerializeField, Tooltip("Canvas du popup de confirmation de fermeture")]
        private Canvas _quitPopupConfirmationCanvas;

        /// <summary>
        /// Scene de connexion
        /// </summary>
        [SerializeField, Tooltip("Scene de connexion")]
        private SceneReference _loginScene;

        #endregion

        #region Variables d'instance

        /// <summary>
        /// Le MainMenuViewModel
        /// </summary>
        private MainMenuViewModel _vm;

        #endregion

        #region Méthodes Unity

        /// <summary>
        /// Init
        /// </summary>
        private void Awake()
        {
            _vm = GetComponent<MainMenuViewModel>();
            Application.wantsToQuit += OnWantsToQuit;
        }

        /// <summary>
        /// Init
        /// </summary>
        private void Start()
        {
            _usernameLabel.SetText(Session.UserName);
            _progressCanvas.enabled = false;
            _loginPopupConfirmationCanvas.enabled = false;
            _logoutErrorMsgLabel.enabled = false;
        }

        /// <summary>
        /// Nettoyage
        /// </summary>
        private void OnDestroy()
        {
            Application.wantsToQuit -= OnWantsToQuit;
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Déonnecte l'utilisateur
        /// </summary>
        /// <param name="quit">true si la déconnexion doit se faire après une tentative de quitter le jeu</param>
        public void Logout(bool quit)
        {
            try
            {
                print("Logging out...");

                _loginPopupConfirmationCanvas.enabled = false;
                _quitPopupConfirmationCanvas.enabled = false;
                _progressCanvas.enabled = true;
                _logoutErrorMsgLabel.gameObject.SetActive(false);

                string decklistsJson = JsonUtility.ToJson(Session.Decks, true);
                _vm.Logout(Session.UserName, decklistsJson, quit ? OnCancelQuitLogoutSuccess : OnNormalLogoutSuccess, OnExceptionThrown);
            }
            catch (Exception e)
            {
                OnExceptionThrown(e);
            }
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Appelée une fois la déconnexion réussie
        /// </summary>
        public void OnNormalLogoutSuccess()
        {
            SceneManager.LoadSceneAsync(_loginScene);

            print("Logout successful. Returning to the login screen...");
        }

        /// <summary>
        /// Appelée une fois la déconnexion réussie
        /// </summary>
        public void OnCancelQuitLogoutSuccess()
        {
            Application.wantsToQuit -= OnWantsToQuit;
            Application.Quit();
            print("Logout successful. Quitting the game...");
        }

        /// <summary>
        /// Appelée si une erreur se produit pendant une opération
        /// </summary>
        private void OnExceptionThrown(Exception e)
        {
            _progressCanvas.enabled = false;
            _logoutErrorMsgLabel.gameObject.SetActive(true);
            _logoutErrorMsgLabel.SetText(e.Message);
            Debug.LogException(e);
        }

        /// <summary>
        /// Appelée quand le joueur demande à quitter le jeu
        /// </summary>
        private bool OnWantsToQuit()
        {
            _quitPopupConfirmationCanvas.enabled = true;
            return false;
        }

#endregion
    }
}