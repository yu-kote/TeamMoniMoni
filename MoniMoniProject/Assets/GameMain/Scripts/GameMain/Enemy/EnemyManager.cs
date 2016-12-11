using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    NightMareController nightmare;

    [SerializeField]
    PlayerController player;

    [SerializeField]
    MapChipController mapchip;

    public List<GameObject> enemys;

    // エネミーの数
    public int enemy_num;


    public bool is_bosshit;

    void Start()
    {
        is_bosshit = false;
        dreamersPop();
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
                is_bosshit = true;
            }
    }

    void dreamersPop()
    {
        for (int i = 0; i < enemy_num; i++)
        {
            var enemy = Resources.Load<GameObject>("Prefabs/Enemy");
            var ai = enemy.GetComponent<EnemyAI>();
            ai.mapchip = mapchip;
            ai.direction = EnemyAI.EnemyDirection.DOWN;
            ai.enemynumber = i;

            enemy.transform.position = new Vector3(4.0f, -58.0f, -0.4f);

            enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);

            enemys.Add((GameObject)Instantiate(enemy, transform));
        }
    }

    /// <summary>
    /// 点と円の判定(当たってたらtrue)
    /// </summary>
    bool pointToCircle(Vector2 circlepos, float radius, Vector2 pointpos)
    {
        float x = (pointpos.x - circlepos.x) * (pointpos.x - circlepos.x);
        float y = (pointpos.y - circlepos.y) * (pointpos.y - circlepos.y);

        return x + y <= radius * radius;
    }
}
