namespace MathXML
{
    class OperationStrategyInvalid : IOperationStrategy
    {
        public float Calculate(float value1, float value2)
        {
            return 0;
        }

        public string OperationSymbol()
        {
            return "N/A";
        }
    }
}
