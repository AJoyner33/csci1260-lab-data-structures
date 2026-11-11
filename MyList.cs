// MyList: an array that manages itself. It tracks the count, grows by
// doubling when it is full, and refuses any index that is not in use.
//
// Part B. Build this class along with the Class 1 demo.
// Insert is Exercise 2.
public class MyList<T>
{
    private T[] items;
    private int count;

    // Given. Every list starts with room for four items.
    public MyList()
    {
        items = new T[4];
        count = 0;
    }

    // Number of items currently in the list.
    public int Count => count;
    // Number of slots in the underlying array.
    public int Capacity => items.Length;

    // Add to the end. Grow first if every slot is taken.
    // Adds an item to the end, growing the array first if it is full.
    public void Add(T item)
    {
        if (count == items.Length)
        {
            Grow();
        }
        items[count] = item;
        count++;
    }

    // The indexer is the code behind list[2]. Both get and set must
    // refuse any index that is not in use.
    // Gets or sets the item at index, refusing any index that is not in use.
    public T this[int index]
    {
        get
        {
            CheckIndex(index);
            return items[index];
        }
        set
        {
            CheckIndex(index);
            items[index] = value;
        }
    }

    // Insert anywhere from 0 to Count. Inserting at Count is legal and
    // means the same thing as Add. Throw ArgumentOutOfRangeException
    // for anything else.
    // Inserts an item at any index from 0 to Count, growing first if needed.
    public void Insert(int index, T item)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        if (count == items.Length)
        {
            Grow();
        }
        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }
        items[index] = item;
        count++;
    }

    // Remove the item at index and close the gap.
    // Removes the item at index and shifts later items left to close the gap.
    public void RemoveAt(int index)
    {
        CheckIndex(index);
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        count--;
    }

    // Linear search. Return the index, or -1 when the item is not there.
    // Compare with Equals(a, b), which works for every type T.
    // Returns the index of the first item equal to item, or -1 if it is not there.
    public int IndexOf(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (Equals(items[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    // Given. Builds a line like "[A, B, C]" from the slots in use.
    public override string ToString()
    {
        string result = "[";
        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                result += ", ";
            }
            result += items[i];
        }
        return result + "]";
    }

    //   Grow()            make a new array twice the size, copy every item
    //   CheckIndex(index) throw ArgumentOutOfRangeException unless
    //                     0 <= index < count
    // Replaces the array with one twice the size, copying every item in use.
    private void Grow()
    {
        T[] bigger = new T[items.Length * 2];
        for (int i = 0; i < count; i++)
        {
            bigger[i] = items[i];
        }
        items = bigger;
    }

    // Throws ArgumentOutOfRangeException unless 0 <= index < count.
    private void CheckIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }
}
