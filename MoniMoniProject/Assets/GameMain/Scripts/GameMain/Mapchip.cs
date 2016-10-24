﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Mapchip : MonoBehaviour
{
    public float chipsize = 0;
    const int chip_num_x = 15;
    const int chip_num_y = 15;

    public int[,] map_array = new int[chip_num_x, chip_num_y] {
         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 3, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 7, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 9, 8, 4, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },

         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },

         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
         { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1 },
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


    GameObject[,] blocks;
    [SerializeField]
    GameObject player = null;

    [SerializeField]
    PlayerController player_controller = null;


    void Start()
    {
        // ここはそのうちtxtからデータを読むようにするところ

        blocks = new GameObject[chip_num_y, chip_num_x];

        chipsize = 1.0f;

        //SpriteLoader loader = new SpriteLoader();
        //loader.Load("Textures/samplechip");

        Sprite[] sprites = Resources.LoadAll<Sprite>("Textures/samplechip");

        int chip_y = 0;
        for (int y = 0; y < chip_num_y; y++)
        {
            int chip_x = 0;
            for (int x = 0; x < chip_num_x; x++)
            {
                GameObject block;
                block = Resources.Load<GameObject>("Prefabs/BlockBase");
                // スプライトまとめて読む感じに失敗・・・修正予定
                //Sprite tempsprite = loader.GetSprite("samplechip_" + map_array[y, x].ToString());
                block.GetComponent<SpriteRenderer>().sprite = //tempsprite;
                    System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals("samplechip_" + map_array[y, x].ToString()));

                block.transform.position = new Vector3(chipsize * chip_x, chipsize * chip_y, 0);
                block.transform.localScale = new Vector3(chipsize, chipsize, 0);
                block.transform.rotation = Quaternion.identity;

                blocks[y, x] = Instantiate(block);

                if (map_array[y, x] == 1)
                {
                    blocks[y, x].GetComponent<BoxCollider2D>().isTrigger = false;
                }

                chip_x += 1;
            }
            chip_y -= 1;
        }

        // string.IndexOf("") --- 含まれている場合0以上含まれていない場合-1
        //                        大文字小文字の区別はつく

        playerPop();
    }

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
                    var v = blocks[search_y, search_x].transform.position;
                    // playerが手前に描画されるようにするため
                    v.z += -0.5f;
                    player.transform.position = v;
                }
                search_x += 1;
            }
            search_y += 1;
        }

        // StartCoroutine
        StartCoroutine(playerSelectBlock());

    }

    private IEnumerator playerSelectBlock()
    {
        while (true)
        {
            
            for (int y = 0; y < chip_num_y; y++)
            {
                for (int x = 0; x < chip_num_x; x++)
                {
                    blocks[y, x].GetComponent<SpriteRenderer>().material.color = Color.white;
                }
            }
            var select_cell_x = (int)player_controller.retCell().x;
            var select_cell_y = (int)player_controller.retCell().y;
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

            select_cell_x = Mathf.Clamp(select_cell_x, 0, chip_num_x);
            select_cell_y = Mathf.Clamp(select_cell_y, 0, chip_num_y);

            blocks[select_cell_y, select_cell_x]
         .GetComponent<SpriteRenderer>().material.color = Color.red;

            yield return null;
        }
    }

    void Update()
    {

    }
}