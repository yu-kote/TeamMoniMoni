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
    [SerializeField]
    private Collider2D _collider2D = null;

    [SerializeField]
    private CounterView _counterView = null;

    public int Count { get; private set; }

    public Action Touched { get; set; }

    private float _invalidInterval = 0;

    public void SetInvalidInterval(float interval) { _invalidInterval = interval; }

    // Use this for initialization
    void Start()
    {
        Count = 0;
        _counterView.Count = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (_invalidInterval > 0)
        {
            Debug.Log("Interval: " + _invalidInterval);
            _invalidInterval -= Time.deltaTime;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(tapPoint);

            if (collider == _collider2D)
            {
                if (Touched != null) { Touched(); }

                Debug.Log("Pass");
                Count++;
                _counterView.Count--;
                //Debug.Log(cout);
            }
        }
    }
}