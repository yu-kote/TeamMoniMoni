using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// イベントにtagをつけて管理するクラス
/// </summary>
public class EventRepository : MonoBehaviour
{
    // トリガー
    public enum EventTriggerType
    {
        CHECK,
        OVERLAP,
        FRONT_WARD,
    }

    // アップデートのしかた
    public enum EventUpdateType
    {
        TEMPORARY,
        ALWAYS,
    }

    [SerializeField]
    EventsCreate events;

    public delegate int EventFunc();
    Dictionary<int, List<EventFunc>> eventdic = new Dictionary<int, List<EventFunc>>();
    Dictionary<int, EventTriggerType> event_trigger_type = new Dictionary<int, EventTriggerType>();
    Dictionary<int, EventUpdateType> event_update_type = new Dictionary<int, EventUpdateType>();



    void Awake()
    {

        //schoolEventSetup();
        if (SceneInfoManager.instance.select_stage_name == "Videl" ||
            SceneInfoManager.instance.select_stage_name == null)
        {
            houseEventSetup();
        }
        if (SceneInfoManager.instance.select_stage_name == "School")
        {
            schoolEventSetup();
        }
    }

    public void houseEventSetup()
    {
        eventAllClear();
        eventAdd(0, new List<EventFunc> { events.emptyEvent }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);

        eventAdd(1, new List<EventFunc> { events.houseEvent02 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

        eventAdd(2, new List<EventFunc> { events.houseEvent03 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(3, new List<EventFunc> { events.houseEvent04 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(4, new List<EventFunc> { events.houseEvent05 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(5, new List<EventFunc> { events.houseEvent06 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(6, new List<EventFunc> { events.houseEvent07 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(7, new List<EventFunc> { events.houseEvent08 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(8, new List<EventFunc> { events.houseEvent09 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(9, new List<EventFunc> { events.houseEvent10 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(10, new List<EventFunc> { events.houseEvent11 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(11, new List<EventFunc> { events.houseEvent12 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(12, new List<EventFunc> { events.houseEvent13 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(13, new List<EventFunc> { events.houseEvent14 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(14, new List<EventFunc> { events.houseEvent15 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(15, new List<EventFunc> { events.houseEvent16 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(16, new List<EventFunc> { events.houseEvent17 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(17, new List<EventFunc> { events.houseEvent18 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(18, new List<EventFunc> { events.houseEvent19 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(19, new List<EventFunc> { events.houseEvent20 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(20, new List<EventFunc> { events.houseEvent21 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

        eventAdd(21, new List<EventFunc> { events.houseEvent22 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(22, new List<EventFunc> { events.houseEvent23 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(23, new List<EventFunc> { events.houseEvent24 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(24, new List<EventFunc> { events.houseEvent25 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(25, new List<EventFunc> { events.houseEvent26 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(26, new List<EventFunc> { events.houseEvent27 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(27, new List<EventFunc> { events.houseEvent28 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(28, new List<EventFunc> { events.houseEvent29 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(29, new List<EventFunc> { events.houseEvent30 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(30, new List<EventFunc> { events.houseEvent31 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(31, new List<EventFunc> { events.houseEvent32 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(32, new List<EventFunc> { events.houseEvent33 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(33, new List<EventFunc> { events.houseEvent34 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(34, new List<EventFunc> { events.houseEvent35 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(35, new List<EventFunc> { events.houseEvent36 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(36, new List<EventFunc> { events.houseEvent37 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(37, new List<EventFunc> { events.houseEvent38 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(38, new List<EventFunc> { events.houseEvent39 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(39, new List<EventFunc> { events.houseEvent40 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(40, new List<EventFunc> { events.houseEvent41 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(41, new List<EventFunc> { events.houseEvent42 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(42, new List<EventFunc> { events.houseEvent43 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(43, new List<EventFunc> { events.houseEvent44 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(44, new List<EventFunc> { events.houseEvent45 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(45, new List<EventFunc> { events.houseEvent46 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(46, new List<EventFunc> { events.houseEvent47 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(47, new List<EventFunc> { events.houseEvent48 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(48, new List<EventFunc> { events.houseEvent49 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
    }

    public void houseEndEventSetup()
    {
        eventAllClear();
        eventAdd(0, new List<EventFunc> { events.emptyEvent }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);

        eventAdd(1, new List<EventFunc> { events.houseEvent02 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

        eventAdd(2, new List<EventFunc> { events.houseEvent03 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(3, new List<EventFunc> { events.houseEvent04 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(4, new List<EventFunc> { events.houseEvent05 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(5, new List<EventFunc> { events.houseEvent06 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(6, new List<EventFunc> { events.houseEvent07 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(7, new List<EventFunc> { events.houseEvent08 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(8, new List<EventFunc> { events.houseEvent09 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(9, new List<EventFunc> { events.houseEvent10 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(10, new List<EventFunc> { events.houseEvent11 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(11, new List<EventFunc> { events.houseEvent12 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(12, new List<EventFunc> { events.houseEvent13 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(13, new List<EventFunc> { events.houseEvent14 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(14, new List<EventFunc> { events.houseEvent15 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(15, new List<EventFunc> { events.houseEvent16 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(16, new List<EventFunc> { events.houseEvent17 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(17, new List<EventFunc> { events.houseEvent18 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(18, new List<EventFunc> { events.houseEvent19 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(19, new List<EventFunc> { events.houseEvent20 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(20, new List<EventFunc> { events.houseEvent21 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

        eventAdd(21, new List<EventFunc> { events.houseEvent22_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(22, new List<EventFunc> { events.houseEvent23 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(23, new List<EventFunc> { events.houseEvent24 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(24, new List<EventFunc> { events.houseEvent25_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(25, new List<EventFunc> { events.houseEvent26_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(26, new List<EventFunc> { events.houseEvent27_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(27, new List<EventFunc> { events.houseEvent28_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(28, new List<EventFunc> { events.houseEvent29_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(29, new List<EventFunc> { events.houseEvent30 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(30, new List<EventFunc> { events.houseEvent31_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(31, new List<EventFunc> { events.houseEvent32_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(32, new List<EventFunc> { events.houseEvent33_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(33, new List<EventFunc> { events.houseEvent34_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(34, new List<EventFunc> { events.houseEvent35_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(35, new List<EventFunc> { events.houseEvent36_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(36, new List<EventFunc> { events.houseEvent37_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(37, new List<EventFunc> { events.houseEvent38_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(38, new List<EventFunc> { events.houseEvent39_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(39, new List<EventFunc> { events.houseEvent40 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(40, new List<EventFunc> { events.houseEvent41_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(41, new List<EventFunc> { events.houseEvent42_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(42, new List<EventFunc> { events.houseEvent43_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(43, new List<EventFunc> { events.houseEvent44_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(44, new List<EventFunc> { events.houseEvent45_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(45, new List<EventFunc> { events.houseEvent46_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(46, new List<EventFunc> { events.houseEvent47_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(47, new List<EventFunc> { events.houseEvent48_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(48, new List<EventFunc> { events.houseEvent49_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
    }
    public void schoolEventSetup()
    {
        eventAllClear();
        eventAdd(0, new List<EventFunc> { events.schoolEvent01, events.schoolEvent01_2 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);

        eventAdd(1, new List<EventFunc> { events.schoolEvent02 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

        eventAdd(2, new List<EventFunc> { events.schoolEvent03 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(3, new List<EventFunc> { events.schoolEvent04 }, EventTriggerType.OVERLAP, EventUpdateType.TEMPORARY);
        eventAdd(4, new List<EventFunc> { events.schoolEvent05, events.schoolEvent05, events.schoolEvent05_3 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(5, new List<EventFunc> { events.schoolEvent06, events.schoolEvent06_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(6, new List<EventFunc> { events.schoolEvent07, events.schoolEvent07_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(7, new List<EventFunc> { events.schoolEvent08, events.schoolEvent08_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(8, new List<EventFunc> { events.schoolEvent09, events.schoolEvent09_2 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

        eventAdd(9, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

        eventAdd(10, new List<EventFunc> { events.schoolEvent11, events.schoolEvent11_2, events.schoolEvent11_3 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(11, new List<EventFunc> { events.schoolEvent12 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(12, new List<EventFunc> { events.schoolEvent13 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(13, new List<EventFunc> { events.schoolEvent14 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(14, new List<EventFunc> { events.schoolEvent15 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(15, new List<EventFunc> { events.schoolEvent16 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(16, new List<EventFunc> { events.schoolEvent17 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(17, new List<EventFunc> { events.schoolEvent18 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(18, new List<EventFunc> { events.schoolEvent19 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(19, new List<EventFunc> { events.schoolEvent20 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(20, new List<EventFunc> { events.schoolEvent21 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(21, new List<EventFunc> { events.schoolEvent22 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(22, new List<EventFunc> { events.schoolEvent23 }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(23, new List<EventFunc> { events.schoolEvent24 }, EventTriggerType.FRONT_WARD, EventUpdateType.ALWAYS);
        eventAdd(24, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(25, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(26, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(27, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(28, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(29, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(30, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(31, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(32, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(33, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);
        eventAdd(34, new List<EventFunc> { events.emptyEvent }, EventTriggerType.CHECK, EventUpdateType.TEMPORARY);

    }

    /// <summary>
    /// イベント登録関数
    /// </summary>
    /// <param name="key_">イベントの番号</param>
    /// <param name="func_">イベントの関数</param>
    /// <param name="trigger_type_">トリガーの種類( 調べる系(0), 通過系(1) )</param>
    void eventAdd(int key_, List<EventFunc> func_, EventTriggerType trigger_type_, EventUpdateType update_type)
    {
        eventdic.Add(key_, func_);
        event_trigger_type.Add(key_, trigger_type_);
        event_update_type.Add(key_, update_type);
    }

    /// <summary>
    /// イベント取得関数
    /// </summary>
    /// <param name="tag_">イベントのタグ</param>
    /// <returns>イベント関数</returns>
    public List<EventFunc> getEvent(int tag_)
    {
        List<EventFunc> func = eventdic[tag_];
        if (func.Count <= 0)
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

    /// <summary>
    /// イベントのアップデートのしかた取得関数
    /// </summary>
    /// <param name="key_">イベント番号</param>
    /// <returns></returns>
    public EventUpdateType getEventUpdateType(int key_)
    {
        return event_update_type[key_];
    }


    /// <summary>
    /// イベント全消去
    /// </summary>
    public void eventAllClear()
    {
        eventdic.Clear();
        event_trigger_type.Clear();
    }
}
