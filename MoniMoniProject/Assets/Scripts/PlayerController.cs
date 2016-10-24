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

        Vector2 vec_ = new Vector2(vec.x * 0.01f, vec.y * 0.01f);
        transform.Translate(vec_);
    }
}
