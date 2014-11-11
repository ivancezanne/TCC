using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace InterfaceReferenciamento
{
    class Camera
    {
        private double[,] matrizProjecao;
        private Point[, ,] refAproximacao;
        private Boolean calibrada;

        public Camera() {
            this.matrizProjecao = new double[3, 4];
            this.refAproximacao = new Point[2,2,2];
            this.calibrada = false;
        }

        public void calibrar(Point[,,] referencia) { 
            Matriz M = new Matriz();

            double[,] autovetor = new double[12, 12];

            double[] autovalor = new double[12];

            int i = 0;

            //preenche a matriz M com as contas
            for (int x = 0; x < 2; x++ ) {
                for (int y = 0; y < 2; y++ ) {
                    for (int z = 0; z < 2; z++ ) {
                        M.alteraCelula(i, 0, x);
                        M.alteraCelula(i, 1, y);
                        M.alteraCelula(i, 2, z);
                        M.alteraCelula(i, 3, 1);
                        M.alteraCelula(i, 4, 0);
                        M.alteraCelula(i, 5, 0);
                        M.alteraCelula(i, 6, 0);
                        M.alteraCelula(i, 7, 0);
                        M.alteraCelula(i, 8, -1 * referencia[x, y, z].X * x);
                        M.alteraCelula(i, 9, -1 * referencia[x, y, z].X * y);
                        M.alteraCelula(i, 10, -1 * referencia[x, y, z].X * z);
                        M.alteraCelula(i, 11, -1 * referencia[x, y, z].X);

                        M.alteraCelula(i + 1, 0, 0);
                        M.alteraCelula(i + 1, 1, 0);
                        M.alteraCelula(i + 1, 2, 0);
                        M.alteraCelula(i + 1, 3, 0);
                        M.alteraCelula(i + 1, 4, x);
                        M.alteraCelula(i + 1, 5, y);
                        M.alteraCelula(i + 1, 6, z);
                        M.alteraCelula(i + 1, 7, 1);
                        M.alteraCelula(i + 1, 8, -1 * referencia[x, y, z].Y * x);
                        M.alteraCelula(i + 1, 9, -1 * referencia[x, y, z].Y * y);
                        M.alteraCelula(i + 1, 10, -1 * referencia[x, y, z].Y * z);
                        M.alteraCelula(i + 1, 11, -1 * referencia[x, y, z].Y);

                        i += 2;
                    }
                }
            }

            M.transposta();

            M.multiplica();

            Boolean convergiu = alglib.evd.smatrixevd(M.ADoubleTA, 12, 1, true, ref autovalor, ref autovetor);

            this.matrizProjecao = new double[3,4]{{autovetor[0, 0], autovetor[1, 0], autovetor[2, 0], autovetor[3, 0]},
                                                  {autovetor[4, 0], autovetor[5, 0], autovetor[6, 0], autovetor[7, 0]},
                                                  {autovetor[8, 0], autovetor[9, 0], autovetor[10, 0], autovetor[11, 0]}};
        
            this.calibrada = true;
        }

        public double[,] matriz(){
            return this.matrizProjecao;
        }

        public void calculaReferenciasAproximadas() {
            double[] v;
            double[] c = new double[4];

            for (int x = 0; x < 2; x++) {
                for (int y = 0; y < 2; y++) {
                    for (int z = 0; z < 2; z++) {
                        v = new double[4] { x, y, z, 1 };

                        c[0] = c[1] = c[2] = 0;

                        Matriz.multiplica(this.matrizProjecao, v, c, 3, 4);

                        this.refAproximacao[x, y, z].X = Convert.ToInt32(c[0] / c[2]);
                        this.refAproximacao[x, y, z].Y = Convert.ToInt32(c[1] / c[2]); 
                    }
                }
            }
        }

        public Point[, ,] referenciasAproximadas() {
            return this.refAproximacao;
        }

        public Boolean estaCalibrada(){
            return this.calibrada;
        }
    }
}
