﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MinimosQuadrados
{
    class Regiao
    {
        public Point[] pontos;
        public int npontos;
        public List<Point> interesse;

        public Regiao(int largura, int altura){
            this.pontos = new Point[2]{ new Point(0, 0), new Point(largura, altura)};
            this.npontos = 0;
            this.interesse = new List<Point>();
        }


        public double descobreM() {

            int N = interesse.Count();
            double somaX = 0, somaY = 0, somaXY = 0, somaX2 = 0;

            for (int i = 0; i < N; i++ ) {
                somaX += interesse[i].X;
                somaY += interesse[i].Y;

                somaXY += interesse[i].X * interesse[i].Y;

                somaX2 += interesse[i].X * interesse[i].X;
            }

            return (N * somaXY - somaX * somaY) / (N * somaX2 - somaX * somaX);
        }

        public double descobreB()
        {
            int N = interesse.Count();
            double somaX = 0, somaY = 0, somaXY = 0, somaX2 = 0;

            for (int i = 0; i < N; i++)
            {
                somaX += interesse[i].X;
                somaY += interesse[i].Y;

                somaXY += interesse[i].X * interesse[i].Y;

                somaX2 += interesse[i].X * interesse[i].X;
            }

            return (somaX2 * somaY - somaXY * somaX) / (N * somaX2 - somaX * somaX);
        }
    }
}
