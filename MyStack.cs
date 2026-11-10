// MyStack: last in, first out.
//
// Part C. Build this class along with the Class 2 demo.
// A stack HAS A MyList. It does not inherit from one.
public class MyStack<T>
{

    // the items. The top of the stack is the END of the list.
    private MyList<T> items = new MyList<T>();


    public int Count => items.Count;
    public bool IsEmpty => items.Count == 0;

    // Put an item on top.
    public void Push(T item)
    {
        items.Add(item);
    }

    // Take the top item off and hand it back.
    public T Pop()
    {
        T top = Peek();
        items.RemoveAt(items.Count - 1);
        return top;
    }

    // Look at the top item without removing it. On an empty stack, throw
    // InvalidOperationException("Stack is empty.").
    public T Peek()
    {
        // TODO: Part C, demo
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return items[items.Count - 1];
    }
}
