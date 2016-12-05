using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Image_alpha : MonoBehaviour {
    [SerializeField]
    float a ;//徐々に0に近づける
    private Image image;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();//Imageコンポネントを取得
    }
    
    // Update is called once per frame
    void Update () {
        
        var color = image.color;//取得したimageのcolorを取得
        color.a = a;
        image.color = color;
    }
}
