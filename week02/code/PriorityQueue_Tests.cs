using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        // Test for PriorityItem with the most priority

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Emmanuel", 8);
        priorityQueue.Enqueue("Abel", 7);
        priorityQueue.Enqueue("Favour", 5);
        priorityQueue.Enqueue("Angel", 10);
        Debug.WriteLine(priorityQueue.ToString());
        // Assert.Fail("Implement the test case and then remove this.");
        Assert.AreEqual(priorityQueue.Dequeue(), "Angel");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        // Tests if the Dequeue method in the PriorityQueue follows proper order (priority) to remove elements

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Differential", 7);
        priorityQueue.Enqueue("Engine", 10);
        priorityQueue.Enqueue("Rear Axles", 6);
        priorityQueue.Enqueue("Body", 4);
        priorityQueue.Enqueue("Gearbox", 9);
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
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        // Test PriorityQueue for handling error in the case of where no items are in the list
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