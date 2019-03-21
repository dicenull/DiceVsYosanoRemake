using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphics;

namespace DiceVsYosanoRemake
{
    public abstract class CharacterBase<T> where T : IDiagram
    {
        public int Speed { get; set; } = 3;

        public int Hp { get; protected set; }

        public T Area { get; protected set; }

        public abstract void Draw();
    }
}
