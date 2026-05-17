public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}
/*Purpose 
This function reverses a string. 
It pushes each character onto a stack 
(LIFO — Last In, First Out), 
then pops them all off in reverse order.*/
