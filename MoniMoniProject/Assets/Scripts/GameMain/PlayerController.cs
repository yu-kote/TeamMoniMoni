using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        UP, DOWN, RIGHT, LEFT
    }

    public PlayerState player_state = PlayerState.DOWN;

    public Vector2 vec;
    private float speed = 1f;

    // Use this for initialization
    void Start()
    {
        player_state = PlayerState.DOWN;
        transform.position = new Vector3(0, 0, -1.0f);
        vec = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        vec = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            player_state = PlayerState.UP;
            vec.y += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player_state = PlayerState.DOWN;
            vec.y -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player_state = PlayerState.LEFT;
            vec.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player_state = PlayerState.RIGHT;
            vec.x += speed;
        }

        Vector3 vec_ = new Vector3(vec.x * 0.05f, vec.y * 0.05f, 0);
        transform.Translate(vec_);
    }
}
