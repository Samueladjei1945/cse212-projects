using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 items with different priorities: "Low"(1), "High"(3), "Med"(2).
    // Dequeue should return the highest priority item first.
    // Expected Result: "High" is returned first, then "Med", then "Low"
    // Defect(s) Found: 
    //   1. Loop used < _queue.Count - 1, skipping the last item — "High" at back was never found
    //   2. _queue.RemoveAt() was never called — items were never actually removed from the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Med", 2);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Med", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue 3 items with the SAME priority: "First"(2), "Second"(2), "Third"(2).
    // When priorities are equal, FIFO order must be followed (first added = first removed).
    // Expected Result: "First", then "Second", then "Third"
    // Defect(s) Found:
    //   1. >= was used instead of > when comparing priorities, causing the LAST equal-priority
    //      item to be selected instead of the FIRST, violating FIFO order
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: None — empty queue exception works correctly
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue 2 items where the LAST item has the highest priority.
    // Expected Result: The last-added item "Last"(5) is dequeued first, then "First"(1)
    // Defect(s) Found:
    //   1. Loop used < _queue.Count - 1 which skipped the last element entirely,
    //      so the highest priority item at the back was never considered
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Last", 5);

        Assert.AreEqual("Last", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue 3 items, dequeue one, verify queue size decreased by 1.
    // Expected Result: After one dequeue, queue should have 2 items remaining.
    // Defect(s) Found:
    //   1. _queue.RemoveAt() was missing — items were never removed, queue size never decreased
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        priorityQueue.Dequeue();

        // After removing 1 item, only 2 should remain: "A (Pri:1), B (Pri:2)"
        Assert.AreEqual("[A (Pri:1), B (Pri:2)]", priorityQueue.ToString());
    }
}