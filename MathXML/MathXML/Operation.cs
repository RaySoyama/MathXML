namespace MathXML
{
    class Operation
    {
        public string operationType { get; private set; }
        public string username { get; private set; }
        public string operationName { get; private set; }
        public string miscellaneousInfo { get; private set; }

        public float value1 { get; private set; }
        public float value2 { get; private set; }

        public Operation(string _operationType, string _username, string _operationName, string _miscellaneousInfo, float _Value1, float _Value2)
        {
            operationType = _operationType;
            username = _username;
            operationName = _operationName;
            miscellaneousInfo = _miscellaneousInfo;
            value1 = _Value1;
            value2 = _Value2;
        }

        public float Calculate()
        {
            switch (operationType)
            {
                case "Add":
                    return Add();
                case "Subtract":
                    return Subtract();
                case "Multiply":
                    return Multiply();
                case "Divide":
                    return Divide();
                default:
                    System.Console.WriteLine($"{operationType} is not a valid operation type");
                    return 0;
            }
        }

        public string OperationSymbol()
        {
            switch (operationType)
            {
                case "Add":
                    return "+";
                case "Subtract":
                    return "-";
                case "Multiply":
                    return "*";
                case "Divide":
                    return "/";
                default:
                    System.Console.WriteLine($"{operationType} is not a valid operation type");
                    return "N/A";
            }
        }

        private float Add()
        {
            return value1 + value2;
        }

        private float Subtract()
        {
            return value1 - value2;
        }

        private float Multiply()
        {
            return value1 * value2;
        }

        private float Divide()
        {
            return value1 / value2;
        }
    }
}
