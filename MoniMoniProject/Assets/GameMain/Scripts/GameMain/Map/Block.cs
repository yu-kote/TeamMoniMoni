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

    public int number;

    // カメラに写っていないときの処理
    public void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    // カメラに写っているときの処理
    public void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }
}
