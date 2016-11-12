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
    SpriteRenderer spriterenderer;

    public int number;

    // カメラに写っていないときの処理
    public void OnBecameInvisible()
    {
        Color color = spriterenderer.color;
        color.a = 0;
        spriterenderer.color = color;
    }
    // カメラに写っているときの処理
    public void OnBecameVisible()
    {
        Color color = spriterenderer.color;
        color.a = 255.0f;
        spriterenderer.color = color;
    }
}
