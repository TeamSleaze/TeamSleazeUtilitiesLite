using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true), CanEditMultipleObjects]
public class DefaultMonoBehaviourEditor : Editor
{
    private bool m_hideScriptField;

    private void OnEnable()
    {
        m_hideScriptField = target.GetType().GetCustomAttributes(typeof(HideScriptField), false).Length > 0;
    }

    public override void OnInspectorGUI()
    {
        if (m_hideScriptField)
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            DrawPropertiesExcluding(serializedObject, "m_Script");
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
        else
        {
            base.OnInspectorGUI();
        }
    }
}