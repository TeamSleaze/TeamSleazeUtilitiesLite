using UnityEditor;
using UnityEngine;

namespace TeamSleaze.UtilitiesLite
{
    [InitializeOnLoad]
    public class StyleHierarchy
    {
        private static string[] m_dataArray;
        private static string m_path;
        private static ColorPalette m_colorPalette;

        static StyleHierarchy()
        {
            m_dataArray = AssetDatabase.FindAssets("t:ColorPalette");

            if (m_dataArray.Length >= 1)
                m_path = AssetDatabase.GUIDToAssetPath(m_dataArray[0]);
            m_colorPalette = AssetDatabase.LoadAssetAtPath<ColorPalette>(m_path);
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindow;
        }

        private static void OnHierarchyWindow(int instanceID, Rect selectionRect)
        {
            if (m_dataArray.Length == 0) return;

            Object instance = EditorUtility.InstanceIDToObject(instanceID);

            if (instance != null)
            {
                for (int i = 0; i < m_colorPalette.ColorDesigns.Count; i++)
                {
                    var design = m_colorPalette.ColorDesigns[i];

                    if (instance.name.StartsWith(design.KeyChar))
                    {
                        string newName = instance.name.Substring(design.KeyChar.Length);
                        EditorGUI.DrawRect(selectionRect, design.BackgroundColor);

                        GUIStyle newStyle = new GUIStyle
                        {
                            alignment = design.TextAlignment,
                            fontStyle = design.FontStyle,
                            normal = new GUIStyleState()
                            {
                                textColor = design.TextColor,
                            }
                        };

                        if (design.UpperCase) EditorGUI.LabelField(selectionRect, newName.ToUpper(), newStyle);
                        else EditorGUI.LabelField(selectionRect, newName, newStyle);
                    }
                }
            }
        }
    }
}