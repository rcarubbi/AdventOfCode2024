
namespace AdventOfCode2024.Day7;

class CalibrationSystem
{
    private readonly List<Equation> _equations;
    private readonly IEnumerable<IOperator> _operators;

    public CalibrationSystem(List<Equation> equations, IEnumerable<IOperator> operators)
    {
        _equations = equations;
        _operators = operators;
    }

    public long CalculateTotalCalibrationResult()
    {
        long total = 0;

        foreach (var equation in _equations)
        {
            if (equation.CanProduceTarget(_operators))
            {
                total += equation.Target;
            }
        }

        return total;
    }
}

