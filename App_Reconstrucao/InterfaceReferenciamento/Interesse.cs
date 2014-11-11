using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace InterfaceReferenciamento
{
    class Interesse
    {
        private List<Point> pontos;
        private List<int> planoPonto; 

        public Interesse(){
            this.pontos = new List<Point>();
            this.planoPonto = new List<int>();
        }

        public void insereInteresse(int u, int v, int plano){
            this.pontos.Add(new Point(u, v));
            this.planoPonto.Add(plano);
        }

        public void removeInteresse(){
            this.pontos.Clear();
            this.planoPonto.Clear();
        }

        public void removeInteresse(int indice){
            this.pontos.RemoveAt(indice);
            this.planoPonto.RemoveAt(indice);
        }

        public List<Point> interesses(){
            return this.pontos;
        }

        public List<int> interesses(Boolean flag){
            return this.planoPonto;
        }

        public int quantosPontos(){
            return this.pontos.Count;
        }
    }
}
