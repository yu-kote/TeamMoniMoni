using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// プレイヤーの操作を持つクラス
/// </summary>
public class PlayerController : MonoBehaviour
{
    public enum PlayerDirection
    {
        UP, DOWN, RIGHT, LEFT
    }

    public PlayerDirection player_direction = PlayerDirection.DOWN;

    public Vector2 vec;

    private float speed;

    /// <summary>
    /// 何かしら選択しているかどうか
    /// </summary>
    private bool is_select;
    public bool IsSelect
    {
        get { return is_select; }
        set { is_select = value; }
    }

    void Start()
    {
        player_direction = PlayerDirection.DOWN;
        transform.position = new Vector3(0, 0, -1.0f);
        speed = 1.0f;
        vec = new Vector2(0, 0);
        is_select = false;

        StartCoroutine(moveMethod());
        StartCoroutine(fieldCheck());
    }

    /// <summary>
    /// フィールドを選択しているかどうかのフラグを変更する関数
    /// </summary>
    /// <returns>null</returns>
    private IEnumerator fieldCheck()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                is_select = true;
                yield return null;
            }

            if (/*イベントが終了したかどうか*/true)
            {
                is_select = false;
            }
            yield return null;
        }
    }

    [SerializeField]
    MapChipController mapchip = null; // ブロックサイズを取得するため

    /// <summary>
    /// playerの位置からcell番号(x, y)を返す
    /// </summary>
    /// <returns>cell番号</returns>
    public Vector2 retCell()
    {
        var pos = transform.position;
        Vector2 cell_f = pos / mapchip.chipsize;

        Vector2 cell_i = new Vector2(Mathf.RoundToInt(cell_f.x), Mathf.RoundToInt(cell_f.y));
        cell_i.x = Mathf.Abs(cell_i.x);
        cell_i.y = Mathf.Abs(cell_i.y);

        return cell_i;
    }

    /// <summary>
    /// プレイヤー移動メソッド
    /// </summary>
    /// <returns>null</returns>
    private IEnumerator moveMethod()
    {
        while (true)
        {
            move();
            yield return null;
        }
    }

    /// <summary>
    /// プレイヤー移動関数
    /// </summary>
    private void move()
    {
        vec = Vector2.zero;
        if (is_select) return;
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
    }
}

