using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
using System.Globalization;

public class Scenario : MonoBehaviour
{
    string textfile = @"Scenario/test.txt";
    private string nametxt = "";
    private string guitxt = "";
    private string str = "";
    bool sce_flag = true;
    FileInfo fi;
    StreamReader sr;
    void Start()
    {
        fi = new FileInfo(Application.dataPath + "/" + textfile);

        // 一文字毎読み込み
        sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
    }

    void Update()
    {
        // スペースキーを押したらファイル読み込みする
        if (Input.GetKeyDown(KeyCode.Space) && sce_flag)
        {
            //ReadFile();
            guitxt = null;
            testtext();
        }
    }
    // 読み込んだ情報をGUIとして表示
    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 230, 100, 20), nametxt);
        GUI.TextArea(new Rect(0, 250, Screen.width, 100), guitxt);
    }
    // 読み込み関数
    void ReadFile()
    {

        // test.txtファイルを読み込む
        FileInfo fi = new FileInfo(Application.dataPath + "/" + textfile);
        try
        {
            // 一行毎読み込み
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8))
            {
                guitxt = sr.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            // 改行コード
            guitxt += SetDefaultText();
        }
    }

    void testtext()
    {
        //str = sr.ReadLine();
        //Char[] c = str.ToCharArray();
        //if (c[0] == '#')
        //{
        //    /*
        //    for (int i = 0; i < c.Length; i++)
        //    {
        //        guitxt += c[i];
        //    }
        //    */
        //    guitxt += scenario();
        //}
        string nameline = sr.ReadLine();
        string name = null;

        char[] c = nameline.ToCharArray();
        bool name_start = false;

        for (int i = 0; i < nameline.Length; i++)
        {
            if (c[i] == '#')
            {
                name_start = true;
                nametxt = null;
            }
            if (name_start)
            {
                for (int k = i + 1; k < nameline.Length; k++)
                {
                    if (c[k] == '#') break;
                    name += c[k];
                }
                break;
            }

        }
        nametxt += name;

        for (int i = 0; i < 5; i++)
        {
            bool is_textend = endNLine(sr.ReadLine());

            if (is_textend == true)
            {
                break;
            }
        }
        guitxt += view_text;
        view_text = null;
    }

    string view_text;

    bool endNLine(string line_)
    {

        char[] c = line_.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == '[')
            {
                view_text += "";
                if (c[i + 1] == 'n')
                {
                    return true;
                }
                if (c[i + 1] == 'p')
                {
                    i++;
                    view_text += "\n";
                }
                if(c[i + 1] == 'e')
                {
                    sce_flag = false;
                }
            }
            else
            {
                if (c[i] == ']')
                {
                    view_text += "";
                }
                else
                {
                    view_text += c[i];
                }
            }
        }


        return false;
    }
#if false
    string scenario()
    {
        string sce_text = "";
        string sce_emp = "";
        FileInfo fi = new FileInfo(Application.dataPath + "/" + textfile);

        // 一文字毎読み込み
        StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        sce_emp = sr.ReadLine();
        Char[] c = str.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            switch (c[i])
            {
                case '[':
                    sce_text += "";
                    break;
                case ']':
                    sce_text += "";
                    break;
                case '#':
                    sce_text += "";
                    break;

                case 'p':
                    sce_text += "\n";
                    break;

                case 'n':
                    sce_text += "";

                    break;

                default:
                    sce_text += c[i];
                    break;
            }
            sce_emp = null;
        }
        sr.Close();
        return sce_text;
    }
        string character_name = null;
        string testtext = getTextData();
        // コマンドのごく一部
        if (testtext == ":")
        {
            string character_name_count = getTextData();

            //                          ↓ string "3" => int 3
            for (int i = 0; i < Int32.Parse(character_name_count); i++)
            {
                // 1回目のループ "" + "さ"
                // 2回目のループ "さ" + "ち"
                // 3回目のループ "さち" + "こ"
                character_name += getTextData();
            }
            // 結果 "さちこ"
        }
    }
    private string getTextData()
    {
        // 一文字づつ読み込む処理

        // return で返す関数
        return ":";
    }
#endif
    // 改行コード処理
    string SetDefaultText()
    {
        return "C#あ\n";
    }
}