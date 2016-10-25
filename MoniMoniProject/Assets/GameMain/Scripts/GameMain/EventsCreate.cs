using UnityEngine;
using System.Collections;

/// <summary>
/// イベントたちを作るクラス
/// </summary>
public class EventsCreate : MonoBehaviour
{
    /// <summary>
    /// イベントが終了したかどうか
    /// </summary>
    private bool is_event_completed = false;
    public bool IsEventCompleted
    {
        get { return is_event_completed; }
        set { is_event_completed = value; }
    }

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject mapcontroller;

    public void playerUpEvent()
    {

    }
}
