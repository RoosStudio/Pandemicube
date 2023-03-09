using UnityEngine;

public class TextureJoiner: MonoBehaviour
{
    // this function should be called in runtime to generate a custom texture from layers to a material texture

    public static Texture generateTexture(MaterialModel[] layer) {
        if(layer != null && layer.Length > 0) {
        Texture2D finalResult = new Texture2D(layer[0].texture.width, layer[0].texture.height, TextureFormat.ARGB32, true);
        for( int x = 0; x < layer[0].texture.width; x++ ) {
            for( int y = 0; y < layer[0].texture.height; y++ ) {
                for( int l = layer.Length-1; l >= 0; l-- ) {
                    if(layer[l].texture.GetPixel(x,y).a > 0.1) {
                        if(layer[l].cutMap != null) {
                            Color textPixel = layer[l].texture.GetPixel(x,y)*layer[l].color;
                            textPixel.a = layer[l].cutMap.GetPixel(x, y).a;
                            finalResult.SetPixel(x, y, textPixel);
                        } else {
                            finalResult.SetPixel(x, y, layer[l].texture.GetPixel(x,y)*layer[l].color);
                        }
                        break;
                    }
                }
            }
        }
        
        finalResult.Apply();
        finalResult.filterMode = FilterMode.Point;
        return finalResult;
    } else {
        return null;
    }
    }



    // This function is used by texture interpolation menu

    [SerializeField] MaterialModel[] layer;
    [SerializeField] Material output;

    public void test() {
        Texture2D finalResult = new Texture2D(layer[0].texture.width, layer[0].texture.height, TextureFormat.ARGB32, true);
        for( int x = 0; x < layer[0].texture.width; x++ ) {
            for( int y = 0; y < layer[0].texture.height; y++ ) {
                for( int l = layer.Length-1; l >= 0; l-- ) {
                    if(layer[l].texture.GetPixel(x,y).a > 0.1) {
                        if(layer[l].cutMap != null) {
                            Color textPixel = layer[l].texture.GetPixel(x,y);
                            textPixel.a = layer[l].cutMap.GetPixel(x, y).a;
                            layer[l].texture.SetPixel(x, y, textPixel);
                        }
                        finalResult.SetPixel(x, y, layer[l].texture.GetPixel(x,y)*layer[l].color);
                        break;
                    }
                }
            }
        }
        
        finalResult.Apply();
        finalResult.filterMode = FilterMode.Point;
        output.SetTexture("_BaseMap", finalResult);
    }
}
