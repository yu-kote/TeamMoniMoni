using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
    void Touch()
    {
        print(GetInstanceID());
    }


    public static bool IsTouchObject(GameObject aObject)
    {
        int srcId = aObject.gameObject.GetInstanceID();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.touches[i];
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
                foreach (Collider2D collider in colliders)
                {
                    int dstId = collider.gameObject.GetInstanceID();
                    if (srcId == dstId)
                    {
                        Debug.Log("touch object name : " + aObject.gameObject.name);
                        return true;
                    }
                }
            }
        }
        return false;
    }

}
