using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{

    [SerializeField]
    private GameObject slide_text;
    Text text_slide;
    [SerializeField]
    private GameObject eat_end_text;
    Text text_eat_end;
    Vector3 text_eat_end_pos;
    public bool text_eat_end_look;
    float text_eat_end_move;

    private Vector3 pos;
    bool starter;
    //[SerializeField]
    //private Slider eat_slider;
    //private float slide_level;
    //private int eat_count;
    //// Use this for initialization
    private Image image_eat;
    [SerializeField]
    private int chew_number;
    float pos_upper;
    public static Vector3 mousePosition;
    Vector3 touch_pos;
    private bool eating_1;
    private bool eating_2;
    private bool eating_yet;
    private bool turning;
    public int eat_count;
    public int chew_count;

    public Sprite eat_1;
    public Sprite eat_2;
    public Sprite eat_3;
    public Sprite eat_4;
    public bool chew_halo;
    public int effect_time;

    private bool eat_end;
    private GameObject eat_effect;
    float effect_rotate;
    float eat_effect_alpha;
    void Start()
    {
        text_eat_end_pos = new Vector3(0, 1, 0);
        text_eat_end_look = false;
        text_eat_end_move = 0.0f;
        text_slide = slide_text.GetComponent<Text>();
        text_eat_end = eat_end_text.GetComponent<Text>();
        pos = transform.localPosition;
        starter = false;
        eat_end = false;
        mousePosition = Vector3.zero;
        touch_pos = Vector3.zero;
        pos_upper = 0.0f;
        eating_1 = false;
        eating_2 = false;
        eating_yet = false;
        turning = false;
        eat_count = 0;
        chew_count = 0; ;
        image_eat = GetComponent<Image>();
        effect_time = 0;
        //slide_level = eat_slider.value;
        //eat_count = 0;
        eat_effect = transform.Find("eat_effect").gameObject;
        effect_rotate = 0.0f;
        eat_effect_alpha = 0.0f;
    }

    // Update is called once per frame


    void Update()
    {
        if (starter == false) {
            transform.localPosition = new Vector3(200, 0, 0);
            
        }
        if (starter == true)
        {
            
            mousePosition = Input.mousePosition;
            eat_effect.GetComponent<CanvasGroup>().alpha = eat_effect_alpha;
            eat_effect.transform.localEulerAngles = new Vector3(0, 180, effect_rotate);
            effect_rotate += 10.0f;
            if (Input.GetMouseButtonDown(0))
            {
                //if (mousePosition.x > -1.0f && mousePosition.x < 495.0f) print("いま左ボタンが押された");
                //else {
                //    print(mousePosition);
                //}
                //if (mousePosition.y > -1.0f && mousePosition.y < 313.0f) print("いま左ボタンが押された");
                //else
                //{
                //    print(mousePosition);
                //}
                if (mousePosition.y > 190.0f && mousePosition.y < 313.0f) eating_1 = true;
                else if (mousePosition.y > -5.0f && mousePosition.y < 120.0f) eating_2 = true;
                else if (mousePosition.y >= 120.0f && mousePosition.y <= 190.0f) eating_yet = true;
                else
                {
                    print(mousePosition);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                eating_1 = false;
                eating_2 = false;
                eating_yet = false;
                turning = false;
                eat_count = 0;
            }
            if (chew_halo == true)
            {
                effect_time++;
                eat_effect_alpha -= 0.05f;
                if (effect_time == 10)
                {
                    effect_time = 0;
                    eat_effect_alpha = 0;
                    chew_halo = false;
                }
            }
            if (eat_end == false)
            {
                if (eating_1 == true)
                {
                    if (mousePosition.y > 190.0f && mousePosition.y < 313.0f)
                    {
                        eat_count = 0;
                        if (turning == true)
                        {
                            chew_halo = true;
                            chew_count++;
                            turning = false;
                            eat_effect_alpha = 0.5f;
                        }
                    }
                    if (mousePosition.y > 120.0f && mousePosition.y < 190.0f)
                    {
                        eat_count = 1;
                        if (turning == true)
                        {
                            eat_count = 3;
                        }
                    }
                    if (mousePosition.y > 50.0f && mousePosition.y < 120.0f)
                    {
                        eat_count = 2;
                        turning = true;
                    }

                }
                if (eating_2 == true)
                {
                    if (mousePosition.y > 50.0f && mousePosition.y < 120.0f)
                    {
                        eat_count = 0;
                        if (turning == true)
                        {
                            chew_halo = true;
                            chew_count++;
                            turning = false;
                            eat_effect_alpha = 0.5f;
                        }
                    }
                    if (mousePosition.y > 120.0f && mousePosition.y < 190.0f)
                    {
                        eat_count = 1;
                        if (turning == true)
                        {
                            eat_count = 3;
                        }
                    }
                    if (mousePosition.y > 190.0f && mousePosition.y < 313.0f)
                    {
                        eat_count = 2;
                        turning = true;

                    }
                }

                if (eating_yet == true)
                {
                    if (mousePosition.y > 190.0f && mousePosition.y < 313.0f)
                    {
                        eating_1 = true;
                        eating_yet = false;
                    }
                    else if (mousePosition.y > -5.0f && mousePosition.y < 120.0f)
                    {
                        eating_2 = true;
                        eating_yet = false;
                    }
                    else { };
                }

                switch (eat_count)
                {
                    case 0:
                        if (eating_yet == true) image_eat.sprite = eat_4;
                        else image_eat.sprite = eat_1;
                        break;
                    case 1:
                        image_eat.sprite = eat_2;
                        break;
                    case 2:
                        image_eat.sprite = eat_3;
                        break;
                    case 3:
                        image_eat.sprite = eat_4;
                        break;
                }
            }
            if (eat_end == true)
            {
                image_eat.sprite = eat_1;
                if (eat_effect_alpha > 0.0f) eat_effect_alpha -= 0.03f;
                if (eat_effect_alpha < 0.0f) eat_effect_alpha = 0.0f;
                text_eat_end.transform.localPosition = text_eat_end_pos;
                if (text_eat_end_look == false)
                {
                    if (text_eat_end_pos.y > -4)text_eat_end_pos.y -= 0.05f;
                    if(text_eat_end_pos.y  > -3) text_eat_end_pos.y -= 0.02f;
                    if (text_eat_end_pos.y > -2) text_eat_end_pos.y -= 0.015f;
                    if (text_eat_end_pos.y > -1) text_eat_end_pos.y -= 0.015f;
                    if (text_eat_end_pos.y > 0) text_eat_end_pos.y -= 0.01f;
                    if (text_eat_end_pos.y <= -4) text_eat_end_look = true;
                }
                else
                {
                    text_eat_end_move += 0.10f;
                    text_eat_end_pos.y = -4 + Mathf.Sin(-text_eat_end_move) / 4;
                }
            }
            if (chew_count == chew_number)
            {
                chew_count = 0;
                eat_end = true;
                print("咀嚼完了");
                text_slide.fontSize = 40;
                text_slide.text = " ";
                text_eat_end.text = "ごちそうさまでした！";
               
               
            }


            //    if (eat_slider.value != slide_level)
            //    {
            //        slide_level = eat_slider.value;
            //        if (eat_slider.value == 0)
            //        {



            //        }
            //        if (eat_slider.value == 1)
            //        {



            //        }
            //        if (eat_slider.value == 3)
            //        {



            //        }
            //        if (eat_slider.value == 5)
            //        {



            //        }
            //        if (eat_slider.value == 7)
            //        {



            //        }
            //        if (eat_slider.value == 8)
            //        {



            //        }
            //    }
        }
    }
    public void SlideStart() {
        starter = true;
        transform.localPosition = pos;
        text_slide.text = "し縦てに食スべラてイねド";
    }
}
