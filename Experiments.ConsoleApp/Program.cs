// See https://aka.ms/new-console-template for more information
using CircularArray;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Stack<char> StackResult = new();

var listNumber = new CircularArray<char>(new char[] {
    '1','2','3','4','5',
});

var lisChar = new CircularArrayDecorator<char>(new char[] {
    'a','b',
}, listNumber, StackResult);

var listNumber2 = new CircularArrayDecorator<char>(new char[] {
    '-','+','=',
}, lisChar, StackResult);

bool isExit = false;
listNumber.OnEnding += (s, e) => isExit = true;


for (listNumber2.MoveNext(); !isExit; listNumber2.MoveNext())
{
    Console.WriteLine(String.Join(" ", StackResult.ToArray()));
}

isExit = false;
for (lisChar.MoveNext(); !isExit; lisChar.MoveNext())
{
    Console.WriteLine(String.Join(" ", StackResult.ToArray()));
}