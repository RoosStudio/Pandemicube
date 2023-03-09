using UnityEngine;
 
 public class BoundRecalculate : MonoBehaviour
 {
     [SerializeField]
     GameObject target;
 
     public void calculate() {
         foreach( Transform c$$anonymous$$ld in target.transform ) {
             if(c$$anonymous$$ld.GetComponent<SkinnedMeshRenderer>() != null) {
                 SkinnedMeshRenderer skinnedMeshRenderer = c$$anonymous$$ld.GetComponent<SkinnedMeshRenderer>();
                     skinnedMeshRenderer.rootBone = skinnedMeshRenderer.bones[skinnedMeshRenderer.sharedMesh.boneWeights[0].boneIndex0];
                     skinnedMeshRenderer.updateWhenOffscreen = true;
                     Bounds bounds = new Bounds();
                     Vector3 center = skinnedMeshRenderer.localBounds.center;
                     Vector3 extents = skinnedMeshRenderer.localBounds.extents;
                     bounds.center = center;
                     bounds.extents = extents;
                     skinnedMeshRenderer.updateWhenOffscreen = false;
                     skinnedMeshRenderer.localBounds = bounds;
             }
         }
     }
 }
