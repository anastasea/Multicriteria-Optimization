using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticriteriaOptimization
{
    enum MathSign { GreaterThan, LessThan, Equal }

    class MultiCriteriaProblem
    {
        public bool[] Maximize { get; set; }
        public double[,] CriteriaCoefficients { get; set; }
        public double[,] ConstraintCoefficients { get; set; }
        public double[] Constants { get; set; }
        public MathSign[] ConstraintSigns { get; set; }
        // По умолчанию предполагается, что на остальные переменные наложено условие неотрицательности
        public int[] NotNonNegativeVarInd { get; set; }

        public int CountConstraint { get; set; }
        public int CountVariables { get; set; }

        public MultiCriteriaProblem(bool[] maximize, double[,] criteriaCoefficients, double[,] constraintCoefficients, double[] constants, MathSign[] constraintSigns, int[] notNonNegativeVariables)
        {
            Maximize = maximize;
            ConstraintCoefficients = constraintCoefficients;
            CriteriaCoefficients = criteriaCoefficients;
            CountConstraint = ConstraintCoefficients.GetLength(0);
            CountVariables = ConstraintCoefficients.GetLength(1);
            Constants = constants;
            ConstraintSigns = constraintSigns;
            NotNonNegativeVarInd = notNonNegativeVariables;
        }
    }
}
