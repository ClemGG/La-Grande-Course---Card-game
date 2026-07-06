using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Cards;
using Assets.Scripts.Database;
using Assets.Scripts.Scenes;
using Assets.Scripts.User.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.User
{
    /// <summary>
    /// Interface de la partie enreigstrement/connexion du joueur
    /// </summary>
    [RequireComponent(typeof(UserLoginViewModel))]
    public class UserLoginView : MonoBehaviour
    {
        #region Variables Unity

        /// <summary>
        /// Canvas d'enregistrement
        /// </summary>
        [SerializeField]
        private Canvas _registerCanvas;

        /// <summary>
        /// Canvas de connexion
        /// </summary>
        [SerializeField]
        private Canvas _loginCanvas;

        /// <summary>
        /// Canvas d'attente
        /// </summary>
        [SerializeField]
        private Canvas _progressCanvas;

        /// <summary>
        /// Label du message d'erreur
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _registerErrorMsg;

        /// <summary>
        /// Champ du nom d'utilisateur
        /// </summary>
        [SerializeField]
        private TMP_InputField _registerUsernameField;

        /// <summary>
        /// Champ du mdp
        /// </summary>
        [SerializeField]
        private TMP_InputField _registerPasswordField;

        /// <summary>
        /// Label du message d'erreur
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _loginErrorMsg;

        /// <summary>
        /// Champ du nom d'utilisateur
        /// </summary>
        [SerializeField]
        private TMP_InputField _loginUsernameField;

        /// <summary>
        /// Champ du mdp
        /// </summary>
        [SerializeField]
        private TMP_InputField _loginPasswordField;

        /// <summary>
        /// Champ du admin
        /// </summary>
        [SerializeField]
        private Toggle _adminField;

        /// <summary>
        /// Scène du menu ppal
        /// </summary>
        [SerializeField]
        private SceneReference _mainMenuScene;

        #endregion

        #region Variables d'instance

        /// <summary>
        /// Le UserLoginViewModel
        /// </summary>
        private UserLoginViewModel _vm;

        #endregion

        #region Méthodes Unity

        /// <summary>
        /// init
        /// </summary>
        private void Awake()
        {
            _vm = GetComponent<UserLoginViewModel>();
        }

        /// <summary>
        /// init
        /// </summary>
        private void Start()
        {
            bool loginCacheExists = _vm.TryGetCredentialsInCache(out string username, out string passwordHash);
            _registerErrorMsg.gameObject.SetActive(false);
            _loginErrorMsg.gameObject.SetActive(false);
            _progressCanvas.enabled = false;
            _registerCanvas.enabled = !loginCacheExists;
            _loginCanvas.enabled = loginCacheExists;

            // Si l'utilisateur a déjà inscrit ses identifiants auparavant, on les récupère dans le cache

            if (loginCacheExists)
            {
                _loginUsernameField.SetTextWithoutNotify(username);
                _loginPasswordField.SetTextWithoutNotify(PasswordEncryption.Decrypt(passwordHash, username));
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
                _registerErrorMsg.gameObject.SetActive(false);
                string username = _registerUsernameField.text;
                string password = _registerPasswordField.text;
                bool admin = _adminField.isOn;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    throw new Exception(Constants.EMPTY_INPUT_ERR);

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
                print("Logging in...");
                _progressCanvas.enabled = true;
                _registerErrorMsg.gameObject.SetActive(false);
                string username = _loginUsernameField.text;
                string password = _loginPasswordField.text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    throw new Exception(Constants.EMPTY_INPUT_ERR);

                _vm.Login(username, password, OnLoginSuccess, OnExceptionThrown);
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
            string username = _registerUsernameField.text;
            string password = _registerPasswordField.text;
            bool admin = _adminField.isOn;

            if (!_vm.TryGetPreferencesInCache(out UserPreferences preferences))
            {
                preferences = new UserPreferences(0);
            }

            _vm.SetCredentialsCache(username, PasswordEncryption.Encrypt(password, username));
            _vm.SetPreferencesCache(preferences);
            _vm.SetSessionUserData(username, password, admin, true, new UserDecklists(), preferences);

            SceneManager.LoadSceneAsync(_mainMenuScene);

            print("Registering successful");
        }

        /// <summary>
        /// Apelée si la connexion est un succès
        /// </summary>
        /// <param name="loginInfo">Infos de connexion</param>
        private void OnLoginSuccess(string loginInfo)
        {
            string username = _loginUsernameField.text;
            string password = _loginPasswordField.text;
            string[] loginInfos = loginInfo.Split('\n');
            bool admin = int.Parse(loginInfos[1]) == 1;
            string decklistJson = loginInfos[2];

            UserDecklists userDecklists = JsonUtility.FromJson<UserDecklists>(decklistJson);

            if (!_vm.TryGetPreferencesInCache(out UserPreferences preferences))
            {
                preferences = new UserPreferences(0);
            }

            _vm.SetCredentialsCache(username, PasswordEncryption.Encrypt(password, username));
            _vm.SetPreferencesCache(preferences);
            _vm.SetSessionUserData(username, password, admin, false, userDecklists, preferences);

            SceneManager.LoadSceneAsync(_mainMenuScene);

            print("Logging successful");
        }

        /// <summary>
        /// Appelée si une erreur se produit pendant une opération
        /// </summary>
        private void OnExceptionThrown(Exception e)
        {
            _progressCanvas.enabled = false;
            _registerErrorMsg.gameObject.SetActive(true);
            _loginErrorMsg.gameObject.SetActive(true);
            _registerErrorMsg.SetText(e.Message);
            _loginErrorMsg.SetText(e.Message);
            Debug.LogException(e);
        }

        #endregion
    }
}