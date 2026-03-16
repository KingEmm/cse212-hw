using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test for PriorityItem with the most priority
    // Expected Result: Emmanuel
    // Defect(s) Found: Can't iterate through the lists completely when finding the highest Priority
    public void TestPriorityQueue_1()
    {
        // 

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Emmanuel", 10);
        priorityQueue.Enqueue("Abel", 7);
        priorityQueue.Enqueue("Favour", 5);
        priorityQueue.Enqueue("Angel", 10);
        Debug.WriteLine(priorityQueue.ToString());
        // Assert.Fail("Implement the test case and then remove this.");
        Assert.AreEqual(priorityQueue.Dequeue(), "Emmanuel");
    }

    [TestMethod]
    // Scenario: Iterate through the priorityQueue and ensure they follow proper order when dequeued
        // Tests if the Dequeue method in the PriorityQueue follows proper order (priority) to remove elements
    // Expected Result: "Engine", "Gearbox", "Propeller Shaft", "Differential", "Rear Axles"
    // Defect(s) Found: Items don't get removed after been dequeued
    public void TestPriorityQueue_2()
    {

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Differential", 7);
        priorityQueue.Enqueue("Engine", 10);
        priorityQueue.Enqueue("Rear Axles", 6);
        priorityQueue.Enqueue("Body", 4);
        priorityQueue.Enqueue("Gearbox", 10);
        priorityQueue.Enqueue("Wheel", 5);
        priorityQueue.Enqueue("Propeller Shaft", 8);
        // priorityQueue.Enqueue("Engine", 10);

        string[] driveTrain = ["Engine", "Gearbox", "Propeller Shaft", "Differential", "Rear Axles"];
        // string[] driveTrainList = new string[5];

        int i=0;
        for (; i<5; i++)
        {
            Assert.AreEqual(driveTrain[i], priorityQueue.Dequeue());
        }
    }

     [TestMethod]
    // Scenario: Has an error message ("The queue is empty.") when Queue is empty
    // Test PriorityQueue for handling error in the case of where no items are in the list
    // Expected Result: "The queue is empty."
    // Defect(s) Found: No actual deffect found just want to check
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
        }
        catch (InvalidOperationException error)
        {
            Assert.AreEqual("The queue is empty.", error.Message);
        }
    }

    // Add more test cases as needed below.
}