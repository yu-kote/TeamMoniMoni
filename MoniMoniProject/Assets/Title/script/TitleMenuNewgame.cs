using UnityEngine;
using System.Collections;

public class TitleMenuNewgame : MonoBehaviour
{
    [SerializeField]
    private bool movie;
    private bool first_open;
    private int first_open_time;
    private Vector3 size;
    private Vector3 size_2;
    private int local_time;

    private bool display_newgame;
    private float changesize_newgame;
    
    // Use this for initialization
    void Start()
    {
        first_open = false;
        local_time = 58;
        first_open_time = 0;
        display_newgame = false;
        changesize_newgame = 0.0f;
        size = transform.localScale;
        size_2 = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (movie == true)
        {
            if (first_open == true) first_open_time++;
                 local_time++;
            size_2.x = size.x * changesize_newgame;
            transform.localScale = size_2;

            if (local_time == 2 && display_newgame == false)
            {
                display_newgame = true;
                local_time = 10;
            }
            if (local_time == 4 && display_newgame == true)
            {
                display_newgame = false;
                local_time = 10;
            }

            if (display_newgame == true)
            {
                if (changesize_newgame < 1.00f) changesize_newgame += 0.02f;
                if (changesize_newgame >= 1.00f) changesize_newgame = 1.000f;
            }
            if (display_newgame == false)
            {
                if (changesize_newgame > 0.00f) changesize_newgame -= 0.02f;
                if (changesize_newgame <= 0.00f) changesize_newgame = 0.000f;
            }
        }
        if (movie == false)
        {
            local_time++;
            transform.localScale = size * changesize_newgame;

            if (local_time == 2 && display_newgame == false)
            {
                display_newgame = true;
                local_time = 10;
            }
            if (local_time == 4 && display_newgame == true)
            {
                display_newgame = false;
                local_time = 10;
            }

            if (display_newgame == true)
            {
                if (changesize_newgame < 1.00f) changesize_newgame += 0.02f;
                if (changesize_newgame >= 1.00f) changesize_newgame = 1.000f;
            }
            if (display_newgame == false)
            {
                if (changesize_newgame > 0.00f) changesize_newgame -= 0.02f;
                if (changesize_newgame <= 0.00f) changesize_newgame = 0.000f;
            }
        }

    }
    public void OnClick()
    {
        if (first_open_time >= 56&&local_time >= 56) local_time = 0;      
    }
    public void OnClick_2() {
        first_open = true;
    }
}
