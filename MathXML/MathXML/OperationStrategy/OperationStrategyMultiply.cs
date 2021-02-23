namespace MathXML
{
    class OperationStrategyMultiply : IOperationStrategy
    {
        public float Calculate(float value1, float value2)
        {
            return value1 * value2;
        }

        public string OperationSymbol()
        {
            return "*";
        }
    }
}
