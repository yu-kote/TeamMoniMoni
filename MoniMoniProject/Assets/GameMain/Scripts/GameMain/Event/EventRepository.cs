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

    public delegate int EventFunc();
    Dictionary<int, EventFunc> eventdic = new Dictionary<int, EventFunc>();
    Dictionary<int, EventTriggerType> event_trigger_type = new Dictionary<int, EventTriggerType>();

    public enum EventTriggerType
    {
        CHECK,
        OVERLAP,
    }

    void Awake()
    {
        eventAdd(0, eventscreate.playerUpEvent, EventTriggerType.CHECK);
        eventAdd(1, eventscreate.playerZombieHand, EventTriggerType.OVERLAP);
    }

    /// <summary>
    /// イベント登録関数
    /// </summary>
    /// <param name="key_">イベントの番号</param>
    /// <param name="func_">イベントの関数</param>
    /// <param name="trigger_type_">トリガーの種類( 調べる系(0), 通過系(1) )</param>
    void eventAdd(int key_, EventFunc func_, EventTriggerType trigger_type_)
    {
        eventdic.Add(key_, func_);
        event_trigger_type.Add(key_, trigger_type_);
    }

    /// <summary>
    /// イベント取得関数
    /// </summary>
    /// <param name="tag_">イベントのタグ</param>
    /// <returns>イベント関数</returns>
    public EventFunc getEvent(int tag_)
    {
        EventFunc func = eventdic[tag_];
        if (func == null)
        {
            Debug.Assert(false, "Not Event Find!!");
        }
        return eventdic[tag_];
    }

    /// <summary>
    /// イベントのトリガー取得関数
    /// </summary>
    /// <param name="key_">トリガーの種類</param>
    /// <returns></returns>
    public EventTriggerType getEventTriggerType(int key_)
    {
        return event_trigger_type[key_];
    }
}
