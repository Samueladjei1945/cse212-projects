public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}
/*Purpose
This function evaluates Reverse Polish Notation 
(RPN) a mathematical expression where operators
 come after their operands. Numbers are pushed onto 
 the stack; when an operator is encountered, two numbers
  are popped, the operation is applied, 
and the result is pushed back.*/

/* 2. Read 5   → stack: [5]
Read 3   → stack: [5, 3]
Read 7   → stack: [5, 3, 7]
Read +   → pop 7 and 3, push (3+7=10) → stack: [5, 10]
Read *   → pop 10 and 5, push (5*10=50) → stack: [50]

Output: 50
*/

/* 3. Read 6   → stack: [6]
Read 2   → stack: [6, 2]
Read +   → pop 2 and 6, push (6+2=8)  → stack: [8]
Read 5   → stack: [8, 5]
Read 3   → stack: [8, 5, 3]
Read -   → pop 3 and 5, push (5-3=2)  → stack: [8, 2]
Read /   → pop 2 and 8, push (8/2=4)  → stack: [4]

Output: 4
*/

/* ErrorWhen it triggersExample 
inputInvalid Case 1!An operator is encountered but fewer than 2 numbers are on the stack5 + (only one number before operator)
Invalid Case 2!Division by zero — the second operand popped is 05 0 /
Invalid Case 3!A token is not a number and not an operator5 3 abc +
Invalid Case 4!After processing everything, the stack doesn't have exactly 1 result — too many leftover numbers5 3 (two numbers, no operator to combine them)
*/