using UnityEngine;
using System.Collections;

public class TitleWord : MonoBehaviour {
    [SerializeField]
    private int wait_time;
    Vector2 pos;
    // Use this for initialization
	void Start () {
    pos = transform.localPosition;
    
	}
	
	// Update is called once per frame
	void Update () {
        if (wait_time > 0)
        {
            wait_time--;
            transform.localPosition = new Vector3(pos.x, pos.y + 150, 0);
        }
        else
        {
            transform.localPosition = new Vector3(pos.x, pos.y, 0);
        }

    }
}
