using UnityEngine;
using System.Collections;

public class fall : MonoBehaviour {
    [SerializeField]
    private float fall_time;
    [SerializeField]
    private float fall_speed;
    Vector3 pos;
    // Use this for initialization
    void Start()
    {

        pos = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(pos.x,pos.y + fall_time,pos.z);
        if (fall_time > 0)
        {
            fall_time -= fall_speed;
        }
        if (fall_time < 0) fall_time = 0;

    }
}
