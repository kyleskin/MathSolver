try{

    Console.WriteLine("Please provide path to file:");
    string? path = Console.ReadLine();

    if (string.IsNullOrEmpty(path))
    {
        throw new ArgumentNullException(path, "Empty file path given.");
    }

    MathSolver.Service.MathSolver solver = new(path);
    solver.ProcessFile();
    Console.WriteLine();
    Console.WriteLine($"File processed successfully. Solution file created at: {solver.OutputFilePath}");
    Environment.Exit(0);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Environment.Exit(-1);
}

