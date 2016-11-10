using UnityEngine;
using System.Collections;


/// <summary>
/// UIをオンオフするスクリプト
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject wiivabutton;
    [SerializeField]
    GameObject eventbutton;
    [SerializeField]
    GameObject itembutton;
    [SerializeField]
    GameObject movebutton;

    public void uiOn()
    {
        wiivabutton.SetActive(true);
        eventbutton.SetActive(true);
        itembutton.SetActive(true);
        movebutton.SetActive(true);
    }

    public void uiOff()
    {
        wiivabutton.SetActive(false);
        eventbutton.SetActive(false);
        itembutton.SetActive(false);
        movebutton.SetActive(false);
    }
}
