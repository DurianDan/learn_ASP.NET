using System; // like `import`

namespace HelloWorld // used to store classes and other namespaces
{
  class Program
  {
    static void Main(string[] args) // a code that always will be 
    {
      int myNum = 91;
      int divider = 3;
      string myName = "Huy";
      Console.WriteLine($"My Name is {myName}");
      Console.WriteLine($"{myNum}%{divider} = {myNum%divider}");
      Console.WriteLine($"Converted {myNum}/{divider} = {(float) myNum/divider}");
      Console.WriteLine($"This is your input: [{string.Join(", ", args)}]");

      Console.WriteLine("How old are you?");
      // cant use `const`,
      // because user input is a variable edited at runtime
      int userAge = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine($"You are {userAge} years old");

    }
  }
}