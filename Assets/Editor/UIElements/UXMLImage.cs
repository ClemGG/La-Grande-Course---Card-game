using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Editor.UIElements
{
    /// <summary>
    /// Elément UXML représentant une image
    /// </summary>
    [UxmlElement]
    public partial class UXMLImage : Image
    {
        #region Properties

        /// <summary>
        /// L'image
        /// </summary>
        [UxmlAttribute]
        public new Texture image
        {
            get => base.image;
            set => base.image = value;
        }

        /// <summary>
        /// Le sprite à afficher
        /// </summary>
        [UxmlAttribute]
        public new Sprite sprite
        {
            get => base.sprite;
            set => base.sprite = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur
        /// </summary>
        public UXMLImage() : base()
        {

        }

        #endregion
    }
}