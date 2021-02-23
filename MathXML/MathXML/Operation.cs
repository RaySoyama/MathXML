namespace MathXML
{
    class Operation
    {
        //If this system gets used often, the operation logic can be converted into a Strategy Pattern

        /// <summary>
        /// enums of handled math operations
        /// </summary>
        public enum OperationTypes
        {
            Invalid = -1,
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Divide = 3
        }

        static OperationStrategyInvalid operationStrategyInvalid = new OperationStrategyInvalid();
        static OperationStrategyAdd operationStrategyAdd = new OperationStrategyAdd();
        static OperationStrategySubtract operationStrategySubtract = new OperationStrategySubtract();
        static OperationStrategyMultiply operationStrategyMultiply = new OperationStrategyMultiply();
        static OperationStrategyDivide operationStrategyDivide = new OperationStrategyDivide();

        public OperationTypes operationType { get; private set; }
        public IOperationStrategy operationStrategyType { get; private set; }

        public string operationXmlName { get; private set; }

        public string username { get; private set; }
        public string operationName { get; private set; }
        public string miscellaneousInfo { get; private set; }

        public float value1 { get; private set; }
        public float value2 { get; private set; }


        public Operation(string _operationType, string _username, string _operationName, string _miscellaneousInfo, float _Value1, float _Value2)
        {
            operationXmlName = _operationType;

            switch (_operationType)
            {
                case "Add":
                    operationType = OperationTypes.Add;
                    operationStrategyType = operationStrategyAdd;
                    break;
                case "Subtract":
                    operationType = OperationTypes.Subtract;
                    operationStrategyType = operationStrategySubtract;
                    break;
                case "Multiply":
                    operationType = OperationTypes.Multiply;
                    operationStrategyType = operationStrategyMultiply;
                    break;
                case "Divide":
                    operationType = OperationTypes.Divide;
                    operationStrategyType = operationStrategyDivide;
                    break;
                default:
                    operationType = OperationTypes.Invalid;
                    operationStrategyType = operationStrategyInvalid;
                    System.Console.WriteLine($"{operationXmlName} is not a valid operation type");
                    break;
            }



            username = _username;
            operationName = _operationName;
            miscellaneousInfo = _miscellaneousInfo;
            value1 = _Value1;
            value2 = _Value2;
        }

        /// <summary>
        /// Returns a result of applying the operation to Value1 and Value2. If the operation is not supported, it will return 0.0f and print an error to the console
        /// </summary>
        /// <returns></returns>
        public float Calculate()
        {
            //float result = 0.0f;

            return operationStrategyType.Calculate(value1, value2);

            //switch (operationType)
            //{
            //    case OperationTypes.Invalid:
            //        System.Console.WriteLine($"{operationXmlName} is not a valid operation type");
            //        result = 0.0f;
            //        break;
            //    case OperationTypes.Add:
            //        result = Add();
            //        break;
            //    case OperationTypes.Subtract:
            //        result = Subtract();
            //        break;
            //    case OperationTypes.Multiply:
            //        result = Multiply();
            //        break;
            //    case OperationTypes.Divide:
            //        result = Divide();
            //        break;
            //}

            //return result;
        }

        /// <summary>
        /// Returns the corresponding character to the operationType. If the operation is not supported, it will return "N/A" and print an error to the console
        /// </summary>
        /// <returns></returns>
        public string OperationSymbol()
        {
            return operationStrategyType.OperationSymbol();

            //string symbol = "";

            //switch (operationType)
            //{
            //    case OperationTypes.Invalid:
            //        System.Console.WriteLine($"{operationXmlName} is not a valid operation type");
            //        symbol = "N/A";
            //        break;
            //    case OperationTypes.Add:
            //        symbol = "+";
            //        break;
            //    case OperationTypes.Subtract:
            //        symbol = "-";
            //        break;
            //    case OperationTypes.Multiply:
            //        symbol = "*";
            //        break;
            //    case OperationTypes.Divide:
            //        symbol = "/";
            //        break;
            //}
            //return symbol;
        }

        /// <summary>
        /// Returns a formated string of the operation
        /// </summary>
        /// <returns></returns>
        public string CreateOutput()
        {
            if (operationType == OperationTypes.Invalid)
            {
                return $"{operationXmlName} is not a valid operation type";
            }

            return $"{username} - {operationName} - {value1}{OperationSymbol()}{value2} = {Calculate()}";
        }

        //private float Add()
        //{
        //    return value1 + value2;
        //}

        //private float Subtract()
        //{
        //    return value1 - value2;
        //}

        //private float Multiply()
        //{
        //    return value1 * value2;
        //}

        //private float Divide()
        //{
        //    return value1 / value2;
        //}
    }
}
