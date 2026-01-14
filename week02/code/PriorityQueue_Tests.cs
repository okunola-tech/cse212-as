using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue removes highest priority
    // Expected Result: Item with highest priority is returned
    // Defect(s) Found:
    // Initially failed because dequeue returned FIFO instead of highest priority.
    // Status after fix: PASSED
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);
        pq.Enqueue("Medium", 3);

        var result = pq.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Two items have same highest priority
    // Expected Result: FIFO order preserved
    // Defect(s) Found:
    // Initially failed because last inserted item was returned.
    // Status after fix: PASSED
    public void TestPriorityQueue_FIFO_WhenSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with correct message
    // Defect(s) Found:
    // Exception message incorrect initially.
    // Status after fix: PASSED
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
