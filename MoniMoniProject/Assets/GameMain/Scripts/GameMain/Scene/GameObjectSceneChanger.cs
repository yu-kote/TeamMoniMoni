using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameObjectSceneChanger : MonoBehaviour
{

    [SerializeField]
    EnemyManager enemymanager;

    [SerializeField]
    StagingController staging;

    void Start()
    {

    }


    void Update()
    {
        if (enemymanager.is_bosshit)
        {
            if (staging.flushStart())
                SceneManager.LoadScene("Hunting");
        }
    }
}
