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

    float player_z = -0.5f;

    int zombiecount = 0;
    Vector2 player_start_pos;

    bool is_setup = false;
    public int playerZombieHand()
    {
        if (is_setup == false)
        {
            player_start_pos = player.transform.position;
            is_setup = true;
        }
        zombiecount++;
        player.transform.position = player_start_pos;
        Vector3 randompos = Random.insideUnitCircle * 0.1f;
        player.transform.Translate(randompos + new Vector3(0, 0, player_z));

        if (zombiecount / 60.0f <= 2) return 0;
        is_setup = false;
        zombiecount = 0;
        player.transform.Translate(0, 1, 0);

        return 1;
    }



}
