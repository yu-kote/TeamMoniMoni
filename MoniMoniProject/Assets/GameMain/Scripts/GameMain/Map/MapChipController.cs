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


    void Awake()
    {
        blocks = new List<List<List<GameObject>>>();

        // FIXME: スプライトまとめて読む感じに失敗・・・修正予定
        //SpriteLoader loader = new SpriteLoader();
        //loader.Load("Textures/samplechip");

        loadMap("test");
        //using (StreamReader sr = new StreamReader("Assets/Resources/"))
        //{

        //}


        //for (int i = 0; i < (int)LayerController.Layer.LAYER_MAX; i++)
        //{
        //    List<List<GameObject>> tempblock_xy = new List<List<GameObject>>();

        //    string layername = LayerController.layernumToString(i);
        //    Sprite[] sprites = Resources.LoadAll<Sprite>("Textures/" + layername);

        //    for (int y = 0; y < chip_num_y; y++)
        //    {
        //        List<GameObject> tempblock_x = new List<GameObject>();
        //        for (int x = 0; x < chip_num_x; x++)
        //        {
        //            GameObject block;
        //            block = Resources.Load<GameObject>("Prefabs/BlockBase");

        //            {
        //                block.GetComponent<SpriteRenderer>().sprite =
        //                    System.Array.Find<Sprite>(
        //                        sprites, (sprite) => sprite.name.Equals(
        //                            layername + "_" + map_array[y, x].ToString()));


        //            }

        //            block.transform.position = new Vector3(chipsize * x, chipsize * y * -1, -i * 0.2f);
        //            block.transform.localScale = new Vector3(chipsize, chipsize, 0);

        //            tempblock_x.Add((GameObject)Instantiate(block, gameObject.transform));

        //            // あたり判定付け方
        //            //blocks[y, x].GetComponent<BoxCollider2D>().isTrigger = false;
        //        }
        //        tempblock_xy.Add(tempblock_x);
        //    }
        //    blocks.Add(tempblock_xy);
        //}

        // MEMO: string.IndexOf("") --- 含まれている場合0以上含まれていない場合-1
        //                        大文字小文字の区別はつく

    }

    void Start()
    {
        playerPop();

        // StartCoroutine
        StartCoroutine(playerSelectBlock());
        StartCoroutine(blockUpdate());
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
                    if (blocks[3][y][x].GetComponent<Block>().number != -1)
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

    /// <summary>
    /// ブロックのイベントのアップデートコルーチン
    /// </summary>
    private IEnumerator blockUpdate()
    {
        while (true)
        {
            if (player.GetComponent<PlayerController>().IsSelect)
            {
                blockEventUpdate();
            }

            var block = blocks[(int)LayerController.Layer.EVENT]
                [player_cell_y]
                [player_cell_x]
                .GetComponent<Block>();

            if (block.number != -1)
            {
                if (overLapEventExists())
                    if (block.event_manager.trigger_type == 1)
                    {
                        block.event_manager.eventExecution();
                        player.GetComponent<PlayerController>().IsEventDuring = true;
                    }
            }


            yield return null;
        }
    }
    private void blockEventUpdate()
    {
        var block = blocks[eventlayer][select_cell_y][select_cell_x].GetComponent<Block>();
        block.event_manager.eventExecution();
    }

    /// <summary>
    /// イベントの有無を返す関数
    /// </summary>
    public bool eventExists()
    {
        var eventmanager = blocks[eventlayer][select_cell_y][select_cell_x].
                GetComponent<Block>().event_manager;
        if (eventmanager.eventExists(eventmanager.event_stage) == false)
            return false;
        return true;
    }

    /// <summary>
    /// 通過系イベントの有無を返す関数
    /// </summary>
    /// <returns></returns>
    public bool overLapEventExists()
    {
        var eventmanager = blocks[eventlayer][player_cell_y][player_cell_x].
        GetComponent<Block>().event_manager;
        if (eventmanager.eventExists(eventmanager.event_stage) == false)
            return false;
        return true;
    }

    /// <summary>
    /// イベントが終了したかどうかを返す関数
    /// </summary>
    /// <returns>イベントが終了したかどうか</returns>
    public bool isEventCompleted()
    {
        if (player.GetComponent<PlayerController>().IsSelect)
        {
            var is_completed = blocks[eventlayer][select_cell_y][select_cell_x].
                GetComponent<Block>().
                event_manager.IsEventCompleted;
            if (is_completed)
            {
                blocks[eventlayer][select_cell_y][select_cell_x].
                GetComponent<Block>().
                event_manager.IsEventCompleted = false;
                return true;
            }
        }
        if (player.GetComponent<PlayerController>().IsEventDuring)
        {
            var is_completed = blocks[eventlayer][player_cell_y][player_cell_x].
              GetComponent<Block>().
              event_manager.IsEventCompleted;
            if (is_completed)
            {
                blocks[eventlayer][player_cell_y][player_cell_x].
                GetComponent<Block>().
                event_manager.IsEventCompleted = false;
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
            Sprite[] loadsprite = Resources.LoadAll<Sprite>("Textures/" + layername);
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
    }

    public void mapClear()
    {
        for (int i = 0; i < (int)LayerController.Layer.LAYER_MAX; i++)
        {
            for (int y = 0; y < chip_num_y; y++)
            {
                for (int x = 0; x < chip_num_x; x++)
                {
                    Destroy(blocks[i][y][x]);
                }
            }
        }
        blocks.Clear();
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


