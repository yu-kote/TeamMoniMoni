using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapchip : MonoBehaviour
{
    public float chipsize = 0;

    public int[,] map_array = new int[15, 15] {
         { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 3, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 6, 7, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 9, 10, 11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },

         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    };

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

    void Awake()
    {

    }

    //List<GameObject> blocks = new List<GameObject>();
    GameObject[,] blocks;

    // Use this for initialization
    void Start()
    {
        // ここはそのうちtxtからデータを読むようにするところ

        int chip_num_x = 15;
        int chip_num_y = 15;

        blocks = new GameObject[chip_num_y, chip_num_x];

        chipsize = 1.0f;

        // prefabからscriptでインスタンスをつくる
        int chip_y = 0;
        for (int y = 0; y < chip_num_y; y++)
        {
            int chip_x = 0;
            for (int x = 0; x < chip_num_x; x++)
            {
                GameObject block;
                block = (GameObject)Resources.Load("Prefabs/samplechip_" + map_array[y, x].ToString());

                blocks[y, x] = block;
                blocks[y, x].transform.position = new Vector3(chipsize * chip_x, chipsize * chip_y, 0);
                blocks[y, x].transform.rotation = Quaternion.identity;

                // Instantiateを使うと生成したものをもう一回呼ぶとうまく動かない？
                // もう一回入れなおしたらうまくいった。

                blocks[y, x] = Instantiate(blocks[y, x]);
                chip_x += 1;
            }
            chip_y -= 1;
        }

        // string.IndexOf("") --- 含まれている場合0以上含まれていない場合-1
        //                        大文字小文字の区別はつく


        int search_y = 0;
        foreach (var y in event_array)
        {
            int search_x = 0;
            foreach (var x in y)
            {
                if (x.ToString() == "1")
                {
                    var v = blocks[search_y, search_x].transform.position;
                    // プレイヤーがpopする位置
                }
                search_x += 1;
            }
            search_y += 1;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
