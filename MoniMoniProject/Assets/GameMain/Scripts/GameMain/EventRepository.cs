using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// イベントにtagをつけて管理するクラス
/// </summary>
public class EventRepository : MonoBehaviour
{
    [SerializeField]
    EventsCreate eventscreate;

    public delegate void EventFunc();
    Dictionary<string, EventFunc> eventdic = new Dictionary<string, EventFunc>();

    void Awake()
    {
        eventdic.Add("player_up", new EventFunc(eventscreate.playerUpEvent));
    }

    /// <summary>
    /// イベント取得関数
    /// </summary>
    /// <param name="tag_">イベントのタグ</param>
    /// <returns>イベント関数</returns>
    public EventFunc getEvent(string tag_)
    {
        EventFunc func = eventdic[tag_];
        if (func == null)
        {
            Debug.Assert(false, "Not Event Find!!!!!!!!!!!!!!!!!!");
        }
        return eventdic[tag_];
    }
}
