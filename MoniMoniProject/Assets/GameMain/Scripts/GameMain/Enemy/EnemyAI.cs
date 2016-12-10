using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    // エネミーの向き
    public enum EnemyDirection
    {
        UP, DOWN, RIGHT, LEFT
    }

    EnemyDirection direction = EnemyDirection.DOWN;
    Vector2 vec;

    public enum State
    {
        IDLE,
        ROOT_NORMALMOVE,
        ROOT_LOCATETRAPMOVE,
        ROOT_CHANGE,
        ON_TRAP,
    }

    State state;
    State currentstate;

    void Start()
    {

    }


    void Update()
    {

    }
}
