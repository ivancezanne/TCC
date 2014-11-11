using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceReferenciamento
{
    class Referencia
    {
        private Point[,,] cubo;

        public Referencia() {
            Point temp = new Point(-1, -1);
            cubo = new Point[2, 2, 2]{{{temp, temp}, {temp, temp}},
                                      {{temp, temp}, {temp, temp}}};
        }

        public Point[,,] pontos() {
            return this.cubo;
        }

        public int quantosPontos() {
            int contador = 0;

            for (int i = 0; i < 2; i++ ) {
                for (int j = 0; j < 2; j++ ) {
                    for (int k = 0; k < 2; k++ ) { 
                        if(this.cubo[i, j, k].X != -1 && this.cubo[i, j, k].Y != -1){
                            contador++;
                        }
                    }
                }
            }

            return contador;
        }

        public void insereReferencia(int x, int y, int z, int u, int v) {
            this.cubo[x, y, z] = new Point(u, v);
        }

        public void removeReferencia(int x, int y, int z) {
            this.cubo[x, y, z] = new Point(-1, -1);
        }

        public void removeReferencia() {
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        this.cubo[i, j, k] = new Point(-1, -1);
                    }
                }
            }
        }

        public Boolean referenciado(int x, int y, int z) {
            if (this.cubo[x, y, z].X != -1 && this.cubo[x, y, z].Y != -1) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
