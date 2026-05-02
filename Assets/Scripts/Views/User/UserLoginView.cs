using System;
using Assets.Scripts.ViewModels.User;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views.User
{
    /// <summary>
    /// Interface de la partie enreigstrement/connexion du joueur
    /// </summary>
    public class UserLoginView : MonoBehaviour
    {
        #region Variables Unity

        /// <summary>
        /// Label du message d'erreur
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _errorMsg;

        /// <summary>
        /// Champ du nom d'utilisateur
        /// </summary>
        [SerializeField]
        private TMP_InputField _usernameField;

        /// <summary>
        /// Champ du mdp
        /// </summary>
        [SerializeField]
        private TMP_InputField _passwordField;

        /// <summary>
        /// Champ du admin
        /// </summary>
        [SerializeField]
        private Toggle _adminField;

        /// <summary>
        /// Canvas d'attente
        /// </summary>
        [SerializeField]
        private Canvas _progressCanvas;

        #endregion

        #region Variables d'instance

        /// <summary>
        /// Le UserLoginViewModel
        /// </summary>
        private UserLoginViewModel _vm;

        /// <summary>
        /// Nom d'utilisateur
        /// </summary>
        private string _login;

        /// <summary>
        /// Mot de passe
        /// </summary>
        private string _password;

        /// <summary>
        /// Mot de passe
        /// </summary>
        private bool _isAdmin;

        #endregion

        #region Méthodes Unity

        /// <summary>
        /// init
        /// </summary>
        private void Awake()
        {
            _vm = GetComponent<UserLoginViewModel>();
            _errorMsg.gameObject.SetActive(false);
            _progressCanvas.enabled = false;
        }

        /// <summary>
        /// init
        /// </summary>
        private void Start()
        {
            // Si l'utilisateur a déjà inscrit ses identifiants auparavant, on les récupère dans le cache

            if (_vm.TryGetCredentials(out string username, out string password, out bool admin))
            {
                _usernameField.SetTextWithoutNotify(username);
                _passwordField.SetTextWithoutNotify(password);
                _adminField.SetIsOnWithoutNotify(admin);
            }
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Enregistre l'utilisateur
        /// </summary>
        public void Register()
        {
            try
            {
                print("Registering...");
                _progressCanvas.enabled = true;
                _errorMsg.gameObject.SetActive(false);
                string username = _usernameField.text;
                string password = _passwordField.text;
                bool admin = _adminField.isOn;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new Exception(Constants.EMPTY_INPUT_ERR);
                }

                _vm.Register(username, password, admin, OnRegisterSuccess, OnExceptionThrown);
            }
            catch (Exception e)
            {
                OnExceptionThrown(e);
            }
        }

        /// <summary>
        /// Connecte l'utilisateur
        /// </summary>
        public void Login()
        {
            try
            {
                print("Logging...");
                _progressCanvas.enabled = true;
                _errorMsg.gameObject.SetActive(false);
                string username = _usernameField.text;
                string password = _passwordField.text;
                bool admin = _adminField.isOn;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new Exception(Constants.EMPTY_INPUT_ERR);
                }

                _vm.Login(username, password, admin, OnLoginSuccess, OnExceptionThrown);
            }
            catch (Exception e)
            {
                OnExceptionThrown(e);
            }
        }

        #endregion

        #region Méthodes privées

        /// <summary> 
        /// Apelée si l'enregistrement est un succès
        /// </summary>
        private void OnRegisterSuccess()
        {
            string username = _usernameField.text;
            string password = _passwordField.text;
            bool admin = _adminField.isOn;
            _vm.SetCredentialsCache(username, password, admin);

            _progressCanvas.enabled = false;
            print("Registering successful");
        }

        /// <summary>
        /// Apelée si la connexion est un succès
        /// </summary>
        private void OnLoginSuccess()
        {
            string username = _usernameField.text;
            string password = _passwordField.text;
            bool admin = _adminField.isOn;
            _vm.SetCredentialsCache(username, password, admin);

            _progressCanvas.enabled = false;
            print("Logging successful");
        }

        /// <summary>
        /// Appelée si une erreur se produit pendant une opération
        /// </summary>
        private void OnExceptionThrown(Exception e)
        {
            _progressCanvas.enabled = false;
            _errorMsg.gameObject.SetActive(true);
            _errorMsg.SetText(e.Message);
            Debug.LogException(e);
        }

        #endregion
    }
}