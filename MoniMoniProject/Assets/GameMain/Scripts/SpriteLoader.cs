using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteLoader : MonoBehaviour
{
    Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    /**
     * 読み込み
     * @param   filepath_
     * @retval  読み込んだSpriteの数(error -1)
     */
    public int Load(string filepath_)
    {
        Object[] resources = Resources.LoadAll(filepath_, typeof(Sprite));

        if (resources == null || resources.Length == 0) return -1;

        int len = resources.Length;

        for (int i = 0; i < len; i++)
        {

            Debug.Log("AddSprite : " + resources[i].name);
            sprites.Add(resources[i].name, resources[i] as Sprite);
        }

        return len;
    }

    /**
     * 取得
     * @param   name_   Spriteの名前
     * @retval  Spriteのインスタンス(なければnull)
     */
    public Sprite GetSprite(string name_)
    {
        if (!sprites.ContainsKey(name_))
            return null;
        return sprites[name];
    }

}
