using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    NightMareController nightmare;

    [SerializeField]
    PlayerController player;

    void Start()
    {

    }

    public void nightmareRePop()
    {
        nightmare.transform.position = new Vector3(9, -8, nightmare.transform.position.z);
        nightmare.is_move = true;
        nightmare.prev_cell = nightmare.retCell();
    }

    void Update()
    {
        if (nightmare.is_move)
            if (pointToCircle(player.transform.position, 0.6f, nightmare.transform.position))
            {
                Debug.Log("hit");
            }
    }

    // 点と円の判定(当たってたらtrue)
    bool pointToCircle(Vector2 circlepos, float radius, Vector2 pointpos)
    {
        float x = (pointpos.x - circlepos.x) * (pointpos.x - circlepos.x);
        float y = (pointpos.y - circlepos.y) * (pointpos.y - circlepos.y);

        return x + y <= radius * radius;
    }
}
