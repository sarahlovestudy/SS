using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public abstract class Strategy
    {
       public abstract double CalculateTax(double income);
    }
    public class Tax1:Strategy
    {
        public override double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0;
        }
    }
    public class Tax2:Strategy
    { 
        public override double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }
    public class Operation
    {
        private Strategy strategy;
        public Operation(Strategy _strategy)
        {
            strategy = _strategy;
        }
        public double GetTex(double income)
        {
            return strategy.CalculateTax(income);
        }
    }
}
