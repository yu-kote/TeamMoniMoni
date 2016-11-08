using UnityEngine;
using System.Collections;

public class transfrom : MonoBehaviour
{

    public float angle = 30f;
    private Vector3 targetPos;
    private Vector3 target;
    private Vector3 pos;

    public GameObject prefad;

    // Use this for initialization
    void Start()
    {

        //Destroy(gameObject, 5.0f);



        //Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        //Instantiate(prefad, position, Quaternion.identity);
        //if (Random.RandomRange(10,10,10))
        //{
        //    float x = Random.Range(-2.0f, 2.0f);
        //    float y = Random.Range(-2.0f, 2.0f);
        //    float z = Random.Range(-2.0f, 2.0f);

        //}

    }

    // Update is called once per frame
    void Update()
    {

        float speed = 2.0f;

        Debug.Log(transform.position);
        pos = Vector3.zero;


        pos.y += Mathf.Sin(Time.time * speed) * 2f;
        pos.x += Mathf.Cos(Time.time * speed) * 2f;

        float translation = Time.deltaTime * 30;
        transform.Translate(0, translation, 0);


        target = pos;
        gameObject.transform.position = pos;


        //Vector3 axis = Vector3.forward;
        //transform.RotateAround(targetPos, axis, angle * Time.deltaTime);

    }
}
