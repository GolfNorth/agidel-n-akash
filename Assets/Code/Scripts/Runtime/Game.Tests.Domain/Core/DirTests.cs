using System.Collections.Generic;
using Game.Domain.Core;
using NUnit.Framework;

namespace Game.Tests.Domain.Core
{
    public sealed class DirTests
    {
        [Test]
        public void Opposite_Maps_Correctly()
        {
            Assert.AreEqual(Dir.S, Dir.N.Opposite());
            Assert.AreEqual(Dir.N, Dir.S.Opposite());
            Assert.AreEqual(Dir.W,  Dir.E.Opposite());
            Assert.AreEqual(Dir.E,  Dir.W.Opposite());
        }

        [Test]
        public void RotateCW_Cycles_N_E_S_W()
        {
            Assert.AreEqual(Dir.E,  Dir.N.RotCW());
            Assert.AreEqual(Dir.S, Dir.E.RotCW());
            Assert.AreEqual(Dir.W,  Dir.S.RotCW());
            Assert.AreEqual(Dir.N, Dir.W.RotCW()); // wrap-around
        }

        [Test]
        public void RotateCCW_Cycles_N_W_S_E()
        {
            Assert.AreEqual(Dir.W,  Dir.N.RotCCW());
            Assert.AreEqual(Dir.S, Dir.W.RotCCW());
            Assert.AreEqual(Dir.E,  Dir.S.RotCCW());
            Assert.AreEqual(Dir.N, Dir.E.RotCCW()); // wrap-around
        }

        [Test]
        public void D4_Contains_All_Four_Directions_Uniquely()
        {
            // Предполагаем, что DirX.D4 — массив из 4 дельт (N,E,S,W) без дублей.
            var seen = new HashSet<(int x, int y)>();
            foreach (var d in CoordX.D4)
            {
                seen.Add((d.X, d.Y));
            }
            Assert.AreEqual(4, seen.Count);
            Assert.IsTrue(seen.Contains((0, -1))); // N
            Assert.IsTrue(seen.Contains((1,  0))); // E
            Assert.IsTrue(seen.Contains((0,  1))); // S
            Assert.IsTrue(seen.Contains((-1, 0))); // W
        }
    }
}