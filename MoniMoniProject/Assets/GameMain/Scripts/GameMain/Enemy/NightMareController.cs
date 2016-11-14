using UnityEngine;
using System.Collections;

public class NightMareController : MonoBehaviour
{
    [SerializeField]
    MapChipController mapchip;

    public bool is_move;
    public float speed;

    public int movecount;
    int currentcount;

    public Vector2 prev_cell;
    // Use this for initialization
    void Start()
    {
        is_move = false;
        movecount = 0;
        currentcount = movecount;
        prev_cell = retCell();
    }

    // Update is called once per frame
    void Update()
    {

        if (!is_move)
        {
            return;
        }
        Vector3 pos = transform.position;
        if (movecount == 0)
        {
            pos.x -= speed;
            if (prev_cell + new Vector2(-5, 0) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 1)
        {
            pos.y += speed;
            if (prev_cell + new Vector2(0, -7) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 2)
        {
            pos.x -= speed;
            if (prev_cell + new Vector2(-1, 0) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 3)
        {
            pos.y += speed;
            if (prev_cell + new Vector2(0, -2) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 4)
        {
            pos.x -= speed;
            if (prev_cell + new Vector2(-5, 0) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 5)
        {
            pos.y += speed;
            if (prev_cell + new Vector2(0, -3) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 6)
        {
            pos.x -= speed;
            if (prev_cell + new Vector2(-5, 0) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 7)
        {
            pos.y -= speed;
            if (prev_cell + new Vector2(0, 5) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 8)
        {
            pos.x += speed;
            if (prev_cell + new Vector2(1, 0) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 9)
        {
            pos.y -= speed;
            if (prev_cell + new Vector2(0, 7) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 10)
        {
            pos.x += speed;
            if (prev_cell + new Vector2(14, 0) == retCell())
            {
                movecount++;
                prev_cell = retCell();
            }
        }
        else if (movecount == 11)
        {
            pos.y += speed;
            if (prev_cell + new Vector2(0, -1) == retCell())
            {
                movecount = 0;
                prev_cell = retCell();
            }
        }

        if (currentcount != movecount)
        {
            currentcount = movecount;
            //pos = new Vector2(prev_cell.x / 2, (prev_cell.y * -1) / 2);
        }

        transform.position = pos;

    }

    public Vector2 retCell()
    {
        var pos = transform.position;
        Vector2 cell_f = pos / mapchip.chip_size;

        Vector2 cell_i = new Vector2(Mathf.RoundToInt(cell_f.x), Mathf.RoundToInt(cell_f.y));
        cell_i.x = Mathf.Abs(cell_i.x);
        cell_i.y = Mathf.Abs(cell_i.y);

        return cell_i;
    }
}
