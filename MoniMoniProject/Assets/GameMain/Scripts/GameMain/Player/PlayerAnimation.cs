using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{

    Animator anim;
    [SerializeField]
    PlayerController player_controller = null;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = player_controller.player_direction;
        anim.SetInteger("player_direction", (int)direction);
        var vec = player_controller.vec;
        anim.SetFloat("up_down_vec", vec.y);
        anim.SetFloat("right_left_vec", vec.x);

        anim.SetInteger("player_anim_state", (int)player_controller.animstate);
    }
}
