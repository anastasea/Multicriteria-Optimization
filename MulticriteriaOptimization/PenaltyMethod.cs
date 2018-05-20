using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticriteriaOptimization
{
    class PenaltyMethod
    {
        MultiCriteriaProblem prob;
        double[] optF;
        double alphaK;
        double step;
        double[,] GradCoefficients;
        double epsilon;
        List<double[]> penaltyIterations;
        List<double[]> gradDescentIterations;
        List<double[]> xkDescentIterations;
        List<double> funcValueDescentIterations;

        public PenaltyMethod(MultiCriteriaProblem prob, double[] optF, double epsilon, double alphaK, double step)
        {
            this.prob = prob;
            this.optF = optF;
            this.epsilon = epsilon;
            this.alphaK = alphaK;
            this.step = step;
            penaltyIterations = new List<double[]>();
            gradDescentIterations = new List<double[]>();
            xkDescentIterations = new List<double[]>();
            funcValueDescentIterations = new List<double>();
            GradCoefficients = new double[prob.CriteriaCoefficients.GetLength(0), prob.CriteriaCoefficients.GetLength(1)];
        }

        public double[] Calculate()
        {
            double[] xk = new double[prob.CountVariables];
            double[] prev = new double[xk.Length];
            double norm;
            //double[] xk = new double[2] { -0.5, -1};
            int k = 1;
            do
            {
                Array.Copy(xk, prev, xk.Length);
                xk = DeepGradientDescent(xk);
                penaltyIterations.Add(xk);
                alphaK += step;
                norm = VectorNorm(SubstractVectors(prev, xk));
                k++;
            }
            while (norm > epsilon);
            return xk;
        }

        public double[] DeepGradientDescent(double[] x0)
        {
            double step;
            double[] xk = new double[x0.Length];
            Array.Copy(x0, xk, x0.Length);
            for (int k = 0; ; k++)
            {
                double[] prev = new double[x0.Length];
                Array.Copy(xk, prev, xk.Length);
                double[] sk = GetDerivativeInXk(xk);
                gradDescentIterations.Add(sk);
                step = BisectionMethod(-10000000, 10000000, xk);
                for (int i = 0; i < xk.Length; i++)
                {
                    xk[i] = xk[i] - step * sk[i];
                }
                double norm = VectorNorm(SubstractVectors(prev, xk));
                if (norm < 0.1)
                {
                    break;
                }
            }
            return xk;
        }

        public double VectorNorm(double[] x)
        {
            double res = 0;
            for(int i = 0; i < x.Length; i++)
            {
                res += x[i] * x[i];
            }
            return Math.Sqrt(res);
        }

        public double[] SubstractVectors(double[] prev, double[] next)
        {
            double[] res = new double[prev.Length];
            for (int i = 0; i < prev.Length; i++)
            {
                res[i] = next[i] - prev[i];
            }
            return res; 
        }

        public double BisectionMethod(double a0, double b0, double[] xk)
        {
            double lk, mk;
            double epsilon = 0.01; 
            double delta = 0.5 * epsilon;
            double ak = a0, bk = b0;

            double[] x1 = new double[xk.Length];
            double[] x2 = new double[xk.Length];
            double[] grad = GetDerivativeInXk(xk);
            do
            {
                lk = (ak + bk - delta) / 2;
                mk = (ak + bk + delta) / 2;
                for (int i = 0; i < x1.Length; i++)
                {
                    x1[i] = xk[i] - lk * grad[i];
                    x2[i] = xk[i] - mk * grad[i];
                }
                if (GetFunctionValue(x1) <= GetFunctionValue(x2))
                {
                    bk = mk;
                }
                else
                {
                    ak = lk;
                }
            } while ((bk - ak) >= epsilon);
            return (ak + bk) / 2; 
        }
                
        public double GetFunctionValue(double[] x)
        {
            double sum = 0;
            double temp = 0;
            for (int i = 0; i < prob.CriteriaCoefficients.GetLength(0); i++)
            {
                temp = 0;
                for (int j = 0; j < prob.CriteriaCoefficients.GetLength(1); j++)
                {
                    temp += prob.CriteriaCoefficients[i, j] * x[j];
                }
                temp -= optF[i];
                temp *= temp;
                sum += temp;
            }
            sum += GetPenaltyValue(x);
            return sum;
            //return x[0] * x[0] * x[0] + 2 * x[1] * x[1] - 3 * x[0] - 4 * x[1]; 
        }
        
        // Градиент функции sum((gi(x)-fi*)^2) + ak*P(x)
        public double[] GetDerivativeInXk(double[] x)
        {
            double[] sk = new double[x.Length];
            double[] sum = new double[prob.CriteriaCoefficients.GetLength(0)];
            for (int i = 0; i < prob.CriteriaCoefficients.GetLength(0); i++)
            {
                for (int j = 0; j < prob.CriteriaCoefficients.GetLength(1); j++)
                {
                    sum[i] += prob.CriteriaCoefficients[i,j] * x[j];
                }
                sum[i] -= optF[i];
                sum[i] *= 2;
            }
            for (int i = 0; i < sk.Length; i++)
            {
                for (int j = 0; j < prob.CriteriaCoefficients.GetLength(0); j++)
                {
                    sk[i] += sum[j] * prob.CriteriaCoefficients[j, i];
                }
            }
            double[] sum2 = new double[prob.ConstraintCoefficients.GetLength(0)];
            for (int i = 0; i < prob.ConstraintCoefficients.GetLength(0); i++)
            {
                for (int j = 0; j < prob.ConstraintCoefficients.GetLength(1); j++)
                {
                    sum2[i] += prob.ConstraintCoefficients[i, j] * x[j];
                }
                sum2[i] -= prob.Constants[i];
            }
            for (int i = 0; i < sk.Length; i++)
            {
                for (int j = 0; j < prob.ConstraintCoefficients.GetLength(0); j++)
                {
                    if ((prob.ConstraintSigns[j] == MathSign.LessThan) && (sum2[j] > 0) ||
                    (prob.ConstraintSigns[j] == MathSign.GreaterThan) && (sum2[j] < 0) ||
                    prob.ConstraintSigns[j] == MathSign.Equal)
                    {
                        sk[i] += sum2[j] * 2 * alphaK * prob.ConstraintCoefficients[j, i];
                    }
                }
            }
            for (int i = 0; i < prob.CountVariables; i++)
            {
                if (!ContainsValue(prob.NotNonNegativeVarInd, i) && x[i] < 0)
                {
                    sk[i] += 2 * alphaK * x[i];
                }
            }
            return sk;
            //double[] sk = new double[2];
            //sk[0] = 3 * x[0] * x[0] - 3;
            //sk[1] = 4 * x[1] - 4;
            //return sk;
        }

        public double GetPenaltyValue(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < prob.ConstraintCoefficients.GetLength(0); i++)
            {
                double temp = 0;
                for (int j = 0; j < prob.ConstraintCoefficients.GetLength(1); j++)
                {
                    temp += prob.ConstraintCoefficients[i, j] * x[j];
                }
                temp -= prob.Constants[i];

                if ((prob.ConstraintSigns[i] == MathSign.LessThan) && (temp > 0) ||
                    (prob.ConstraintSigns[i] == MathSign.GreaterThan) && (temp < 0) ||
                    prob.ConstraintSigns[i] == MathSign.Equal)
                {
                    sum += temp * temp * alphaK;
                }
            }
            for(int i = 0; i < prob.CountVariables; i++)
            {
                if(!ContainsValue(prob.NotNonNegativeVarInd,i) && x[i] < 0)
                {
                    sum += alphaK * x[i] * x[i];
                }
            }
            return sum;
        }

        private bool ContainsValue(int[] arr, int val)
        {
            bool contains = false;
            if (arr != null)
            {
                for (int i = 0; i < prob.NotNonNegativeVarInd.Length; i++)
                {
                    if (prob.NotNonNegativeVarInd[i] == val)
                    {
                        contains = true;
                        break;
                    }
                }
            }
            return contains;
        }

    }
}
