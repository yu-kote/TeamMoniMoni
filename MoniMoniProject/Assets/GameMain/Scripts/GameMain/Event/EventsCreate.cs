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
    PlayerController playercontroller;

    [SerializeField]
    GameObject mapcontroller;

    [SerializeField]
    MapChipController chipcontroller;

    [SerializeField]
    EventTalkManager talkmanager;

    [SerializeField]
    StagingController staging;

    [SerializeField]
    EnemyManager enemys;

    int upcount = 0;
    // イベントが正常に動くかどうかのお試し関数
    public int playerUpEvent()
    {
        player.transform.Translate(0, chipcontroller.chip_size, 0);
        upcount++;
        if (upcount < 1)
            return 1;
        return 2;
    }

    public int playerDirectionEvent()
    {
        if (playercontroller.player_direction == PlayerController.PlayerDirection.UP)
        {
            player.transform.Translate(0, 1.5f, 0);
        }
        if (playercontroller.player_direction == PlayerController.PlayerDirection.DOWN)
        {
            player.transform.Translate(0, -1.5f, 0);
        }
        upcount++;
        if (upcount < 1)
            return 1;
        return 1;
    }

    public int emptyEvent()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("none");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    float player_z = -0.5f;

    int zombiecount = 0;
    Vector2 player_start_pos;

    bool is_setup = false;
    public int playerZombieHand1()
    {
        if (is_setup == false)
        {
            player_start_pos = player.transform.position;

            is_setup = true;
        }
        zombiecount++;
        if (zombiecount / 60.0f <= 2)
        {
            player.transform.position = player_start_pos;
            Vector3 randompos = Random.insideUnitCircle * 0.05f;
            player.transform.Translate(randompos + new Vector3(0, 0, player_z));
            return 0;
        }
        else if (zombiecount == 60 * 2 + 1)
        {
            player.transform.Translate(0, 1, 0);
            talkmanager.startTalk("testevent");
            playercontroller.state = PlayerController.State.TALK;
        }

        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int playerZombieHand2()
    {
        if (is_setup)
        {
            talkmanager.startTalk("testevent");

            is_setup = false;
        }

        if (talkmanager.is_talknow)
            return 0;
        zombiecount = 0;
        return 1;
    }

    public int schoolEvent05()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_05");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent08()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_08");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent14()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_14");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent00()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_00");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    bool is_enemypop = false;
    public int schoolBossEvent()
    {
        if (is_enemypop == false)
        {
            if (staging.flushStart())
            {
                is_enemypop = true;
                enemys.nightmareRePop();
            }
            return 0;
        }
        else
        {
            if (staging.flushEnd())
            {
                if (is_setup == false)
                {
                    talkmanager.startTalk("school_00");
                    is_setup = true;
                }
                if (talkmanager.is_talknow)
                    return 0;
                is_setup = false;
                return 1;
            }
            return 0;
        }
    }
}
