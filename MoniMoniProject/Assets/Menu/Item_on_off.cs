using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

public class Item_on_off : MonoBehaviour
{
    Dictionary<int, bool> data = new Dictionary<int, bool>();
    [SerializeField]
    int Item_number;
    bool[] Item_get = new bool[60];
    int time;
    bool value;
    // Use this for initialization
    void Start()
    {
        // for(int i = 0 ; i < 60; i++)data[i]=false;
        //data.Add(Item_number, false);
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        time++;

        if (time == 300)
        {
            data.Add(Item_number, true);
            value = data[Item_number];


            if (Item_get[Item_number] == false)
            {
                Item_get[Item_number] = data[Item_number];
            }

           
        
            if (value == true)
            {
                Debug.Log("アイテム" + Item_number + "番がtrueです");
            }
       }

         

    }

}
