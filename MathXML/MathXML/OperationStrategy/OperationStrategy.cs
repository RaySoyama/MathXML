namespace MathXML
{
    interface IOperationStrategy
    {
        float Calculate(float value1, float value2);
        string OperationSymbol();
    }
}
