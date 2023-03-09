#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextureJoiner))]
public class TextureInterpolationMenu : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TextureJoiner script = (TextureJoiner)target;

        if(GUILayout.Button("Generate new Texture")) {
            script.test();
        }
    }
}
#endif
