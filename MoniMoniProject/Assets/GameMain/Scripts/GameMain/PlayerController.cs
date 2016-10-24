using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public enum PlayerDirection
    {
        UP, DOWN, RIGHT, LEFT
    }

    public PlayerDirection player_direction = PlayerDirection.DOWN;

    public Vector2 vec;
    private float speed = 1f;

    // Use this for initialization
    void Start()
    {
        player_direction = PlayerDirection.DOWN;
        transform.position = new Vector3(0, 0, -1.0f);
        vec = new Vector2(0, 0);

        StartCoroutine(move());
        StartCoroutine(DeriveCellByPosition());
    }

    [SerializeField]
    Mapchip mapchip;

    /**
     * playerの位置からcell番号(x,y)を返す
     * @retval  cell番号
     */
    public Vector2 retCell()
    {
        var pos = transform.position;
        Vector2 cell_f = pos / mapchip.chipsize;

        Vector2 cell_i = new Vector2(Mathf.RoundToInt(cell_f.x), Mathf.RoundToInt(cell_f.y));
        cell_i.x = Mathf.Abs(cell_i.x);
        cell_i.y = Mathf.Abs(cell_i.y);

        return cell_i;
    }

    private IEnumerator DeriveCellByPosition()
    {
        while (true)
        {
            //Debug.Log(retCell());
            yield return null;
        }
    }

    private IEnumerator move()
    {
        while (true)
        {
            vec = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                player_direction = PlayerDirection.UP;
                vec.y += speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                player_direction = PlayerDirection.DOWN;
                vec.y -= speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                player_direction = PlayerDirection.LEFT;
                vec.x -= speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                player_direction = PlayerDirection.RIGHT;
                vec.x += speed;
            }

            Vector3 vec_ = new Vector3(vec.x * 0.05f, vec.y * 0.05f, 0);
            transform.Translate(vec_);
            yield return null;
        }
    }


}
