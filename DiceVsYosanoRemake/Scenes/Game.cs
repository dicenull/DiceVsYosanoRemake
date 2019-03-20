using System;
using DxLogic;
using Graphics;
using System.Linq;
using DxLibUtilities;
using Utilities;

namespace DiceVsYosanoRemake.Scenes
{
    class Game : SceneBase<MyData>
    {
        private DicePlayer[] players = new DicePlayer[2];
        private Rectangle gameField = new Rectangle(0, 70, Window.Size.X, Window.Size.Y - 70);

        public Game()
        {
            var damageDice = new Texture("Resource/DamageDice.png");
            var spawnData = new[]
            {
                new Rectangle(600, 400, 32, 32),
                new Rectangle(100, 100, 32, 32)
            };

            for (int i = 0; i < 2; i++)
            {
                var diceList = Texture.LoadDivision($"Resource/DiceList{i + 1}.png", 5, 1).ToList();
                diceList.Add(damageDice);

                players[i] = new DicePlayer(spawnData[i], diceList);
            }
        }

        public override SceneBase<MyData> Update()
        {
            var moveKeysList = new[]
            {
                new[] { ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow },
                new[] { ConsoleKey.W, ConsoleKey.D, ConsoleKey.S, ConsoleKey.A }
            };

            for(int i = 0;i < 2;i++)
            {
                for(int k = 0;k < moveKeysList[i].Length;k++)
                {
                    var moveKey = moveKeysList[i][k];
                    var moveDir = (Direction)k;
                    var area = players[i].Area;

                    if (Input.Key.IsPressed(moveKey))
                    {
                        // 動かした先がフィールド外の場合、動かさない
                        if (!gameField.Contains((Rectangle)area.MovedBy(moveDir.ToVector())))
                        {
                            continue;
                        }

                        players[i].Move((Direction)k);
                    }
                }
            }

            return this;
        }

        public override void Draw()
        {
            gameField.DrawFrame(Palette.White);

            foreach(var player in players)
            {
                player.Draw();
            }
        }
    }
}
