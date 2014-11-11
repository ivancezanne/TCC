using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceReferenciamento
{
    class Matriz
    {

        public alglib.complex[,] AComplex;
        public alglib.complex[,] AComplexT;
        public alglib.complex[,] AComplexTA;

        public double[,] ADouble;
        public double[,] ADoubleT;
        public double[,] ADoubleTA;

        public Matriz() { 
            AComplex = new alglib.complex[16, 12];
            ADouble = new double[16, 12];
            AComplexT = new alglib.complex[12, 16];
            ADoubleT = new double[12, 16];
            AComplexTA = new alglib.complex[12, 12];
            ADoubleTA = new double[12, 12];
        }

        public void alteraCelula(int i, int j, double valor) {
            this.AComplex[i, j] = valor;
            this.ADouble[i, j] = valor;
        }

        public void transposta()
        {
            int i, j;

            for (i = 0; i < 16; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    this.AComplexT[j, i] = this.AComplex[i, j];
                    this.ADoubleT[j, i] = this.ADouble[i, j];
                }
            }
        }

        public void multiplica()
        {
            int i, j, k;

            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    for (k = 0; k < 16; k++)
                    {
                        this.ADoubleTA[i, j] += this.ADoubleT[i, k] * this.ADouble[k, j];
                        this.AComplexTA[i, j] += this.AComplexT[i, k] * this.AComplex[k, j];
                    }
                }
            }
        }

        public static void multiplica(double[,] m, double[] v, double[] c, int lin, int col)
        {
            int i, j;

            for (i = 0; i < lin; i++)
            {
                for (j = 0; j < col; j++)
                {
                    c[i] += m[i, j] * v[j];
                }
            }
        }

        public static double determinante(double[,] matriz, int dimensao)
        {
            int i, 
                j, 
                k;
        
            int novaDimensao = 2 * dimensao - 1;
        
            double[,] matrizAumentada = new double[dimensao, novaDimensao];
        
            double diagonalPrincipal = 0,
                   diagonalSecundaria = 0,
                   auxiliar;
        
            //faz a matriz aumentada
            if(dimensao > 2){
                for(i = 0; i < dimensao; i++){
                    for(j = 0; j < novaDimensao; j++){
                        if(j >= dimensao){
                            matrizAumentada[i, j] = matriz[i, j - dimensao];
                            }
                            else{
                                matrizAumentada[i, j] = matriz[i, j];
                                }
                        }
                    }
                }
                else{
                    for(i = 0; i < dimensao; i++){
                        for(j = 0; j < novaDimensao; j++){
                            if(j >= dimensao){
                                matrizAumentada[i, j] = 0;
                                }
                                else{
                                    matrizAumentada[i, j] = matriz[i, j];
                                    }
                            }
                        }
                    }
        
            //calcula a diagonal principal
            for(i = 0; i < dimensao; i++){
                auxiliar = 1;
                for(j = 0, k = i; j < dimensao; j++, k++){
                    auxiliar *= matrizAumentada[j, k];
                    }
                diagonalPrincipal += auxiliar;
                }
        
            //calcula a diagonal secundaria
            for(i = novaDimensao - 1; i >=0; i--){
                auxiliar = 1;
                for(j = 0, k = i; j < dimensao; j++, k--){
                    auxiliar *= matrizAumentada[j, k];
                    }
                diagonalSecundaria += auxiliar;
                }
    
            return diagonalPrincipal - diagonalSecundaria;
    }

        public static void eliminacaoGauss(double[,] matriz, double[] vetor, double[] solucao, int dimensao)
        {
            int i, j, k;
            double[,] matriz2 = new double[dimensao, dimensao];
            double[] vetor2 = new double[dimensao];
            double[] multiplicador = new double[dimensao];
            double som;
    
            for(i = 0; i < dimensao; i++){
                vetor2[i] = vetor[i];
                for(j = 0; j < dimensao; j++){
                    matriz2[i, j] = matriz[i, j];
                    }
                }
    
            for(j = 0; j < dimensao - 1; j++){
                for(i = j + 1; i < dimensao; i++){
                    multiplicador[i] = matriz2[i, j] / matriz2[j, j];
                    }
                for(i = j + 1; i < dimensao; i++){
                    for(k = 0; k < dimensao; k++){
                        matriz2[i, k] -= multiplicador[i] * matriz2[j, k];
                        }
                    vetor2[i] -= multiplicador[i] * vetor2[j];
                    }
                }
        
            for(i = dimensao - 1; i >= 0; i--){
                som = 0;
                for(k = dimensao - 1; k > i; k--){
                    som += solucao[k] * matriz2[i, k];
                    }
                solucao[i] = (vetor2[i] - som)/matriz2[i, i];
                }
            }

      }
}
