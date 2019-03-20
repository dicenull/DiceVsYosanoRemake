using System;
using DxLogic;
using Graphics;
using System.Linq;

namespace DiceVsYosanoRemake.Scenes
{
    class Game : SceneBase<MyData>
    {
        private DicePlayer[] players = new DicePlayer[2];

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

                    if (Input.Key.IsPressed(moveKey))
                    {
                        players[i].Move((Direction)k);
                    }
                }
            }

            return this;
        }

        public override void Draw()
        {
            foreach(var player in players)
            {
                player.Draw();
            }
        }
    }
}
