using UnityEngine;
using System.Collections;


/// <summary>
/// ブロック単体のクラス
/// </summary>
public class Block : MonoBehaviour
{
    private bool is_select;
    public bool IsSelect
    {
        get { return is_select; }
        set { is_select = value; }
    }

    [SerializeField]
    public EventManager event_manager = null;

    [SerializeField]
    public SpriteRenderer spriterenderer;

    // 画像の判定をするための番号
    public int number;
    // Astarで使う一次元配列番号
    public int index;
    // イベントで使うカウント
    public int event_draw_count;
}
