using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    [SerializeField]
    GameObject uicanvas;

    [SerializeField]
    GameObject talkcanvas;


    public void playerStateChangeCanvas()
    {
        uicanvas.SetActive(false);
        talkcanvas.SetActive(false);
        switch (player.state)
        {
            case PlayerController.State.NORMAL:
                uicanvas.SetActive(true);
                break;
            case PlayerController.State.EVENT:
                break;
            case PlayerController.State.TALK:
                talkcanvas.SetActive(true);
                break;
            case PlayerController.State.SKILL:
                uicanvas.SetActive(true);
                break;
        }
    }

}
