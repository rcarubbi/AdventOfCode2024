
namespace AdventOfCode2024.Day7;

class Equation
{
    public long Target { get; }
    public int[] Numbers { get; }

    public Equation(long target, int[] numbers)
    {
        Target = target;
        Numbers = numbers;
    }

    public bool CanProduceTarget(IEnumerable<IOperator> operators)
    {
        return EvaluateOperators(operators, Numbers[0], 0);
    }

    private bool EvaluateOperators(IEnumerable<IOperator> operators, long currentValue, int index)
    {
        if (index == Numbers.Length - 1)
        {
            return currentValue == Target;
        }

        foreach (var op in operators)
        {
            if (EvaluateOperators(operators, op.Apply(currentValue, Numbers[index + 1]), index + 1))
            {
                return true;
            }
        }

        return false;
    }
}

