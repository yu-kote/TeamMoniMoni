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

    public bool is_talknow;

    string loadtextpath;
    string loadtextdata;
    string draw_name;
    string draw_talk;


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

            textDataCheck(loadtextdata);

            nametext.text = draw_name;
            talktext.text = draw_talk;
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
                i += draw_name.Length + 2;
            }

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

            if (chara_array[i] == ' ' ||
                chara_array[i] == '\r' ||
                chara_array[i] == '\n') continue;

            // 会話文に追加
            draw_talk += chara_array[i];
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

    void Start()
    {
        is_talknow = false;
    }

    void Update()
    {
        if (player.state != PlayerController.State.NORMAL)
        {
            if (is_talknow)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    loadTalk(loadtextpath);

                    if (is_talknow == false)
                    {
                        player.state = PlayerController.State.NORMAL;
                    }
                }
            }
        }
    }

}
