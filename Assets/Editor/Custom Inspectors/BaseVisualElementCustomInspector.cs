using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Editor.CustomInspectors
{
    /// <summary>
    /// Inspecteur personnalisé permettant de renvoyer l'inspecteur par défaut
    /// sous forme d'UIElements
    /// </summary>
    [CustomEditor(typeof(Object), true, isFallback = true)]
    public class BaseVisualElementCustomInspector : UnityEditor.Editor
    {
        /// <summary>
        /// Remplace l'inspecteur existant
        /// </summary>
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement container = new();
            SerializedProperty iterator = serializedObject.GetIterator();

            if (iterator.NextVisible(true))
            {
                do
                {
                    PropertyField propertyField = new(iterator.Copy()) { name = "PropertyField:" + iterator.propertyPath };

                    if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
                    {
                        propertyField.SetEnabled(false);
                    }

                    container.Add(propertyField);
                }
                while (iterator.NextVisible(false));
            }

            return container;
        }
    }
}