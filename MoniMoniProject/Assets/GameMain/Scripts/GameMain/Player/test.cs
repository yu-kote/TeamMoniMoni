using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(1, 0);
    }
}
