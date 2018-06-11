﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticriteriaOptimization
{
    public enum MathSign { GreaterThan, LessThan, Equal }

    public class MultiCriteriaProblem
    {
        public bool[] Minimize { get; set; }
        public double[,] CriteriaCoefficients { get; set; }
        public double[,] ConstraintCoefficients { get; set; }
        public double[] Constants { get; set; }
        public MathSign[] ConstraintSigns { get; set; }
        public int[] NotNonNegativeVarInd { get; set; }

        public int CountCriteria { get; set; }
        public int CountConstraint { get; set; }
        public int CountVariables { get; set; }

        public MultiCriteriaProblem(bool[] minimize, double[,] criteriaCoefficients, double[,] constraintCoefficients, double[] constants, MathSign[] constraintSigns, int[] notNonNegativeVariables)
        {
            Minimize = minimize;
            ConstraintCoefficients = constraintCoefficients;
            CriteriaCoefficients = criteriaCoefficients;
            CountCriteria = criteriaCoefficients.GetLength(0);
            CountConstraint = ConstraintCoefficients.GetLength(0);
            CountVariables = ConstraintCoefficients.GetLength(1);            
            Constants = constants;
            ConstraintSigns = constraintSigns;
            NotNonNegativeVarInd = notNonNegativeVariables;
        }
    }
}
