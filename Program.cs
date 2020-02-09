using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Program
    {
        static char[] map =
        {
            '#','#','#','#','#',
            '#',' ',' ',' ','#',
            '#',' ','#',' ','#',
            '#','P','#','G','#',
            '#','#','#','#','#',
        };

        static void DrawMap()
        {
            for (int i = 0; i < map.Length; i++)
            {
                Console.Write(map[i]);
                if ((i + 1) % 5 == 0)
                {
                    Console.Write(System.Environment.NewLine);
                }
            }
        }

        // プレイヤの移動メソッド
        static void MovePlayer(string key)
        {
            // プレイヤの現在位置を取得する
            int playerPos = Array.IndexOf(map, 'P');

            // キーの入力に応じて、プレイヤを動かす
            int playerNextPos = 0;
            if (key == "a")     // プレイヤを左に移動
            {
                playerNextPos = playerPos - 1;
            }
            else if (key == "d")     // プレイヤを右に移動
            {
                playerNextPos = playerPos + 1;
            }
            else if (key == "w")     // プレイヤを上に移動
            {
                playerNextPos = playerPos - 5;
            }
            else if (key == "s")     // プレイヤを下に移動
            {
                playerNextPos = playerPos + 5;
            }
            else //ASDW以外のキーが押された場合は、プレイヤの位置を更新しない
            {
                return;
            }

            // プレイヤの現在の位置を更新
            if (map[playerNextPos] != '#')
            {
                map[playerNextPos] = 'P';
                map[playerPos] = ' ';
                playerPos = playerNextPos;
            }
        }

        // ゴール判定のメソッド
        static bool CheckGoal()
        {
            // map中に'G'の文字がない場合はtrue、
            // 'G'の文字がある場合にはfalseを返す
            if (Array.IndexOf(map, 'G') < 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            // 初期状態のMAPを表示
            DrawMap();

            // キー入力を受け取る
            while (true)
            {
                string key = Console.ReadLine();
                MovePlayer(key);
                // ゴールしたらwhile分を抜けてゲームクリア
                if (CheckGoal())
                {
                    Console.WriteLine("GOAL!");
                    break;
                }
                DrawMap();
            }
            Console.WriteLine("ゲームクリア！");
        }
    }
}
