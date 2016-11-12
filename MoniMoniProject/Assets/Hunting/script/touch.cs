using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour
{


    public int cout;
    public int Maxcount;

    // Use this for initialization
    void Start()
    {
        cout = 0;
        Maxcount = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(tapPoint);

            //GameObject obj = GameObject.Find("40f4e887-5b48-5fb7-ce5d-9fc444f38ff7");
            //if (TouchManager.IsTouchObject(obj))
            if (collider != null)
            {
                cout++;
                Maxcount--;
                Debug.Log(cout);
            }
        }
    }
}
