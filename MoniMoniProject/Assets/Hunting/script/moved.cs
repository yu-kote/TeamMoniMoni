using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class moved : MonoBehaviour
{

    public float angle = 30f;
    public Vector3 target;
    private Vector3 pos;
    private string SceneName;

    float cir;
    float zig;

    public GameObject obj;


    private float speed;
    bool isWorp;

    touch touches;

    // Use this for initialization
    void Start()
    {
        touches = GetComponent<touch>();
        touches.action = () => { speed = 5; };

        speed = 5.0f;
          
        target = pos;
        pos = Vector3.zero;
        obj =  gameObject;
        SceneName = "GameMain";



    }

    private float v;


    //円軌道
    public void circle()
    {
        v += Time.deltaTime * speed;
        Debug.Log(transform.position);

        pos.y = Mathf.Sin(v) * 2f;
        pos.x = Mathf.Cos(v) * 2f;

        float translation = Time.deltaTime * 30;
        transform.Translate(0, translation, 0);

        cir += Time.deltaTime;
        if (cir> 3)
        {
            Debug.Log("aaaaa");
            speed = 1.0f;
            cir = 0;
        }

        gameObject.transform.position = pos;
    }

    //ジグザグ軌道
    public void Zigzag()
    {
        v += Time.deltaTime * speed;
        Debug.Log(transform.position);

        pos.y = Mathf.Sin(v) * 1f;
        pos.x = Mathf.Cos(v / 9) * 1f;

        float translation = Time.deltaTime * 60;
        transform.Translate(0, translation, 0);

        zig+= Time.deltaTime;
        if (zig > 3)
        {
            Debug.Log("aaaaa");
            speed = 1.0f;
            zig = 0;
        }

        gameObject.transform.position = pos;
    }

    //テレポート
    public IEnumerator random()
    {
        isWorp = true;
        yield return new WaitForSeconds(2.0f);

        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-2.5f, 2.5f);
        transform.position = new Vector3(x, y, transform.position.z);

        isWorp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touches.cout == 0)
        {
            circle();
        }
        else if (touches.cout == 1)
        {
            Zigzag();
        }
        else if (touches.cout == 2)
        {
            if (!isWorp)
            {
                StartCoroutine(random());
            }
        }
        else if (touches.cout == 3)
        {
            //Destroy(gameObject);
            if (SceneName == "GameMain")
            {
                touches.cout = 0;
                SceneManager.LoadScene("GameMain");
            }
        }
    }
}
