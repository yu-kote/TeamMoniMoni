using UnityEngine;
using System.Collections;
using System;

public class RayTest : MonoBehaviour
{
    public float floatHeight;
    public float liftFroce;
    public float damping;
    public Rigidbody2D rd2D;
    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if(hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = floatHeight - distance;
            float force = liftFroce * heightError - rd2D.velocity.y * damping;
            rd2D.AddForce(Vector3.up * force);
        }
    }
}

public class touch : MonoBehaviour
{


    public int cout;
    public int Maxcount;
    public Action action;

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

            if (collider != null)
            {

                if(action != null) { action();}

                cout++;
                Maxcount--;
                //Debug.Log(cout);
            }
        }
    }
}