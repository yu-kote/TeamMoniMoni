using UnityEngine;
using System.Collections;

/// <summary>
/// イベントたちを作るクラス
/// イベントの作り方
/// 各関数ごとにintの返り値がある
/// return 0    イベント続行中
///        1    イベントを終了させるかつ、呼び出されるたびに同じイベントを繰り返す
///        2    イベントを終了させるかつ、イベントの段階を進める
/// </summary>
public class EventsCreate : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject mapcontroller;


    // イベントが正常に動くかどうかのお試し関数
    public int playerUpEvent()
    {
        player.transform.Translate(0, 1.0f, 0);
        Debug.Log("EventExecution!!!!!!!!!!!!!!!!!!!!!!");
        return 2;
    }

    public int emptyEvent()
    {
        return 1;
    }
}
