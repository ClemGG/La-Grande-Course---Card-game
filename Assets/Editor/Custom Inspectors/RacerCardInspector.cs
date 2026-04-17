using Assets.Scripts.Models.Cards;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Editor.CustomInspectors
{
    /// <summary>
    /// Inspecteur personnalisé pour les cartes Coureurs
    /// </summary>
    [CustomEditor(typeof(RacerCardSO))]
    sealed class RacerCardInspector : CardInspector<RacerCardSO>
    {
        #region Variables d'instance

        /// <summary>
        /// Asset contenant l'UI de l'inspecteur
        /// </summary>
        [SerializeField]
        private VisualTreeAsset _customInspector;

        /// <summary>
        /// La racine de l'inspecteur
        /// </summary>
        [SerializeField]
        private VisualElement _root;

        /// <summary>
        /// Le component affichant l'illustration
        /// </summary>
        [SerializeField]
        private Image _cardPreviewImg;

        /// <summary>
        /// La propriété contenant l'illustration à afficher
        /// </summary>
        private SerializedProperty _illustrationProperty;

        #endregion

        #region Méthodes Unity

        /// <summary>
        /// Appelée à l'ouverture de l'inspecteur
        /// </summary>
        protected sealed override void OnEnable()
        {
            base.OnEnable();
            _illustrationProperty = serializedObject.FindProperty("<Illustration>k__BackingField");
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Remplace l'inspecteur existant
        /// </summary>
        public override sealed VisualElement CreateInspectorGUI()
        {
            VisualElement root = new();

            // Create a two-pane view with the left pane being fixed.

            TwoPaneSplitView splitView = new(0, 250, TwoPaneSplitViewOrientation.Vertical);

            // Add the view to the visual tree by adding it as a child to the root element.

            root.Add(splitView);

            // A TwoPaneSplitView needs exactly two child elements.

            VisualElement upPane = new();
            splitView.Add(upPane);
            VisualElement downPane = new();
            splitView.Add(downPane);

            InspectorElement.FillDefaultInspector(upPane, serializedObject, this);

            // Load the UXML file and clone its tree into the inspector.

            if (_customInspector != null)
            {
                VisualElement uxmlContent = _customInspector.CloneTree();
                _cardPreviewImg = uxmlContent.Q<Image>("CardPreview");
                _cardPreviewImg.TrackPropertyValue(_illustrationProperty, UpdateIllustration);
                downPane.Add(uxmlContent);

                UpdateIllustration();
            }

            return root;
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// màj l'illustration de la carte
        /// </summary>
        private void UpdateIllustration(SerializedProperty _ = null)
        {
            Sprite illustration = (Sprite)_illustrationProperty.objectReferenceValue;
            _cardPreviewImg.sprite = illustration != null ? illustration : _defaultSprite;
        }

        #endregion
    }
}