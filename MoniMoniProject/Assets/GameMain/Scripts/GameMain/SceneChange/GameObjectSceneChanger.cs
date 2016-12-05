using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameObjectSceneChanger : MonoBehaviour
{

    [SerializeField]
    EnemyManager enemymanager;

    void Start()
    {

    }


    void Update()
    {
        if (enemymanager.is_bosshit)
        {
            SceneManager.LoadScene("Hunting");
        }
    }
}
