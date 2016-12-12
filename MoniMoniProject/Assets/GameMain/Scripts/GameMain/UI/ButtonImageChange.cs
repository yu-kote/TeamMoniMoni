using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonImageChange : MonoBehaviour
{
    PressButton button;
    Image image;
    public Sprite default_sprite;
    public Sprite press_sprite;



    bool current_is_press;

    void Start()
    {
        button = GetComponent<PressButton>();
        image = GetComponent<Image>();

    }

    void Update()
    {
        if (current_is_press == button.is_press) return;
        current_is_press = button.is_press;

        if (button.is_press)
        {
            image.sprite = press_sprite;
        }
        else
        {
            image.sprite = default_sprite;
        }
    }
}
