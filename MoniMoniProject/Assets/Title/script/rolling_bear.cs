using UnityEngine;
using System.Collections;

public class rolling_bear : MonoBehaviour
{
    [SerializeField]
    private bool roll_chenge;
    [SerializeField]
    private bool roll_z;
    [SerializeField]
    private bool roll_xy;

    bool x_or_y;
    int roll_xy_time;
    // Use this for initialization
    void Start()
    {
        roll_xy_time = 0;
        x_or_y = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (roll_chenge == true)
        {
            roll_xy_time++;

            if (x_or_y == false)
            {
                if (roll_xy_time == 359)
                {
                    x_or_y = true;
                    roll_xy_time = 0;
                }
                if (roll_xy == false) transform.Rotate(-1, 0, 0);
                if (roll_xy == true) transform.Rotate(1, 0, 0);
            }
            if (x_or_y == true)
            {
                if (roll_xy_time == 359)
                {
                    x_or_y = false;
                    roll_xy_time = 0;
                }
                if (roll_xy == false) transform.Rotate(0, 1, 0);
                if (roll_xy == true) transform.Rotate(0, -1, 0);
            }
        }
        if (roll_chenge == false)
        {
            if (roll_z == false) transform.Rotate(0, 0, 1);
            if (roll_z == true) transform.Rotate(0, 0, -1);
        }
    }
}
