using UnityEngine;
using System.Collections;


public class TitleResize : MonoBehaviour
{
    public float hei;
    public float wid;


    public Vector3 Resized()
    {
        //スクリーンのサイズの比率を求める 
        float mmm = (float)Screen.width / (float)Screen.height;
        //比率に合わせて横幅を調整（ベース画像の比率が16:10） 
        hei = 1f;
        wid = mmm / 1.6f;



        //スケールを求める 
        Vector3 scale = new Vector3(wid, hei, 1.0f);
        return scale;
    }


    public Vector3 Reposition(float bx, float by)
    {
        //スクリーンのサイズの比率を求める 
        float mmm = (float)Screen.width / (float)Screen.height;
        //比率に合わせて横幅を調整（ベース画像の比率が16:10） 
        hei = 1f;
        wid = mmm / 1.6f;
        //スケールを求める 
        Vector3 pos = new Vector3(wid * bx, hei * by, 0.0f);
        return pos;
    }
}
