using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemy_move : MonoBehaviour {
    [SerializeField]
    private GameObject walker;
    walk_eat walker_move;
    [SerializeField]
    private GameObject enemy_HP_text;
    Text HP_text;
    [SerializeField]
    private GameObject enemy_HP_text_slot;
    Text HP_text_slot;
    public int time;
    public int warp_time;
    private int touch_count;
    public bool enemy_eat;
    private Vector3 enemy_pos;
    private Vector3 enemy_end_pos;
    private Vector3 animation_eat_end_pos = new Vector3(2.5f, -0.16f, -6);
    private float size;
    float speed;
    float speed_regulation;
    
    [SerializeField]
    private Collider2D _collider2D = null;
    // Use this for initialization
    void Start () {
        walker_move = walker.GetComponent<walk_eat>();
        HP_text = enemy_HP_text.GetComponent<Text>();
        HP_text_slot = enemy_HP_text_slot.GetComponent<Text>();
        size = 1.0f;
        time = 0;
        warp_time = 0;
        touch_count = 0;
        enemy_eat = false;
        enemy_pos = Vector3.zero;
        enemy_end_pos = Vector3.zero;
        speed = 0;
        speed_regulation = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(size, size, 1);

        time++;
        switch (touch_count) {
            case 0:
                transform.localPosition = enemy_pos;
                HP_text.text = "3";
                if (time < 150) {
                    speed_regulation = 3;
                }
                if (time >= 150)
                {
                    if (speed_regulation >= 1.0f) {
                     speed_regulation -= 0.01f;
                    }
                   
                }
                speed += 0.05f*speed_regulation;
                enemy_pos = new Vector3(Mathf.Sin(-speed)*2.0f, Mathf.Cos(-speed)*1.5f, 0);
                break;
            case 1:
                transform.localPosition = enemy_pos;
                HP_text.text = "2";
                if (time < 150)
                {
                    speed_regulation = 5;
                }
                if (time >= 150)
                {
                    if (speed_regulation >= 1.0f)
                    {
                        speed_regulation -= 0.01f;
                    }
                }
                speed += 0.03f * speed_regulation;
                enemy_pos = new Vector3(Mathf.Sin(-speed/4) * 2, Mathf.Cos(-speed) * 1.8f, 0);
                break;
            case 2:
                transform.localPosition = enemy_pos;
                HP_text.text = "1";
                if (time < 200)
                {
                    warp_time += 6;
                }
                if (time >= 200)
                {
                    warp_time += 1;
                }
                speed += 0.03f * speed_regulation;
                if (warp_time == 60)
                {
                    enemy_pos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.2f, 2.2f), 0);
                    warp_time = 0;
                }
                break;
            case 3:
                HP_text.text = " ";
                HP_text_slot.text = " ";
                if (time < 100) {
                    transform.localPosition = enemy_end_pos - enemy_end_pos / 100 * time;
                }
                if (time == 100) { touch_count = 4; time = 0; walker_move.starter(); }
                break;
            case 4:
                if (time <= 200)
                {
                    transform.localPosition = new Vector3(
                        0 + animation_eat_end_pos.x / 200 * time,
                        0 + animation_eat_end_pos.y / 200 * time,
                        -6);
                    size -= 1.0f / 200;
                }
                if (time == 201) Destroy(gameObject);
                break;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(tapPoint);

            if (collider == _collider2D)
            {
                if (time > 200&&touch_count<=2) {
                    if (touch_count == 2)
                    {
                        enemy_end_pos = transform.localPosition;
                        enemy_eat = true;
                       
                    }
                    touch_count++;
                    time = 0;
                }
                //Debug.Log(cout);
            }
        }

    }

}
