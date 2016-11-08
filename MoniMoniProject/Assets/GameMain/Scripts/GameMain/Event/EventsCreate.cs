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

    [SerializeField]
    MapChipController chipcontroller;



    int upcount = 0;
    // イベントが正常に動くかどうかのお試し関数
    public int playerUpEvent()
    {
        player.transform.Translate(0, chipcontroller.chip_size, 0);
        upcount++;
        if (upcount < 3)
            return 1;
        return 2;
    }

    public int emptyEvent()
    {
        return 1;
    }


    public int playerZombieHand()
    {

        return 1;
    }



}
