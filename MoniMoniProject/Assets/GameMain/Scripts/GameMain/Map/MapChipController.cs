using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


/// <summary>
/// マップチップを管理するクラス
/// </summary>
public class MapChipController : MonoBehaviour
{
    public float chip_size;
    public float chip_scale;

    public int chip_num_x;
    public int chip_num_y;

    const int eventlayer = (int)LayerController.Layer.EVENT;

    public string[][] event_array = new string[][]
    {
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },

        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", },

        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
        new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", },
    };



    public List<List<List<GameObject>>> blocks;
    [SerializeField]
    GameObject player = null;

    [SerializeField]
    PlayerController player_controller = null;

    public List<List<List<Block>>> blockcomponents;


    void Awake()
    {
        blocks = new List<List<List<GameObject>>>();

        // FIXME: スプライトまとめて読む感じに失敗・・・修正予定
        // SpriteLoader loader = new SpriteLoader();
        // loader.Load("Textures/samplechip");

        loadMap("test");

        // MEMO: string.IndexOf("") --- 含まれている場合0以上含まれていない場合-1
        //                        大文字小文字の区別はつく

    }

    void Start()
    {
        playerPop();

        // StartCoroutine
        //StartCoroutine(playerSelectBlock());
        StartCoroutine(blockUpdate());

        is_eventstart = false;
    }





    /// <summary>
    /// プレイヤーをpopさせる位置を決める関数
    /// </summary>
    private void playerPop()
    {
        int search_y = 0;
        foreach (var y in event_array)
        {
            int search_x = 0;
            foreach (var x in y)
            {
                if (x.ToString() == "1")
                {
                    // プレイヤーがpopする位置
                    var v = blocks[0][search_y][search_x].transform.position;
                    // playerが手前に描画されるようにするため
                    v.z += -0.5f;
                    player.transform.position = v;
                }
                search_x += 1;
            }
            search_y += 1;
        }
    }

    // プレイヤーが選んでいるブロック
    private int select_cell_x;
    private int select_cell_y;
    // プレイヤーのセル
    private int player_cell_x;
    private int player_cell_y;


    /// <summary>
    /// プレイヤーがブロックを選ぶコルーチン
    /// </summary>
    private IEnumerator playerSelectBlock()
    {
        while (true)
        {
            for (int y = 0; y < chip_num_y; y++)
            {
                for (int x = 0; x < chip_num_x; x++)
                {
                    blocks[0][y][x].GetComponent<SpriteRenderer>().material.color = Color.white;
                    if (blockcomponents[3][y][x].number != -1)
                        blocks[0][y][x].GetComponent<SpriteRenderer>().material.color = Color.red;
                }
            }
            player_cell_x = (int)player_controller.retCell().x;
            player_cell_y = (int)player_controller.retCell().y;
            select_cell_x = player_cell_x;
            select_cell_y = player_cell_y;
            switch (player_controller.player_direction)
            {
                case PlayerController.PlayerDirection.UP:
                    select_cell_y -= 1;
                    break;
                case PlayerController.PlayerDirection.DOWN:
                    select_cell_y += 1;
                    break;
                case PlayerController.PlayerDirection.RIGHT:
                    select_cell_x += 1;
                    break;
                case PlayerController.PlayerDirection.LEFT:
                    select_cell_x -= 1;
                    break;
                default:
                    break;
            }

            select_cell_x = Mathf.Clamp(select_cell_x, 0, chip_num_x - 1);
            select_cell_y = Mathf.Clamp(select_cell_y, 0, chip_num_y - 1);

            blocks[0][select_cell_y][select_cell_x]
         .GetComponent<SpriteRenderer>().material.color = Color.red;

            yield return null;
        }
    }

    // プレイヤーでイベントが起こった時に選んでいるブロック
    private int eventselect_cell_x;
    private int eventselect_cell_y;
    // プレイヤーでイベントが起こった時のセル
    private int eventplayer_cell_x;
    private int eventplayer_cell_y;

    bool is_eventstart;

    /// <summary>
    /// ブロックのイベントのアップデートコルーチン
    /// </summary>
    private IEnumerator blockUpdate()
    {
        while (true)
        {
            // イベントが起こる前に通る処理
            if (!is_eventstart)
            {
                if (player_controller.IsSelect)
                {
                    var eventblock = blockcomponents[eventlayer][select_cell_y][select_cell_x];
                    eventselect_cell_x = select_cell_x;
                    eventselect_cell_y = select_cell_y;
                    is_eventstart = eventblock.event_manager.eventExecution();
                }

                var block = blockcomponents[(int)LayerController.Layer.EVENT]
                    [player_cell_y]
                    [player_cell_x];

                if (block.number != -1)
                {
                    if (overLapEventExists(player_cell_x, player_cell_y))
                    {
                        eventplayer_cell_x = player_cell_x;
                        eventplayer_cell_y = player_cell_y;
                        is_eventstart = block.event_manager.eventExecution();
                    }
                }
            }

            // イベントが続行しているときに通る処理
            // イベントが原因でプレイヤーの位置がずれたとき用に処理を分ける必要があったため。
            if (is_eventstart)
            {
                if (player_controller.IsSelect)
                {
                    var eventblock = blockcomponents[eventlayer][eventselect_cell_y][eventselect_cell_x];
                    is_eventstart = eventblock.event_manager.eventExecution();
                }

                var block = blockcomponents[(int)LayerController.Layer.EVENT]
                    [eventplayer_cell_y]
                    [eventplayer_cell_x];

                if (block.number != -1)
                {
                    if (overLapEventExists(eventplayer_cell_x, eventplayer_cell_y))
                    {
                        is_eventstart = block.event_manager.eventExecution();
                        player_controller.IsEventDuring = true;
                    }
                }

                if (is_eventstart == false)
                {
                    player_controller.IsEventDuring = false;
                }
            }


            yield return null;
        }
    }

    /// <summary>
    /// 調べる系のイベントの有無を返す関数
    /// </summary>
    public bool checkEventExists()
    {
        var eventmanager = blockcomponents[eventlayer][select_cell_y][select_cell_x]
                .event_manager;
        if (eventmanager.eventExists(eventmanager.event_stage) == false)
            return false;
        if (eventmanager.trigger_type != EventRepository.EventTriggerType.CHECK)
            return false;
        return true;
    }

    /// <summary>
    /// 通過系のイベントの有無を返す関数
    /// </summary>
    /// <param name="cellx_"></param>
    /// <param name="celly_"></param>
    /// <returns></returns>
    public bool overLapEventExists(int cellx_, int celly_)
    {
        var eventmanager = blockcomponents[eventlayer][celly_][cellx_]
        .event_manager;
        if (eventmanager.eventExists(eventmanager.event_stage) == false)
            return false;
        if (eventmanager.trigger_type != EventRepository.EventTriggerType.OVERLAP)
            return false;
        return true;
    }

    /// <summary>
    /// イベントが終了したかどうかを返す関数
    /// </summary>
    /// <returns>イベントが終了したかどうか</returns>
    public bool isEventCompleted()
    {
        if (player_controller.IsSelect)
        {
            var is_completed = blockcomponents[eventlayer][select_cell_y][select_cell_x]
                .event_manager.IsEventCompleted;
            if (is_completed)
            {
                blockcomponents[eventlayer][select_cell_y][select_cell_x]
                .event_manager.IsEventCompleted = false;
                return true;
            }
        }
        if (player_controller.IsEventDuring)
        {
            var is_completed = blockcomponents[eventlayer][player_cell_y][player_cell_x]
              .event_manager.IsEventCompleted;
            if (is_completed)
            {
                blockcomponents[eventlayer][player_cell_y][player_cell_x]
                .event_manager.IsEventCompleted = false;
                return true;
            }
        }
        return false;
    }


    /// <summary>
    /// マップを読み込む関数
    /// </summary>
    /// <param name="loadname_"></param>
    public void loadMap(string loadname_)
    {
        using (StreamReader sr = new StreamReader("Assets/GameMain/Resources/StageData/" + loadname_ + "_StatusData.txt"))
        {
            string line = sr.ReadLine();
            chip_num_x = stringToInt(line, 0);
            chip_num_y = stringToInt(line, 1);
        }

        for (int i = 0; i < (int)LayerController.Layer.LAYER_MAX; i++)
        {
            string layername = LayerController.layernumToString(i);
            Sprite[] loadsprite = Resources.LoadAll<Sprite>("Textures/MapChip/" + layername);
            using (StreamReader sr = new StreamReader("Assets/GameMain/Resources/StageData/" + loadname_ + "_" + layername + "Data.txt"))
            {

                List<List<GameObject>> tempblock_xy = new List<List<GameObject>>();
                for (int y = 0; y < chip_num_y; y++)
                {
                    string line = sr.ReadLine();

                    List<GameObject> tempblock_x = new List<GameObject>();
                    for (int x = 0; x < chip_num_x; x++)
                    {
                        GameObject block;
                        block = Resources.Load<GameObject>("Prefabs/BlockBase");

                        int number = stringToInt(line, x);

                        var renderer = block.GetComponent<SpriteRenderer>();
                        if (number != -1 && i != (int)LayerController.Layer.EVENT)
                        {
                            renderer.sprite =
                                System.Array.Find<Sprite>(
                                    loadsprite, (sprite) => sprite.name.Equals(
                                        layername + "_" + number.ToString()));

                            var renderer_rect = renderer.sprite.rect;
                            var size = (int)(renderer_rect.width);

                            chip_size = chip_scale * size * 0.01f;
                        }
                        else
                        {
                            // 空白読み
                            renderer.sprite = null;
                        }

                        block.GetComponent<Block>().number = number;

                        block.transform.position = new Vector3(
                            chip_size * x,
                            chip_size * y * -1,
                            -i * 0.01f);

                        block.transform.localScale = new Vector2(chip_scale, chip_scale);

                        block.GetComponent<BoxCollider2D>().isTrigger = true;
                        if (i == (int)LayerController.Layer.WALL)
                        {
                            if (number != -1)
                            {
                                block.GetComponent<BoxCollider2D>().isTrigger = false;
                            }
                        }

                        tempblock_x.Add(Instantiate(block));
                        tempblock_x[x].transform.parent = gameObject.transform;
                    }
                    tempblock_xy.Add(tempblock_x);
                }
                blocks.Add(tempblock_xy);

            }
        }

        blockcomponents = new List<List<List<Block>>>();
        for (int i = 0; i < (int)LayerController.Layer.LAYER_MAX; i++)
        {
            List<List<Block>> component_block_temp_xy = new List<List<Block>>();
            for (int y = 0; y < chip_num_y; y++)
            {
                List<Block> commponent_block_temp_x = new List<Block>();
                for (int x = 0; x < chip_num_x; x++)
                {
                    commponent_block_temp_x.Add(blocks[i][y][x].GetComponent<Block>());
                }
                component_block_temp_xy.Add(commponent_block_temp_x);
            }
            blockcomponents.Add(component_block_temp_xy);
        }

    }

    /// <summary>
    /// マップをクリアする関数
    /// </summary>
    public void mapClear()
    {
        for (int i = 0; i < (int)LayerController.Layer.LAYER_MAX; i++)
        {
            for (int y = 0; y < chip_num_y; y++)
            {
                for (int x = 0; x < chip_num_x; x++)
                {
                    Destroy(blocks[i][y][x]);
                    Destroy(blockcomponents[i][y][x]);
                }
            }
        }
        blocks.Clear();
        blockcomponents.Clear();
    }


    /// <summary>
    /// 文字列を空白区切りでintに変換する関数
    /// </summary>
    /// <param name="value_"></param>
    /// <param name="num_"></param>
    /// <returns></returns>
    public int stringToInt(string value_, int num_)
    {
        int retvalue = 0;
        int value_count = 0;
        string temp_value = "";
        char[] c = value_.ToCharArray();
        bool is_blank = false;

        for (int i = 0; i < value_.Length; i++)
        {
            if (is_blank)
            {
                if (c[i] != ' ')
                {
                    is_blank = false;
                }
            }
            if (is_blank == false)
            {
                if (c[i] == ' ')
                {
                    is_blank = true;

                    if (value_count == num_)
                    {
                        retvalue = int.Parse(temp_value);
                        break;
                    }
                    temp_value = "";
                    value_count++;
                    continue;
                }
                temp_value += c[i];
            }

        }
        return retvalue;
    }
}


