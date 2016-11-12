using UnityEngine;
using System.Collections;

public class black_mist : MonoBehaviour {
   [SerializeField]
    private bool on_under_or_left_right;
    [SerializeField]
    private bool move_change;

    private int can_not_look_time;
    private float move;
    private float alpha;
    private bool mist_on;
    private Vector3 pos;
    private Vector3 move_pos;

    // Use this for initialization

    void Start () {
        can_not_look_time = 0;
        move = 0.0f;
        alpha = 0.00f;
        mist_on = false;
        pos = transform.localPosition;
        move_pos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        can_not_look_time++;
        this.GetComponent<CanvasGroup>().alpha = alpha;
        transform.localPosition = move_pos;
        if (mist_on == true && alpha <= 1.00f)
        {
             
            alpha += 0.0250f;
            //40フレームで覆い、40フレームかけて黒くする
            //上下方向 23/20/2=0.575 4/20 0.2
            if (on_under_or_left_right == true) {
                
               move_pos.y = pos.y + move;
                 //上へ
                if (move_change == true) {
                    if (move < 4.0f) move += 0.10f;
                    if (move >= 4.0f)move = 4.0f;
                   
                }
                //下へ
                if (move_change == false)
                {
                    if (move > -4.0f)move -= 0.10f;
                    if (move <= -4.0f)move = -4.0f;
                }
            }
            //左右方向 28 / 20/2 0.7    6.5/20 0.325
            if (on_under_or_left_right == false) {
                move_pos.x = pos.x + move;
                //右へ
                if (move_change == true)
                {
                    if (move < 6.5f)move += 0.16125f;
                    if (move >= 6.5f) move = 6.5f;
                }
                //左へ
                if (move_change == false)
                {
                    if (move > -6.5f)move -= 0.16125f;
                    if (move <= -6.5f) move = -6.5f;
                }
            }
        }
	}
    public void OnClick() {
        if(can_not_look_time>=60) mist_on = true;

    }
    public void OnClick_2()
    {
        can_not_look_time = 0;
        
    }
}
