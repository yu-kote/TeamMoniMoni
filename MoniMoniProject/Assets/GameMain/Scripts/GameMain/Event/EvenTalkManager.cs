using UnityEngine;
using System.Collections;
using System.IO;


/// <summary>
/// イベントが起こった時に話をするところのスクリプト
/// </summary>
public class EvenTalkManager : MonoBehaviour
{

    string getCommandAndName(string line_, ref int num_)
    {
        int command_length = 0;
        string command = null;
        char[] c = line_.ToCharArray();

        //num_ += 1;
        for (int i = num_ + 1; i < c.Length; i++)
        {
            command_length++;
            if (c[i] == ' ') continue;
            if (c[i] == ']') // コマンド終了
                break;
            if (c[i] == '#') // 名前終了
                break;
            command += c[i];
        }

        num_ += command_length;
        return command;
    }

    string draw_name;
    string draw_talk;


    long text_read_line;

    public void loadTalk(string textname_)
    {
        draw_name = null;
        draw_talk = null;
        using (var fs = new FileStream("Assets/GameMain/Resources/EventData/" + textname_ + ".txt", FileMode.Open))
        {
            Debug.Log(fs.Length);
            fs.Seek(text_read_line, SeekOrigin.Begin);
            using (var sr = new StreamReader(fs))
            {
                commandCheck(sr);

                Debug.Log(draw_name);
                Debug.Log(draw_talk);
                Debug.Log(text_read_line);
            }

        }
    }

    void commandCheck(StreamReader sr_)
    {
        for (;;)
        {
            string line = sr_.ReadLine();
            text_read_line += line.Length;

            // 終わりだったらreturn 
            if (line.IndexOf("end") == 0) return;

            // 行を一文字単位で
            char[] c = line.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                char character = c[i];
                bool is_command = false;
                string command = null;

                if (character == ' ') continue;
                if (character == '#')
                {
                    draw_name = getCommandAndName(line, ref i);
                    is_command = true;
                }

                if (character == '[')
                {
                    command = getCommandAndName(line, ref i);
                    is_command = true;
                }

                if (command == "p")
                    draw_talk += "\n";

                if (command == "n")
                    return;

                if (is_command == true)
                    continue;

                draw_talk += character;
            }
        }
    }

    void Start()
    {
        text_read_line = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loadTalk("testevent");
        }
    }
}
