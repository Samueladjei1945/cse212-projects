public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Do not insert duplicate values — just return if value already exists
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Base case: found the value
        if (value == Data)
            return true;

        // Search left subtree if value is smaller
        if (value < Data)
            return Left != null && Left.Contains(value);

        // Search right subtree if value is larger
        return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Get height of left and right subtrees (0 if null)
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Height is 1 (current node) + the larger of the two subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}