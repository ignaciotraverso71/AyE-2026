
int fact, num;
Console.Write("Enter a number: ");
num = Convert.ToInt32(Console.ReadLine());

 // calling recursive function   
fact = factorial(num);

Console.WriteLine("Factorial of {0} is {1}", num, fact);


int factorial(int num)
{
    // termination condition
    if (num == 0)
        return 1;
    else
        // recursive call
        return num * factorial(num - 1);
}
        