using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find highest priority (FIFO if tie)
        int highPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = i;
            }
        }

        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // ✅ REQUIRED
        return value;
    }

    // DO NOT MODIFY
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }

    // ✅ MUST be inside PriorityQueue
    private class PriorityItem
    {
        public string Value { get; }
        public int Priority { get; }

        public PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        // DO NOT MODIFY
        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }
}
