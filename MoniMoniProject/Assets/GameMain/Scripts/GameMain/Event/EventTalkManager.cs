using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


/// <summary>
/// イベントが起こった時に話をするところのスクリプト
/// </summary>
public class EventTalkManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    [SerializeField]
    GameObject talkcanvas;

    [SerializeField]
    Text nametext;
    [SerializeField]
    Text talktext;

    [SerializeField]
    Image charaimage1;

    public bool is_talknow;

    // 会話の種類
    public enum TalkMode
    {
        NORMAL,
        SELECT,
    }
    public TalkMode talkmode;

    string loadtextpath;
    string loadtextdata;
    string draw_name;
    string draw_talk;
    string texturename;

    Sprite[] sprites;

    int current_read_line;

    public void startTalk(string textname_)
    {
        loadtextpath = textname_;
        // 会話してなかったらテキストを読む
        if (is_talknow == false)
        {
            is_talknow = true;

            current_read_line = 0;
            using (var sr = new StreamReader("Assets/GameMain/Resources/EventData/" + textname_ + ".txt"))
            {
                loadtextdata = sr.ReadToEnd();
            }
            loadTalk(textname_);
            player.state = PlayerController.State.TALK;
        }
    }

    /// <summary>
    /// テキストファイルを開いて名前と会話を取り出す関数
    /// </summary>
    /// <param name="textname_"></param>
    public void loadTalk(string textname_)
    {
        // 会話していたら呼ばれるたびに会話文と名前を更新する
        if (is_talknow)
        {
            draw_name = null;
            draw_talk = null;
            texturename = null;

            textDataCheck(loadtextdata);

            nametext.text = draw_name;
            talktext.text = draw_talk;

            charaimage1.sprite =
                System.Array.Find<Sprite>(
                                    sprites, (sprite) => sprite.name.Equals(
                                        texturename));
            if (charaimage1.sprite == null)
            {
                charaimage1.sprite = System.Array.Find<Sprite>(
                                    sprites, (sprite) => sprite.name.Equals(
                                        "none"));
            }

        }
    }

    /// <summary>
    /// 渡されたテキストを分解して表示する文字列に保存する関数
    /// </summary>
    /// <param name="loadtext_">読み込んだ文字列</param>
    void textDataCheck(string loadtext_)
    {
        char[] chara_array = loadtext_.ToCharArray();
        for (int i = current_read_line; i < chara_array.Length; i++)
        {
            string command = null;

            // メモ書きの判定
            if (chara_array[i] == '/' && chara_array[i + 1] == '/')
            {
                while (true)
                {
                    i++;
                    if (chara_array[i] == '\n')
                    {
                        break;
                    }
                }
                continue;
            }

            // コマンド開始
            if (chara_array[i] == '[')
            {
                command = commandSearch(loadtext_, i);
                if (command != "end")
                    i += command.Length + 2;
            }
            // 名前開始
            else if (chara_array[i] == '#')
            {
                draw_name = commandSearch(loadtext_, i);
                if (draw_name != null)
                    i += draw_name.Length + 1;
                else
                {
                    draw_name = " ";
                    for (int k = i + 1; k < chara_array.Length; k++)
                    {
                        if (chara_array[k] == '#')
                        {
                            i = k;
                            break;
                        }
                    }
                }
                continue;
            }

            // 会話の種類 (普通の会話や選択肢など)
            if (command == "text")
            {
                talkmode = TalkMode.NORMAL;
            }
            else if (command == "root")
            {
                talkmode = TalkMode.SELECT;
            }

            if (talkmode == TalkMode.NORMAL)
            {
                // コマンドを探すswitch文
                switch (command)
                {
                    case "p":
                        draw_talk += "\n";
                        continue;
                    case "n":
                        current_read_line = i;
                        return;
                    case "end":
                        is_talknow = false;
                        return;
                }

                if (command != null)
                {
                    // キャラを表示させるコマンドが来たら通る
                    if (command.IndexOf("chara") != -1)
                    {
                        texturename = commandPickOutTextureName(command);
                    }
                    // エフェクトが来たら通る
                    if (command.IndexOf("effect") != -1)
                    {

                    }
                }

                if (chara_array[i] == ' ' ||
                    chara_array[i] == '\r' ||
                    chara_array[i] == '\n') continue;

                // 会話文に追加
                draw_talk += chara_array[i];
            }
            if (talkmode == TalkMode.SELECT)
            {


            }
        }

    }

    /// <summary>
    /// コマンドを取り出す関数
    /// </summary>
    /// <param name="loadtext_">テキストから読み込んだ文字列</param>
    /// <param name="currentcharapos_">読んでいる位置</param>
    /// <returns>コマンド(文字列)</returns>
    string commandSearch(string loadtext_, int currentcharapos_)
    {
        // char配列にテキスト入れる
        char[] c = loadtext_.ToCharArray();
        // 位置を保存
        int i = currentcharapos_;

        string command = null;

        // コマンドが終わったらループ終了
        while (true)
        {
            i++;
            if (c[i] == ' ') continue;
            if (c[i] == ']' || c[i] == '#') break;
            command += c[i];
        }

        return command;
    }

    /// <summary>
    /// コマンドの中からtextureの情報を引き出す関数
    /// </summary>
    /// <param name="command_"></param>
    /// <returns></returns>
    string commandPickOutTextureName(string command_)
    {
        char[] c = command_.ToCharArray();
        char texturestart = '\'';
        bool is_texturestart = false;
        string texturename = null;
        int commandcount = 0;

        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == texturestart)
            {
                is_texturestart = !is_texturestart;
                commandcount++;
                continue;
            }

            if (is_texturestart)
            {
                texturename += c[i];
            }
            if (commandcount >= 2)
            {
                texturename += c[i];
            }
        }
        return texturename;
    }


    void Start()
    {
        is_talknow = false;
        sprites = Resources.LoadAll<Sprite>("Textures/Talk");
    }

    void Update()
    {
        if (player.state == PlayerController.State.TALK)
        {
            if (is_talknow)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    loadTalk(loadtextpath);

                }
                if (is_talknow == false)
                {
                    player.state = PlayerController.State.NORMAL;
                }
            }
        }
    }

}
