using System.Runtime.Intrinsics;

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
        if(value == Data)
        {
            return;
        }

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
        if (value == Data)
            return true;
        if (value < Data)
        {
            // Insert to the left
            if (Left == null)
                return false;
            else
            {
                if(Left.Data == value)
                    return true;
                return Left.Contains(value);
            }
        }
        else
        {
            // Insert to the right
            if (Right is null)
                return false;
            else
            {
                if(Right.Data == value)
                    return true;
                return Right.Contains(value);
            }
        }
        // return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int left = 0;
        int right = 0;
        int count = 0;
        if(Left is not null | Right is not null)
        {
            count++;
            if(Left is not null)
            {
                // left += 1;
                left += Left.GetHeight() + 1; // Replace this line with the correct return statement(s)
            }
                
            if(Right is not null)
            {
                // right += 1;
                right += Right.GetHeight()+1;// Replace this line with the correct return statement(s)
            }
        }

        if(Right is null & Left is null)
            return 1;


        if(right > left)
            return right;
        return left;
    }
}