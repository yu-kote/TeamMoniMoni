using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour {
    [SerializeField]
    private int time_effect;
    [SerializeField]
    private string SceneName;

    private int can_not_click_time;
    private bool clicked;

    private string GameMain;
    private string Hunting;
    private string Hunting2;
    private string Scenario;
    
    // Use this for initialization
    void Start () {
        clicked = false;
        can_not_click_time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        can_not_click_time++;
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
        if(can_not_click_time>60)clicked = true;
       
    }
    public void OnClick_close() {
        can_not_click_time = 0;
    }
}
