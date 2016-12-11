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
    EnemyManager enemymanager;

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

    // 実装できてないイベントに入れる
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

    public int overrapEmptyEvent()
    {
        playercontroller.state = PlayerController.State.NORMAL;
        return 1;
    }

    float player_z = -0.5f;

    int zombiecount = 0;
    Vector2 player_start_pos;

    bool is_setup = false;

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



    public int schoolEvent01()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_01");
            is_setup = true;
        }
        playercontroller.state = PlayerController.State.TALK;
        if (talkmanager.is_talknow)
            return 0;
        playercontroller.state = PlayerController.State.NORMAL;
        is_setup = false;
        return 2;
    }

    public int schoolEvent02()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_02");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent03()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_03");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent04()
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
            talkmanager.startTalk("school_04");
            playercontroller.state = PlayerController.State.TALK;
        }

        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
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
        return 2;
    }

    public int schoolEvent05_3()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_05-3");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent06()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_06");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent07()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_07");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 2;
    }
    public int schoolEvent07_2()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_07-2");
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
        return 2;
    }
    public int schoolEvent08_2()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_08-2");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent09()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_09");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent10()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_10");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent12()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_12");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }
    public int schoolEvent13()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_13");
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
        return 2;
    }
    public int schoolEvent14_2()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_14-2");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 2;
    }
    public int schoolEvent14_3()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_14-3");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent15()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_15");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent17()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_17");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }

    public int schoolEvent19()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_19");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }
    public int schoolEvent21()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_21");
            is_setup = true;
        }
        if (talkmanager.is_talknow)
            return 0;
        is_setup = false;
        return 1;
    }
    public int schoolEvent22()
    {
        if (is_setup == false)
        {
            talkmanager.startTalk("school_22");
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
            }
            return 0;
        }
        else
        {
            if (staging.flushEnd())
            {
                if (is_setup == false)
                {
                    talkmanager.startTalk("school_23");
                    is_setup = true;
                }
                if (talkmanager.is_talknow)
                    return 0;
                enemymanager.nightmareRePop(talkmanager.selectbuttonnum);
                is_setup = false;
                staging.flushcount = 0;
                return 1;
            }
            return 0;
        }
    }
}
