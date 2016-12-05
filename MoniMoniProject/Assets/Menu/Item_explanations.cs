using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Item_explanations : MonoBehaviour
{
    Image MainSpriteRenderer;
    public Sprite Sprite_one;
    public Sprite Sprite_two;
    private Vector3 pos;
    GameObject name;
    GameObject exp;
    GameObject item;
    // Use this for initialization
    void Start()
    {
        
        name = transform.Find("Item_exp_name").gameObject;
        exp = transform.Find("Item_exp_exp").gameObject;
        item = transform.Find("Item_exp_item").gameObject;
        pos = new Vector3(0, 20, 0);
        MainSpriteRenderer = item.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pos;
    }
    public void OnClick_1() {
        pos = new Vector3(0,0,0);
        name.GetComponent<Text>().text = "アイテム１号\nローマ調の石像";
        exp.GetComponent<Text>().text =  "これはなんの変哲もない石像のはず。\nこれスクリプトで入れてるなぅ" ;
        MainSpriteRenderer.sprite = Sprite_one;
        MainSpriteRenderer.transform.localScale = new Vector3(0.05f, 0.05f, 1);
    }
    public void OnClick_2()
    {
        pos = new Vector3(0, 0, 0);
        name.GetComponent<Text>().text = "アイテム2号\nなんか女性";
        exp.GetComponent<Text>().text = "これはなんの変哲もない女性のはず。\nこれスクリプトで入れてるなぅ";
        MainSpriteRenderer.sprite = Sprite_two;
        MainSpriteRenderer.transform.localScale = new Vector3(0.05f, 0.1f, 1);
    }
    public void OnClickFalse()
    {
        pos = new Vector3(0, 20, 0);
    }
}
