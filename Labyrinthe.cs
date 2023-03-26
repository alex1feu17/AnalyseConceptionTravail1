using System;
using System.Runtime.CompilerServices;

namespace TP1
{
    class Labyrinthe
    {
        private class Arete
        {
            public Noeud noeud1, noeud2;
            public int poids;

            public Arete(Noeud noeud1, Noeud noeud2, int poids)
            {
                this.noeud1 = noeud1;
                this.noeud2 = noeud2;
                this.poids = poids;
            }
        }

        private class Noeud
        {
            public int x, y;

            public Noeud(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private Noeud[] noeuds;
        private Arete[] aretes;
        private Arete[] result;

        public Labyrinthe(int x, int y)
        {
            noeuds = new Noeud[] {};
            aretes = new Arete[] {};

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    noeuds = noeuds.Append(new Noeud(i, j)).ToArray();

            Random random = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i + 1 < x) aretes = aretes.Append(new Arete(noeuds.First(n => n.x == i && n.y == j), noeuds.First(n => n.x == i + 1 && n.y == j), random.Next(1, 11))).ToArray();
                    if (j + 1 < y) aretes = aretes.Append(new Arete(noeuds.First(n => n.x == i && n.y == j), noeuds.First(n => n.x == i && n.y == j + 1), random.Next(1, 11))).ToArray();
                }
            }

            result = Prim(noeuds, aretes);
        }

        public void Regenerate()
        {
            Random random = new Random();
            foreach (Arete a in aretes) a.poids = random.Next(1, 11);

            result = Prim(noeuds, aretes);
        }

        private Arete[] Prim(Noeud[] N, Arete[] A)
        {
            Noeud[] B = new Noeud[] { N[0] };
            Arete[] S = new Arete[] {};
            while(N.Intersect(B).Count() != N.Count())
            {
                Arete a = A.Where(a => B.Contains(a.noeud1) && !B.Contains(a.noeud2) || B.Contains(a.noeud2) && !B.Contains(a.noeud1)).MinBy(a => a.poids);
                S = S.Append(a).ToArray();
                if (!B.Contains(a.noeud1)) B = B.Append(a.noeud1).ToArray();
                if (!B.Contains(a.noeud2)) B = B.Append(a.noeud2).ToArray();
            }

            return S;
        }

        private string GetSymbol(int i, int j, Arete[] aretes)
        {
            if (i == 0 && j == 0) return "E ";

            if (i % 2 == 0)
            {
                if (j % 2 == 0) return "  ";
                if (aretes.Any(a => a.noeud1.x == i / 2 && a.noeud1.y == j / 2 && a.noeud2.x == i / 2 && a.noeud2.y == (j + 1) / 2)) return "  ";
            }
            else if (j % 2 == 0 && aretes.Any(a => a.noeud1.x == i / 2 && a.noeud1.y == j / 2 && a.noeud2.x == (i + 1) / 2 && a.noeud2.y == j / 2)) return "  ";

            return "\u2588\u2588";
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < noeuds.Max(n => n.y + 1) * 2 + 1; i++) result += "\u2588\u2588";
            result += "\n";

            for (int i = 0; i < noeuds.Max(n => n.x + 1) * 2 - 1; i++)
            {
                result += "\u2588\u2588";
                for (int j = 0; j < noeuds.Max(n => n.y + 1) * 2 - 1; j++)
                {
                    if (i == noeuds.Max(n => n.x + 1) * 2 - 2 && j == noeuds.Max(n => n.y + 1) * 2 - 2) result += " S";
                    else result += GetSymbol(i, j, this.result);
                }
                result += "\u2588\u2588\n";
            }

            for (int i = 0; i < noeuds.Max(n => n.y + 1) * 2 + 1; i++) result += "\u2588\u2588";

            return result + '\n';
        }
    }
}
