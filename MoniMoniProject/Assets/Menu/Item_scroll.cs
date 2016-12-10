using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item_scroll : MonoBehaviour {
    [SerializeField]
    private int y_number;
    [SerializeField]
    private Slider slider;
    private float level;

    Vector2 slider_level_pos_1;
    Vector2 slider_level_pos_2;
    Vector2 slider_level_pos_3;
    Vector2 slider_level_pos_4;
    Vector2 slider_level_pos_no;
   
    // Use this for initialization
    void Start () {
        slider.value = 0;
        level = slider.value;
        slider_level_pos_1 = new Vector2 (0,3.6f);
        slider_level_pos_2 = new Vector2(0,1.3f);
        slider_level_pos_3 = new Vector2(0,-1.0f);
        slider_level_pos_4 = new Vector2(0,-3.3f);
        slider_level_pos_no = new Vector2(0,10.0f);

        switch (y_number)
        {
            case 1:
                transform.localPosition = slider_level_pos_1;
                break;
            case 2:
                transform.localPosition = slider_level_pos_2;
                break;
            case 3:
                transform.localPosition = slider_level_pos_3;
                break;
            case 4:
                transform.localPosition = slider_level_pos_4;
                break;
            case 5:
                transform.localPosition = slider_level_pos_no;
                break;
            case 6:
                transform.localPosition = slider_level_pos_no;
                break;
            case 7:
                transform.localPosition = slider_level_pos_no;
                break;
            case 8:
                transform.localPosition = slider_level_pos_no;
                break;
        }
    }

    // Update is called once per frame
    void Update () {
        if (slider.value != level)
        {
            level = slider.value;
            if (slider.value == 0)
            {
                switch (y_number)
                {
                    case 1:
                        transform.localPosition = slider_level_pos_1;
                        break;
                    case 2:
                        transform.localPosition = slider_level_pos_2;
                        break;
                    case 3:
                        transform.localPosition = slider_level_pos_3;
                        break;
                    case 4:
                        transform.localPosition = slider_level_pos_4;
                        break;
                    case 5:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 6:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 7:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 8:
                        transform.localPosition = slider_level_pos_no;
                        break;
                }
                
            }
            else if (slider.value == 1)
            {
                switch (y_number)
                {
                    case 1:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 2:
                        transform.localPosition = slider_level_pos_1;
                        break;
                    case 3:
                        transform.localPosition = slider_level_pos_2;
                        break;
                    case 4:
                        transform.localPosition = slider_level_pos_3;
                        break;
                    case 5:
                        transform.localPosition = slider_level_pos_4;
                        break;
                    case 6:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 7:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 8:
                        transform.localPosition = slider_level_pos_no;
                        break;
                }
            }
            else if (slider.value == 2)
            {
                switch (y_number)
                {
                    case 1:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 2:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 3:
                        transform.localPosition = slider_level_pos_1;
                        break;
                    case 4:
                        transform.localPosition = slider_level_pos_2;
                        break;
                    case 5:
                        transform.localPosition = slider_level_pos_3;
                        break;
                    case 6:
                        transform.localPosition = slider_level_pos_4;
                        break;
                    case 7:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 8:
                        transform.localPosition = slider_level_pos_no;
                        break;
                }
            }
            else if (slider.value == 3)
            {
                switch (y_number)
                {
                    case 1:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 2:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 3:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 4:
                        transform.localPosition = slider_level_pos_1;
                        break;
                    case 5:
                        transform.localPosition = slider_level_pos_2;
                        break;
                    case 6:
                        transform.localPosition = slider_level_pos_3;
                        break;
                    case 7:
                        transform.localPosition = slider_level_pos_4;
                        break;
                    case 8:
                        transform.localPosition = slider_level_pos_no;
                        break;
                }
            }
            else if (slider.value == 4)
            {
                switch (y_number)
                {
                    case 1:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 2:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 3:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 4:
                        transform.localPosition = slider_level_pos_no;
                        break;
                    case 5:
                        transform.localPosition = slider_level_pos_1;
                        break;
                    case 6:
                        transform.localPosition = slider_level_pos_2;
                        break;
                    case 7:
                        transform.localPosition = slider_level_pos_3;
                        break;
                    case 8:
                        transform.localPosition = slider_level_pos_4;
                        break;
                }
            }
        }
    }

}
