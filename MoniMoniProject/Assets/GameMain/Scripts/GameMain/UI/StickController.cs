using UnityEngine;
using System.Collections;

public class StickController : MonoBehaviour
{


    //public void buttonDown()
    //{
    //    mousepos = Input.mousePosition;
    //    is_stickoperating = true;
    //}

    //public void buttonUp()
    //{
    //    is_stickoperating = false;
    //}
    
    //// スティックの初期位置
    //Vector2 default_stickpos;
    //// スティックを動かせる範囲
    //public float stick_move_radius;
    //// タッチしたときの位置
    //Vector2 mousepos;
    //// タッチしているかどうか
    //private bool is_stickoperating;

    //public bool IsStickOperating
    //{
    //    get { return is_stickoperating; }
    //    set { is_stickoperating = value; }
    //}
    
    //// スティックを動かした量 (x,y)
    //private Vector2 move_value;
    //public Vector2 MoveValue
    //{
    //    get
    //    {
    //        return new Vector2(move_value.x / stick_move_radius,
    //      move_value.y / stick_move_radius);
    //    }
    //}
    
    //// 前のフレームでスティックを動かした量
    //Vector2 prev_stick_move_value;

    //void Start()
    //{
    //    is_stickoperating = false;
    //    default_stickpos = transform.position;
    //    move_value = Vector2.zero;
    //}
    
    //void Update()
    //{
    //    // スティックの操作
    //    if (is_stickoperating)
    //    {
    //        Vector2 currentmousepos = Input.mousePosition;
    //        // 移動した後の値
    //        var movepos = default_stickpos;
    //        // マウスの移動量
    //        move_value = currentmousepos - mousepos;

    //        // スティックが移動できる範囲を超えた場合に戻す処理
    //        if (!pointToCircle(mousepos, stick_move_radius, currentmousepos))
    //        {
    //            // マウスの角度
    //            float angle = Mathf.Atan2(move_value.x, move_value.y);
    //            // x = sin y = cos
    //            float x = Mathf.Sin(angle) * stick_move_radius;
    //            float y = Mathf.Cos(angle) * stick_move_radius;

    //            move_value = new Vector2(x, y);
    //            movepos += move_value;
    //        }
    //        else
    //        {
    //            movepos += move_value;
    //        }
    //        transform.position = movepos;
    //    }
    //    else
    //    {
    //        transform.position = default_stickpos;
    //        move_value = Vector2.zero;
    //    }
    //}
    
    //// 点と円の判定(当たってたらtrue)
    //bool pointToCircle(Vector2 circlepos, float radius, Vector2 pointpos)
    //{
    //    float x = (pointpos.x - circlepos.x) * (pointpos.x - circlepos.x);
    //    float y = (pointpos.y - circlepos.y) * (pointpos.y - circlepos.y);

    //    return x + y <= radius * radius;
    //}
    //// 円から出ている場合の差分を返す関数
    //float pointToCircleDifference(Vector2 circlepos, float radius, Vector2 pointpos)
    //{
    //    float x = (pointpos.x - circlepos.x) * (pointpos.x - circlepos.x);
    //    float y = (pointpos.y - circlepos.y) * (pointpos.y - circlepos.y);

    //    if (x + y >= radius * radius)
    //    {
    //        return x + y - radius * radius;
    //    }
    //    return 0.0f;
    //}
}
