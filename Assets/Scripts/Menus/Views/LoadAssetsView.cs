using Assets.Scripts.Database;
using Assets.Scripts.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    /// <summary>
    /// Charge les assets de la base de données
    /// </summary>
    [RequireComponent(typeof(LoadAssetsViewModel))]
    public class LoadAssetsView : MonoBehaviour
    {
        #region Variables Unity

        /// <summary>
        /// Scène du menu de connexion
        /// </summary>
        [SerializeField]
        private SceneReference _loginScene;

        #endregion

        #region Variables d'instance

        /// <summary>
        /// Contrôleur
        /// </summary>
        private LoadAssetsViewModel _vm;

        #endregion

        #region Méthodes Unity

        /// <summary>
        /// init
        /// </summary>
        private void Awake()
        {
            _vm = GetComponent<LoadAssetsViewModel>();
        }

        /// <summary>
        /// init
        /// </summary>
        void Start()
        {
            // Télécharge les assets (cartes, etc.) puis lance l'écran de connexion

            _vm.LoadAssets(OnLoadAssetsSuccess);
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Appelée une fois les assets chargées
        /// </summary>
        private void OnLoadAssetsSuccess()
        {
            SceneManager.LoadSceneAsync(_loginScene);

            print(GameAssets.RacerCards != null ? GameAssets.RacerCards.Length : "0");
            print(GameAssets.TrackCards != null ? GameAssets.TrackCards.Length : "0");
            print(GameAssets.SkillCards != null ? GameAssets.SkillCards.Length : "0");
            print(GameAssets.EquipmentCards != null ? GameAssets.EquipmentCards.Length : "0");
            print(GameAssets.RuseCards != null ? GameAssets.RuseCards.Length : "0");
        }

        #endregion
    }
}