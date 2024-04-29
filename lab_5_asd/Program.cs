using System;
using System.Collections.Generic;

class QueueUsingTwoStacks
{
    private Stack<int> inbox = new Stack<int>();
    private Stack<int> outbox = new Stack<int>();

    public void Enqueue(int item)
    {
        inbox.Push(item);
    }

    public void Dequeue()
    {
        if (outbox.Count ==0)
        {
            while (inbox.Count > 0)
            {
                outbox.Push(inbox.Pop());
            }
        }

        if (outbox.Count>0)
        {
            outbox.Pop(); 
        }
        else
        {
            Console.WriteLine("Queue is empty.");
            Environment.Exit(0);
        }
    }

    public void DisplayQueue()
    {
        Console.WriteLine("Queue contents:");
        foreach (int value in inbox)
        {
            Console.Write(value + " ");
        }
        foreach (int value in outbox)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        QueueUsingTwoStacks queue = new QueueUsingTwoStacks();

        while (true)
        {
            Console.WriteLine("Enter a natural number to enqueue (0 to dequeue three elements):");
            string input = Console.ReadLine();
            int item;
            if (!int.TryParse(input, out item))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            if (item == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    queue.Dequeue();
                }
            }
            else
            {
                queue.Enqueue(item);
            }

            queue.DisplayQueue();
        }
    }
}
