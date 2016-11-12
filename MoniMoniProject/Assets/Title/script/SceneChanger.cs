using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour {
    [SerializeField]
    private int time_effect;
    [SerializeField]
    private string SceneName;

    private bool clicked;

    private string GameMain;
    private string Hunting;
    private string Hunting2;
    private string Scenario;
    
    // Use this for initialization
    void Start () {
        clicked = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (clicked == true) {
            time_effect--;
            if (time_effect == 0)
            {
                if (SceneName == "GameMain") SceneManager.LoadScene("GameMain");
                if (SceneName == "Hunting") SceneManager.LoadScene("Hunting");
                if (SceneName == "Hunting2") SceneManager.LoadScene("Hunting2");
                if (SceneName == "Scenario") SceneManager.LoadScene("Scenario");
            }
        }


	}
    public void OnClick() {
        clicked = true;
       
    }
}
