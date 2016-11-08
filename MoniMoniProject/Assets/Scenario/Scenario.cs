using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
using System.Globalization;

public class Scenario : MonoBehaviour
{
    private string guitxt = "";
    private string str = "";
    int ch = 0;
    int count = 0;
    bool sce_flag = true;

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押したらファイル読み込みする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ReadFile();
            testtext();
        }
    }
    // 読み込んだ情報をGUIとして表示
    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 250, Screen.width, 100), guitxt);
    }
    // 読み込み関数
    void ReadFile()
    {

        // test.txtファイルを読み込む
        FileInfo fi = new FileInfo(Application.dataPath + "/" + "Scenario/test.txt");
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
        FileInfo fi = new FileInfo(Application.dataPath + "/" + "Scenario/test.txt");

        // 一文字毎読み込み
        StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        str = sr.ReadLine();
        Char[] c = str.ToCharArray();
        if (c[0] == '#')
        {
            while (c[ch] == ' ')
            {
                ch += 1;
                count += 1;
            }
            ch = 0;
            for (int i = 0; i < count; i++)
            {
                guitxt += c[i];
            }
            count = 0;
        }
    }

    string scenario()
    {
        string sce_text = "";
        string sce_emp = "";
        FileInfo fi = new FileInfo(Application.dataPath + "/" + "Scenario/test.txt");

        // 一文字毎読み込み
        StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        sce_emp = sr.ReadLine();
        {

            switch (sce_emp)
            {
                case "[":
                    sce_text += "";
                    break;
                case "]":
                    sce_text += "";
                    break;
                case "#":
                    sce_text += "";
                    break;

                case "p":
                    sce_text += "\n";
                    break;

                case "n":
                    sce_text += "";
                    sce_flag = false;
                    break;

                default:
                    sce_text += sce_emp;
                    break;
            }
            sce_emp = null;
        }
        sr.Close();

        return sce_text;
    }
#if false
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

#if false
    void f()
    {
        string h = a();
    }

    string a()
    {
        return "a";
    }
#endif
    // 改行コード処理
    string SetDefaultText()
    {
        return "C#あ\n";
    }

}