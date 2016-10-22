using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject player = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y, -5);
    }
}
