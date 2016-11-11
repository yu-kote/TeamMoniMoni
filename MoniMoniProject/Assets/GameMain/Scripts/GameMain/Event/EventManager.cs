using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ブロック一個一個に対するイベントを管理するクラス
/// </summary>
public class EventManager : MonoBehaviour
{
    /// <summary>
    /// イベントの段階
    /// </summary>
    public enum EventStage
    {
        ONE_STAGE,
        TWO_STAGE,
        THREE_STAGE,
        STAGE_MAX
    }
    // イベントの段階を保持
    public EventStage event_stage = EventStage.ONE_STAGE;

    // イベントの個数を保持
    public int event_count = 0;

    List<EventRepository.EventFunc> eventsfunc = new List<EventRepository.EventFunc>();


    /// <summary>
    /// トリガーが調べる系(0)か通過する系(1)か
    /// </summary>
    public EventRepository.EventTriggerType trigger_type;

    void Start()
    {
        event_count = eventsfunc.Count;
    }

    /// <summary>
    /// イベントが終了したかどうか
    /// </summary>
    private bool is_event_completed = false;
    public bool IsEventCompleted
    {
        get { return is_event_completed; }
        set { is_event_completed = value; }
    }

    /// <summary>
    /// イベントの追加
    /// </summary>
    /// <param name="add_event">イベントの関数</param>
    public void addEvent(
        List<EventRepository.EventFunc> add_event,
        EventRepository.EventTriggerType trigger_type_)
    {
        eventsfunc = add_event;
        trigger_type = trigger_type_;
    }

    /// <summary>
    /// イベント実行関数
    /// </summary>
    /// <returns>イベントが起こったかどうか</returns>
    public bool eventExecution()
    {
        if (!eventExists(event_stage)) return false; // nullcheck

        // イベントの返り値はEventCreate.csを参照
        int event_status = eventsfunc[(int)event_stage]();

        // イベント続行
        if (event_status == 0) return true;

        // イベント終了
        is_event_completed = true;

        // イベントの段階をすすめる
        if (event_status == 2)
            event_stage++;
        return false;
    }

    /// <summary>
    /// イベントが実行可能かどうかを返す関数
    /// </summary>
    /// <returns>イベントが実行可能か</returns>
    public bool eventExists(EventStage now_stage = EventStage.STAGE_MAX)
    {
        if (event_count <= (int)now_stage)
            return false;
        return true;
    }
}
