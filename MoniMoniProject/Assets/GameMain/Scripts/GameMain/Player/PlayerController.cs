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

    //[SerializeField]
    //StickController stick;

    [SerializeField]
    MoveButtonController movebutton;

    public PlayerDirection player_direction = PlayerDirection.DOWN;

    public Vector2 vec;

    [SerializeField]
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

    private bool is_event_during;
    public bool IsEventDuring
    {
        get { return is_event_during; }
        set { is_event_during = value; }
    }
    
    // イベントキーが押されたかどうか
    bool is_pusheventkey;
    public void pushEventKey()
    {
        is_pusheventkey = true;
    }

    void Start()
    {
        player_direction = PlayerDirection.DOWN;
        transform.position = new Vector3(0, 0, -1.0f);

        vec = new Vector2(0, 0);
        is_select = false;
        is_event_during = false;
        is_pusheventkey = false;

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
            // イベントキーが押されたとき
            if (is_pusheventkey)
                // 選択しているブロックにイベントがあるかどうか
                if (mapchip.checkEventExists())
                {
                    is_select = true;
                    is_event_during = true;
                }

            if (Input.GetKeyDown(KeyCode.Return))
                // 選択しているブロックにイベントがあるかどうか
                if (mapchip.checkEventExists())
                {
                    is_select = true;
                    is_event_during = true;
                }

            if (mapchip.isEventCompleted())
            {
                is_select = false;
                is_event_during = false;
            }

            is_pusheventkey = false;
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
        Vector2 cell_f = pos / mapchip.chip_size;

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
            directionChange();
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
        if (is_event_during) return;

        float deltaspeed = speed;

        // スティックの優先度
        //int priority_vec = 0; // x : 0 , y : 1
        //if (Mathf.Abs(stick.MoveValue.x) > Mathf.Abs(stick.MoveValue.y))
        //    priority_vec = 0;
        //else
        //    priority_vec = 1;
        //if (priority_vec == 0)
        //{
        //    vec.x = deltaspeed * stick.MoveValue.x;
        //}
        //else if (priority_vec == 1)
        //{
        //    vec.y = deltaspeed * stick.MoveValue.y;
        //}

        vec = deltaspeed * movebutton.getButtonPushVec();

        if (vec.x < 0.11f && vec.x > -0.11f)
            vec.x = 0;
        if (vec.y < 0.11f && vec.y > -0.11f)
            vec.y = 0;
        Vector3 vec_ = new Vector3(vec.x * 0.05f, vec.y * 0.05f, 0);
        transform.Translate(vec_);
    }

    /// <summary>
    /// プレイヤーのアニメーションの向きを変える関数
    /// </summary>
    void directionChange()
    {
        if (vec.y > 0.0f)
        {
            player_direction = PlayerDirection.UP;
        }
        if (vec.y < 0.0f)
        {
            player_direction = PlayerDirection.DOWN;
        }
        if (vec.x > 0.0f)
        {
            player_direction = PlayerDirection.RIGHT;
        }
        if (vec.x < 0.0f)
        {
            player_direction = PlayerDirection.LEFT;
        }
    }

}

