using UnityEngine;
using System.Collections;

public class moved : MonoBehaviour
{

    public float angle = 30f;
    private Vector3 targetPos;
    private Vector3 target;
    private Vector3 pos;

    float t;

    public GameObject prefad;

    private float speed;

    touch touches;

    // Use this for initialization
    void Start()
    {
        //Destroy(gameObject, 5.0f);

        touches = GetComponent<touch>();

        //Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        //Instantiate(prefad, position, Quaternion.identity);
        //if (Random.RandomRange(10,10,10))
        //{
        //    float x = Random.Range(-2.0f, 2.0f);
        //    float y = Random.Range(-2.0f, 2.0f);
        //    float z = Random.Range(-2.0f, 2.0f);

        //}

        speed = 3.0f;

        pos = Vector3.zero;

    }

    private float v;

    public void circle()
    {
        v += Time.deltaTime * speed;
        Debug.Log(transform.position);

        pos.y = Mathf.Sin(v) * 2f;
        pos.x = Mathf.Cos(v) * 2f;

        float translation = Time.deltaTime * 30;
        transform.Translate(0, translation, 0);

        t += Time.deltaTime;
        if (t > 5)
        {
            Debug.Log("aaaaa");
            speed = 1.0f;
            t = 0;
        }

        target = pos;
        gameObject.transform.position = pos;
    }

    public void Zigzag()
    {
        v += Time.deltaTime * speed;
        Debug.Log(transform.position);

        pos.y = Mathf.Sin(v) * 1f;
        pos.x = Mathf.Cos(v) * 6f;

        float translation = Time.deltaTime * 30;
        transform.Translate(0, translation, 0);

        target = pos;
        gameObject.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = gameObject;
        if (touches.cout == 0)
        {
            circle();
        }
        else if(touches.cout == 1)
        {
            Zigzag();
        }
        else if(touches.cout == 2)
        {
            Destroy(obj);
        }


        //Vector3 axis = Vector3.forward;
        //transform.RotateAround(targetPos, axis, angle * Time.deltaTime);

    }
}
