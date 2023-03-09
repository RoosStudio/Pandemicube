 using UnityEngine;
 using UnityEditor;
 
 [CustomEditor(typeof(BoundRecalculate))]
 public class BoundRecalculatorMenu : Editor
 {
     public override void OnInspectorGUI()
     {
         DrawDefaultInspector();
 
         BoundRecalculate script = (BoundRecalculate)target;
 
         if(GUILayout.Button("Recalculate Bounds")) {
             script.calculate();
         }
     }
 }
