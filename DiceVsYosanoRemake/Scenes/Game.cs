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
        private BulletItem item;
        private Rectangle gameField = new Rectangle(0, 70, Window.Size.X, Window.Size.Y - 70);
        private Text gameText = new Text(18);

        public Game()
        {
            var damageDice = new Texture("Resource/DamageDice.png");
            var spawnData = new[]
            {
                new Rectangle(600, 400, 32, 32),
                new Rectangle(100, 100, 32, 32)
            };
            var colors = new[]
            {
                Palette.White,
                Palette.Green
            };

            for (int i = 0; i < 2; i++)
            {
                var diceList = Texture.LoadDivision($"Resource/DiceList{i + 1}.png", 5, 1).ToList();
                diceList.Add(damageDice);

                players[i] = new DicePlayer(spawnData[i], diceList, colors[i]);
            }

            item = new BulletItem(gameField);

            Data.MainMusic.Play(PlayType.Loop);
        }

        public override SceneBase<MyData> Update()
        {
            var moveKeysList = new[]
            {
                new[] { ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow },
                new[] { ConsoleKey.W, ConsoleKey.D, ConsoleKey.S, ConsoleKey.A }
            };
            var shotKeys = new[] { ConsoleKey.NumPad0, ConsoleKey.Spacebar };

            for(int i = 0;i < 2;i++)
            {
                // ゲームオーバーの判定
                if(players[i].Hp <= 0)
                {
                    int other = 1 - i;
                    Data.Winner = other;

                    Data.MainMusic.Stop();
                    return new Result();
                }

                // プレイヤーの移動
                for(int k = 0;k < moveKeysList[i].Length;k++)
                {
                    var moveKey = moveKeysList[i][k];
                    var moveDir = (Direction)k;
                    var area = players[i].Area;

                    if (Input.Key.IsPressed(moveKey))
                    {
                        // 動かした先がフィールド外の場合、動かさない
                        if (!gameField.Contains((Rectangle)area.MovedBy(players[i].MoveAmount(moveDir))))
                        {
                            continue;
                        }

                        players[i].Move((Direction)k);
                    }
                }

                if(Input.Key.IsPressed(shotKeys[i]))
                {
                    players[i].Shot();
                }

                // 弾の消去でエラーが起きないよう逆順でループ
                for (int k = players[i].Bullets.Count - 1; k >= 0; k--)
                {
                    var bullet = players[i].Bullets[k];

                    bullet.Move();

                    if (!gameField.Contains(bullet.Area))
                    {
                        players[i].Bullets.Remove(bullet);
                    }
                }

                // 相手の弾にあたっていたらダメージ
                int flip = 1 - i;
                foreach(var bullet in players[flip].Bullets)
                {
                    if(players[i].Area.Intersects(bullet.Area))
                    {
                        players[i].Hit(damage: 1);
                    }
                }

                // アイテムを取得したら弾を大きくする
                if(item.Enabled && players[i].Area.Intersects(item.Area))
                {
                    players[i].CollectItem();
                    item.Collect();
                }
            }

            item.Update();

            return this;
        }

        public override void Draw()
        {
            gameField.DrawFrame(Palette.White);

            var statusOrigin = new[]
            {
                new Vector2D(530, 10),
                new Vector2D(10, 10)
            };

            for (int i = 0; i < 2; i++)
            {
                var player = players[i];

                player.Draw();


                foreach(var bullet in player.Bullets)
                {
                    bullet.Draw();
                }

                gameText.Draw($"HP : {player.Hp}", statusOrigin[i], player.HpColor());
                gameText.Draw($"ShotSize: {player.ShotSize}", statusOrigin[i] + (0, 30), Palette.White);
            }

            item.Draw();
        }
    }
}
