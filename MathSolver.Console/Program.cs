// See https://aka.ms/new-console-template for more information


Console.WriteLine("Please provide path to file:");
string? path = Console.ReadLine();

if (string.IsNullOrEmpty(path))
{
    throw new ArgumentNullException(path, "Empty file path given.");
}

MathSolver.Service.MathSolver solver = new(path);
solver.ProcessFile();
