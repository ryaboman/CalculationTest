using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculation.bll {
    public class Expression {
        private Stack<float> stackOfNumbers = new Stack<float>();
        private Stack<char> stackOfOperator = new Stack<char>();
        private string expression = string.Empty;

        public Expression(string expression) {
            this.expression = expression;
        }

        public float Calculation() {           
            string numberOfExpression = string.Empty;
            string functionOfExpression = string.Empty;
            bool flagOfNegativeNumber = false;
            float result = 0;

            for (var index = 0; index < expression.Length; index++) {
                char symbol = expression[index];

                if (symbol == '.') {
                    symbol = ',';
                }

                //Обработка числа
                if ( (Char.IsDigit(symbol) || (symbol == ',')) && ((index + 1) < expression.Length) )  {                    
                    numberOfExpression += symbol;
                    continue;
                }
                else {
                    if ( Char.IsDigit(symbol) ){
                        numberOfExpression += symbol;
                    }

                    if (numberOfExpression != string.Empty) {
                        float number = float.Parse(numberOfExpression);
                        if (flagOfNegativeNumber) {
                            number = -number;
                            flagOfNegativeNumber = false;
                        }
                        stackOfNumbers.Push(number);
                        numberOfExpression = string.Empty;
                    }
                }

                //Обработка функции
                if (Char.IsLetter(symbol)) {
                    functionOfExpression += symbol;
                    continue;
                }
                else {
                    if( (functionOfExpression != string.Empty) && (symbol == '(') ){
                        string subExpressionString = GetSubExpression(ref index);
                        result = CalculationSubExpression(subExpressionString);                        
                        result = CalculationFunc(functionOfExpression, result);
                        stackOfNumbers.Push(result);

                                                
                        functionOfExpression = string.Empty;
                        continue;
                    }
                    else if(functionOfExpression != string.Empty) {
                        return float.NaN;
                    }
                }

                switch (symbol) {
                    case '(':
                        string subExpressionString = GetSubExpression(ref index);
                        result = CalculationSubExpression(subExpressionString);
                        stackOfNumbers.Push(result);
                        break;
                    case '-':
                        if (stackOfNumbers.Count == 0) {
                            flagOfNegativeNumber = true;
                            continue;
                        }
                        else if(stackOfOperator.Count > 0) {
                            CalculationOper(stackOfOperator.Pop());
                            stackOfOperator.Push(symbol);
                        }                        
                        break;
                    case '+':
                        if (stackOfOperator.Count > 0) {
                            CalculationOper(stackOfOperator.Pop());
                        }                        
                        stackOfOperator.Push(symbol);
                        break;
                    case '*':
                    case '/':
                        if (stackOfOperator.Count > 0) {
                            bool priority = PriorityOfOperations(symbol, stackOfOperator.Peek());
                            if ( !priority ) {
                                CalculationOper(stackOfOperator.Pop());
                            }
                        }
                        
                        stackOfOperator.Push(symbol);
                        break;
                }
            }

            while (stackOfOperator.Count > 0) {
                CalculationOper(stackOfOperator.Pop());                               
            }

            return stackOfNumbers.Pop();
        }

        float CalculationSubExpression(string subExpressionString) {
            Expression subExpression = new Expression(subExpressionString);
            return subExpression.Calculation();
        }

        float CalculationFunc(string functionName, float argument) {
            switch (functionName) {
                case "sin":
                    return (float)Math.Sin(argument);
                case "cos":
                    return (float)Math.Cos(argument);
                case "tg":
                    return (float)Math.Tan(argument);
                case "ctg":
                    return (float)(1/Math.Tan(argument));
            }
            return 1;
        }
        
        void CalculationOper(char symbolOfOperator) {

            float argumentSecond = stackOfNumbers.Pop();
            float argumentFirst = stackOfNumbers.Pop();

            switch (symbolOfOperator) {
                case '+':
                    stackOfNumbers.Push(argumentFirst + argumentSecond);
                    break;
                case '-':
                    stackOfNumbers.Push(argumentFirst - argumentSecond);
                    break;
                case '*':
                    stackOfNumbers.Push(argumentFirst * argumentSecond);
                    break;
                case '/':
                    if (argumentSecond != 0) {
                        stackOfNumbers.Push(argumentFirst / argumentSecond);
                    }
                    else {
                        stackOfNumbers.Push(float.NaN);
                    }
                    break;
                default:
                    stackOfNumbers.Push(float.NaN);
                    break;
            }
        }

        string GetSubExpression(ref int index) {
            int indexOfBeginExpression = index + 1;
            int lengthExpression = GetIndexOfClosingBrace(expression.Substring(index), '(', ')') - 1; ;
            index += lengthExpression + 1;

            return expression.Substring(indexOfBeginExpression, lengthExpression);
        }

        int GetIndexOfClosingBrace(string expression, char separator, char antiseporator) {

            int countSeporetor = 0;

            for(var index = 0; index < expression.Length; index++) {

                char symbol = expression[index];

                if(symbol == separator) {
                    countSeporetor++;
                }

                if(symbol == antiseporator) {
                    countSeporetor--;
                    if(countSeporetor == 0) {
                        return index;
                    }
                }               
            }

            return -1;

        }

        /// <summary>
        /// Возращает true если operatorFirst приоритетнее operatorSecond
        /// </summary>
        /// <param name="operatorFirst"></param>
        /// <param name="operatorSecond"></param>
        /// <returns></returns>
        bool PriorityOfOperations(char operatorFirst, char operatorSecond) {
            if( (operatorFirst == '+') && (operatorSecond == '+') 
                    || (operatorFirst == '-') && (operatorSecond == '-')
                    || (operatorFirst == '*') && (operatorSecond == '*')
                    || (operatorFirst == '/') && (operatorSecond == '/')) {
                return false;
            }

            if ((operatorFirst == '+') && (operatorSecond == '-')
                    || (operatorFirst == '-') && (operatorSecond == '+')
                    || (operatorFirst == '*') && (operatorSecond == '/')
                    || (operatorFirst == '/') && (operatorSecond == '*')) {
                return false;
            }

            if ((operatorFirst == '+') && (operatorSecond == '*')
                    || (operatorFirst == '-') && (operatorSecond == '/')
                    || (operatorFirst == '+') && (operatorSecond == '/')
                    || (operatorFirst == '-') && (operatorSecond == '*')) {
                return false;
            }

            if ((operatorFirst == '*') && (operatorSecond == '+')
                    || (operatorFirst == '/') && (operatorSecond == '-')
                    || (operatorFirst == '*') && (operatorSecond == '-')
                    || (operatorFirst == '/') && (operatorSecond == '+')) {
                return true;
            }

            return false;
        }
    }
}
