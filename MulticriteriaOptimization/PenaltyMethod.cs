using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace MulticriteriaOptimization
{
    public class PenaltyMethod
    {
        public MultiCriteriaProblem Prob { get; set; }
        double[] optF;
        double alphaK;
        double stepPenalty;
        double[,] GradCoefficients;
        double epsilon;
        double epsilonGrad;
        List<double[]> gradDescentIterations;
        public List<double[]> PenaltyIterations { get; set; }

        public PenaltyMethod(MultiCriteriaProblem prob, double[] optF, double epsilon, double epsilonGrad, double alphaK, double step)
        {
            this.Prob = prob;
            this.optF = optF;
            this.epsilon = epsilon;
            this.epsilonGrad = epsilonGrad;
            this.alphaK = alphaK;
            this.stepPenalty = step;
            PenaltyIterations = new List<double[]>();
            gradDescentIterations = new List<double[]>();
            GradCoefficients = new double[prob.CriteriaCoefficients.GetLength(0), prob.CriteriaCoefficients.GetLength(1)];
        }

        public double[] Calculate()
        {
            double[] xk = new double[Prob.CountVariables];
            for (int i = 0; i < xk.Length; i++)
            {
                xk[i] = -1;
            }
            double[] prev = new double[xk.Length];
            double norm; double penalty;
            do
            {
                Array.Copy(xk, prev, xk.Length);
                xk = DeepGradientDescent(xk);
                if (xk[0] == Double.NaN) break;
                PenaltyIterations.Add(xk);
                penalty = GetPenaltyValue(xk);
                alphaK += stepPenalty;
                norm = VectorNorm(SubstractVectors(prev, xk));
            }
            while (norm > epsilon);
            return xk;
        }

        public double[] DeepGradientDescent(double[] x0)
        {
            gradDescentIterations.Clear();
            double[] xk = new double[x0.Length];
            Array.Copy(x0, xk, x0.Length);
            double func = GetFunctionValue(xk) + GetPenaltyValue(xk); 
            for (int k = 0; ; k++)
            {
                gradDescentIterations.Add(xk);
                double[] prev = new double[x0.Length];
                Array.Copy(xk, prev, xk.Length);
                double[] sk = GetDerivativeInXk(xk);
                double step = BisectionMethod(-100, 100, xk, sk);
                //double step = 0.001;
                for (int i = 0; i < xk.Length; i++)
                {
                    xk[i] = xk[i] - step * sk[i];
                }
                func = GetFunctionValue(xk) + GetPenaltyValue(xk);
                double norm = VectorNorm(SubstractVectors(prev, xk));
                if (norm < epsilonGrad || k > 500000)
                {
                    break;
                }
                //if (step > 90)  break;
            }
            return xk;
        }

        public double[] NewtonMethod(double[] x0)
        {
            double[] xk = new double[x0.Length];
            Array.Copy(x0, xk, x0.Length);
            double func = GetFunctionValue(xk) + GetPenaltyValue(xk);
            for (int k = 0; ; k++)
            {
                gradDescentIterations.Add(xk);
                double[] prev = new double[x0.Length];
                Array.Copy(xk, prev, xk.Length);
                double[] sk = GetDerivativeInXk(xk);
                double[,] hess = GetHessianMatrix(xk);
                var  M = Matrix<double>.Build;
                var V = Vector<double>.Build;
                Vector<double> grad = V.DenseOfArray(sk);
                double[,] inverse = M.DenseOfArray(hess).Inverse().ToArray();
                double[] inverseHessMultiGrad = M.DenseOfArray(hess).Inverse().LeftMultiply(grad).ToArray();
                double step = BisectionMethodForNewton(-1000, 1000, xk, inverseHessMultiGrad);
                for (int i = 0; i < xk.Length; i++)
                {
                    xk[i] = xk[i] - step * inverseHessMultiGrad[i];
                }
                func = GetFunctionValue(xk) + GetPenaltyValue(xk); 
                double norm = VectorNorm(SubstractVectors(prev, xk));
                if (norm <= 0.1)
                {
                    break;
                }
                if (xk[0] == Double.NaN) break;
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

        public double BisectionMethod(double a0, double b0, double[] xk, double[] grad)
        {
            double lk, mk;
            double epsilon = 0.000000000001; 
            double delta = 0.5 * epsilon;
            double ak = a0, bk = b0;

            double[] x1 = new double[xk.Length];
            double[] x2 = new double[xk.Length];
            do
            {
                lk = (ak + bk - delta) / 2;
                mk = (ak + bk + delta) / 2;
                for (int i = 0; i < x1.Length; i++)
                {
                    x1[i] = xk[i] - lk * grad[i];
                    x2[i] = xk[i] - mk * grad[i];
                }
                if (GetFunctionValue(x1) + GetPenaltyValue(x1)  <= GetFunctionValue(x2) + GetPenaltyValue(x2))
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

        public double BisectionMethodForNewton(double a0, double b0, double[] xk, double[] inverseHessMultiGrad)
        {
            double lk, mk;
            double epsilon = 0.0001;
            double delta = 0.5 * epsilon;
            double ak = a0, bk = b0;

            double[] x1 = new double[xk.Length];
            double[] x2 = new double[xk.Length];
            do
            {
                lk = (ak + bk - delta) / 2;
                mk = (ak + bk + delta) / 2;
                for (int i = 0; i < x1.Length; i++)
                {
                    x1[i] = xk[i] - lk * inverseHessMultiGrad[i];
                    x2[i] = xk[i] - mk * inverseHessMultiGrad[i];
                }
                if (GetFunctionValue(x1) + GetPenaltyValue(x1) <= GetFunctionValue(x2) + GetPenaltyValue(x2))
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
            for (int i = 0; i < Prob.CriteriaCoefficients.GetLength(0); i++)
            {
                temp = 0;
                for (int j = 0; j < Prob.CriteriaCoefficients.GetLength(1); j++)
                {
                    temp += Prob.CriteriaCoefficients[i, j] * x[j];
                }
                temp -= optF[i];
                temp *= temp;
                sum += temp;
            }
            //sum += GetPenaltyValue(x);
            return sum;
        }
        
        public double[] GetDerivativeInXk(double[] x)
        {
            double[] sk = new double[x.Length];
            double[] sum = new double[Prob.CriteriaCoefficients.GetLength(0)];
            for (int i = 0; i < Prob.CriteriaCoefficients.GetLength(0); i++)
            {
                for (int j = 0; j < Prob.CriteriaCoefficients.GetLength(1); j++)
                {
                    sum[i] += Prob.CriteriaCoefficients[i,j] * x[j];
                }
                sum[i] -= optF[i];
                sum[i] *= 2;
            }
            for (int i = 0; i < sk.Length; i++)
            {
                for (int j = 0; j < Prob.CriteriaCoefficients.GetLength(0); j++)
                {
                    sk[i] += sum[j] * Prob.CriteriaCoefficients[j, i];
                }
            }
            double[] sum2 = new double[Prob.ConstraintCoefficients.GetLength(0)];
            for (int i = 0; i < Prob.ConstraintCoefficients.GetLength(0); i++)
            {
                for (int j = 0; j < Prob.ConstraintCoefficients.GetLength(1); j++)
                {
                    sum2[i] += Prob.ConstraintCoefficients[i, j] * x[j];
                }
                sum2[i] -= Prob.Constants[i];
            }
            for (int i = 0; i < sk.Length; i++)
            {
                for (int j = 0; j < Prob.ConstraintCoefficients.GetLength(0); j++)
                {
                    if ((Prob.ConstraintSigns[j] == MathSign.LessThan) && (sum2[j] > 0) ||
                    (Prob.ConstraintSigns[j] == MathSign.GreaterThan) && (sum2[j] < 0) ||
                    Prob.ConstraintSigns[j] == MathSign.Equal)
                    {
                        sk[i] += 2 * alphaK * Math.Abs(sum2[j] * Prob.ConstraintCoefficients[j, i]);
                    }
                }
            }
            for (int i = 0; i < Prob.CountVariables; i++)
            {
                if (!ContainsValue(Prob.NotNonNegativeVarInd, i) && x[i] < 0)
                {
                    sk[i] += 2 * alphaK * Math.Abs(x[i]);
                }
            }
            return sk;
        }

        public double GetPenaltyValue(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < Prob.ConstraintCoefficients.GetLength(0); i++)
            {
                double temp = 0;
                for (int j = 0; j < Prob.ConstraintCoefficients.GetLength(1); j++)
                {
                    temp += Prob.ConstraintCoefficients[i, j] * x[j];
                }
                temp -= Prob.Constants[i];

                if ((Prob.ConstraintSigns[i] == MathSign.LessThan) && (temp > 0) ||
                    (Prob.ConstraintSigns[i] == MathSign.GreaterThan) && (temp < 0) ||
                    Prob.ConstraintSigns[i] == MathSign.Equal)
                {
                    sum += temp * temp * alphaK;
                }
            }
            for(int i = 0; i < Prob.CountVariables; i++)
            {
                if(!ContainsValue(Prob.NotNonNegativeVarInd,i) && x[i] < 0)
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
                for (int i = 0; i < Prob.NotNonNegativeVarInd.Length; i++)
                {
                    if (Prob.NotNonNegativeVarInd[i] == val)
                    {
                        contains = true;
                        break;
                    }
                }
            }
            return contains;
        }

        private double[,] GetHessianMatrix(double[] x)
        {
            double[,] res = new double[Prob.CountVariables, Prob.CountVariables];
            for(int k = 0; k < Prob.CountVariables; k++)
            {
                for(int m = 0; m < Prob.CountVariables; m++ )
                {
                    for (int i = 0; i < Prob.CriteriaCoefficients.GetLength(0); i++)
                    {
                        res[k, m] += 2 * Prob.CriteriaCoefficients[i, k] * Prob.CriteriaCoefficients[i, m];
                    }
                }
            }
            double[] sum2 = new double[Prob.ConstraintCoefficients.GetLength(0)];
            for (int i = 0; i < Prob.ConstraintCoefficients.GetLength(0); i++)
            {
                for (int j = 0; j < Prob.ConstraintCoefficients.GetLength(1); j++)
                {
                    sum2[i] += Prob.ConstraintCoefficients[i, j] * x[j];
                }
                sum2[i] -= Prob.Constants[i];
                if (Prob.ConstraintSigns[i] == MathSign.GreaterThan)
                {
                    sum2[i] *= -1;
                }
            }
            for (int k = 0; k < Prob.CountVariables; k++)
            {
                for (int m = 0; m < Prob.CountVariables; m++)
                {
                    for (int j = 0; j < Prob.ConstraintCoefficients.GetLength(0); j++)
                    {
                        if ((Prob.ConstraintSigns[j] == MathSign.LessThan) && (sum2[j] > 0) ||
                            (Prob.ConstraintSigns[j] == MathSign.GreaterThan) && (sum2[j] > 0) ||
                        Prob.ConstraintSigns[j] == MathSign.Equal)
                        {
                            res[k, m] += 2 * alphaK * Prob.ConstraintCoefficients[j, k] * Prob.ConstraintCoefficients[j, m];
                        }
                    }
                }
            }
            return res;
        }

        public double CountDifferenceForConstraints(double[] x, int constrInd)
        {
            double sum = 0;
            double temp = 0;
            for (int j = 0; j < Prob.ConstraintCoefficients.GetLength(1); j++)
            {
                temp += Prob.ConstraintCoefficients[constrInd, j] * x[j];
            }
            temp -= Prob.Constants[constrInd];

            if ((Prob.ConstraintSigns[constrInd] == MathSign.LessThan) && (temp > 0) ||
                (Prob.ConstraintSigns[constrInd] == MathSign.GreaterThan) && (temp < 0) ||
                Prob.ConstraintSigns[constrInd] == MathSign.Equal)
            {
                sum += Math.Abs(temp);
            }
            return sum;
        }

        public double CountDifferenceForNonNegativityConstraints(double[] x, int constrInd)
        {
            double sum = 0;
            if (!ContainsValue(Prob.NotNonNegativeVarInd, constrInd) && x[constrInd] < 0)
            {
                sum += Math.Abs(x[constrInd]);
            }
            return sum;
        }

    }
}
