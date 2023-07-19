// See https://aka.ms/new-console-template for more information
using CircularArray;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Stack<char> StackResult = new();

var listItemNumbers = new CircularArray<char>(new char[] {
    '1','2','3','4','5',
});

var listItemChars = new CircularArrayDecorator<char>(new char[] {
    'a','b','c','d',
}, listItemNumbers, StackResult);

var listItemSigns = new CircularArrayDecorator<char>(new char[] {
    '-','+','=',
}, listItemChars, StackResult);

listItemSigns = new CircularArrayDecorator<char>(new char[] {
    '/','*','?',
}, listItemSigns, StackResult);

bool isExit = false;
listItemNumbers.OnEnding += (s, e) => isExit = true;


for (listItemSigns.MoveNext(); !isExit; listItemSigns.MoveNext())
{
    Console.WriteLine(String.Join(" ", StackResult.ToArray()));
}