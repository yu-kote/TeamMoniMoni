using UnityEngine;
using System.Collections;


public class TitleSizeTo : MonoBehaviour
{


    void Start()
    {
        //Resizeを取得 
        GameObject Resize = GameObject.Find("/Resize");
        //スケールの変更 
        //Risizeから変更スケールを取得 
        Vector3 scale = Resize.GetComponent<TitleResize>().Resized();
        //スケールを変更 
        transform.localScale = scale;

        //ポジションの変更 
        //現在のポジションを取得 
        float tx = transform.localPosition.x;
        float ty = transform.localPosition.y;
        float tz = transform.localPosition.z;
        //Risizeから変更ポジションを取得 
        Vector3 pos = Resize.GetComponent<TitleResize>().Reposition(tx, ty);
        //ポジション変更 
        transform.position = new Vector3(pos.x, pos.y, tz);
    }
}

