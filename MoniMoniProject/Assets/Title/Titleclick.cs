using UnityEngine;
using System.Collections;

public class Titleclick : MonoBehaviour
{
    public bool clicked_newgame;
    public bool clicked_continue;
    int clicked_time;
    private Vector2 pos;
    private Vector2 pos_move;

    // Use this for initialization
    void Start()
    {
        clicked_time = 0;
        clicked_newgame = false;
        clicked_continue = false;
        pos = new Vector2(transform.localPosition.x,
           transform.localPosition.y);
        pos_move = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        clicked_time++;
        transform.localPosition = new Vector2(pos.x + pos_move.x, pos.y + pos_move.y);

        if (clicked_newgame == false)
        {
            if (clicked_continue == true)
            {
                if (pos_move.y <= 8.1f)
                    pos_move.y += 0.1f;
            }
            if (clicked_continue == false)
            {
                if (pos_move.y > 0.0f)
                    pos_move.y -= 0.1f;
                if (pos_move.y < 0.0f)
                    pos_move.y += 0.1f;
            }
        }

        if (clicked_newgame == true)
        {
            if (clicked_continue == false)
            {
                if (pos_move.y >= -8.1f)
                    pos_move.y -= 0.1f;
            }
        }


        if (Input.GetMouseButtonDown(0))
        {

            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                RaycastHit2D hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
                if (hitObject)
                {
                    if (clicked_time > 85)
                    {
                        clicked_time = 0;
                        if (hitObject.collider.gameObject.name == "newgame_command")
                        {
                            Debug.Log("hit object is " + hitObject.collider.gameObject.name
                                 + "\nthis command is NewGame");
                            clicked_newgame = true;
                        }
                        else if (hitObject.collider.gameObject.name == "continue_command")
                        {
                            Debug.Log("hit object is " + hitObject.collider.gameObject.name
                                    + "\nthis command is Continue");
                            clicked_continue = true;
                        }
                        else if (hitObject.collider.gameObject.name == "end_command")
                        {
                            Debug.Log("hit object is " + hitObject.collider.gameObject.name
                                   + "\nthis command is End");
                            Application.Quit();
                        }
                        else if (hitObject.collider.gameObject.name == "いいよ")
                        {
                            Debug.Log("hit object is " + hitObject.collider.gameObject.name
                                   + "\nthis command is happy");
                            Application.Quit();
                        }
                        else if (hitObject.collider.gameObject.name == "ダメダメ")
                        {
                            Debug.Log("hit object is " + hitObject.collider.gameObject.name
                                   + "\nthis command is sad");
                            Application.Quit();
                        }
                        else if (hitObject.collider.gameObject.name == "裏地")
                        {
                            Debug.Log("hit object is null \nthis command is back");
                            clicked_newgame = false;
                            clicked_continue = false;
                        }
                    }
                }
            }
        }


    }
}
