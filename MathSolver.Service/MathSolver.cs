namespace MathSolver.Service;

public class MathSolver
{
    private readonly string _inputFilePath;
    public string OutputFilePath { get; set; }
    
    public MathSolver(string inputFilePath)
    {
        _inputFilePath = inputFilePath;
        OutputFilePath = _inputFilePath.Replace(".txt", "-Solution.txt");
    }
    
    public void ProcessFile()
    {
        int lineNumber = 0;

        try
        {
            using StreamReader reader = new(_inputFilePath);
            using StreamWriter writer = new(OutputFilePath);
            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                lineNumber++;
                writer.WriteLine($"{line} {Solve(line)}");
            }
        }
        catch (FileNotFoundException e)
        {
            throw new FileNotFoundException("File could not be found. Please ensure correct file path is used.");
        }
        catch (Exception e)
        {
            throw new Exception($"Error encountered on line {lineNumber}: {e.Message}");
        }
    }
    
    public string Solve(string? expression)
    {
        if (string.IsNullOrEmpty(expression))
            throw new ArgumentNullException(expression, "Expression cannot be null or an empty string");

        // Assumption #3 - no letters can appear in an expression
        if (expression.Any(Char.IsLetter))
            throw new ArgumentOutOfRangeException(expression, "Expression cannot contain any letters");

        // Assumption #4 - expression must contain an operator
        // Assumption #5 - expressions won't be exponents and so every expression can be broken in LH & RH
        if (!expression.Any(c => new char[]{'+', '-', '*', '/'}.Contains(c)))
            throw new ArgumentOutOfRangeException(expression, "Expression must have an operator letters");
        
        // Assumption #1 - all units of the expression, i.e. numbers or symbols will be surrounded by spaces
        string[] parsedExpression = expression.Split(" ");
        
        // Assumption #2 - the final character of an expression should be an equals sign
        if (parsedExpression.Last() != "=")
            throw new ArgumentOutOfRangeException(expression, "Expression must end with an equals sign");

        int result = Evaluate(int.Parse(parsedExpression[0]), int.Parse(parsedExpression[2]), parsedExpression[1]);
        
        
        return result.ToString();
    }

    private int Evaluate(int leftHand, int rightHand, string operation)
    {
        int result;
        switch(operation)
        {
            case "+":
                result = leftHand + rightHand;
                break;
            case "-":
                result = leftHand - rightHand;
                break;
            case "*":
                result = leftHand * rightHand;
                break;
            case "/":
                result = leftHand / rightHand;
                break;
            default:
                throw new ArgumentOutOfRangeException(operation, "Invalid operator");
                break;
        };

        return result;
    }
    
    
}