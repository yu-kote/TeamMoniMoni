using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject player = null;

    public float camera_follow_speed;
    public float camera_follow_z;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camerapos = transform.position;
        Vector3 playerpos = player.transform.position;

        camerapos.x += (playerpos.x - camerapos.x) * camera_follow_speed;
        camerapos.y += (playerpos.y - camerapos.y) * camera_follow_speed;
        camerapos.z = camera_follow_z * -1;

        transform.position = camerapos;

        Debug.Log(Time.deltaTime);
    }


}
