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

    List<EventRepository.EventFunc> eventsfunc = new List<EventRepository.EventFunc>();

    /// <summary>
    /// イベントの追加
    /// </summary>
    /// <param name="add_event">イベントの関数</param>
    public void addEvent(EventRepository.EventFunc add_event)
    {
        eventsfunc.Add(add_event);
    }

    /// <summary>
    /// イベント実行関数
    /// </summary>
    public void eventExecution()
    {
        eventsfunc[(int)event_stage]();
    }

    /// <summary>
    /// イベントが実行可能かどうかを返す関数
    /// </summary>
    /// <returns>イベントが実行可能か</returns>
    public bool eventExists(EventStage now_stage = EventStage.STAGE_MAX)
    {
        EventRepository.EventFunc func = eventsfunc[(int)now_stage];
        if (func == null)
            return false;
        return true;
    }
}
