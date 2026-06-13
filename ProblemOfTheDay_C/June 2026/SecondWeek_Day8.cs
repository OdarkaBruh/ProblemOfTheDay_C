using System;
using System.Collections.Generic;

public class SecondWeek_Day8
{
    public static void launchDay()
    {
        int[] array = new[] { 1, 2, 3 };
        var node = new Node(array[0]);
        for (var i = 1; i < array.Length; i++)
        {
            new Node(array[i]);
        }

        var result = compute(node);

        Console.WriteLine("Result: ");
        while (result != null)
        {
            Console.Write(result.data);
            Console.Write(" ");
            result = result.next;
        }
    }

    /// <summary>
    /// 08.06.2026 (13.06.2026) - Delete Nodes with Greater on Right
    ///
    /// Given a singly linked list, remove all nodes that have a node with a greater value anywhere to their right
    /// in the list. Return the head of the modified linked list.
    /// </summary>
    /// <param name="head">the head of the linked list</param>
    /// <returns>the head of the modified linked list</returns>
    private static Node compute(Node head)
    {
        List<Node> nodes = new List<Node> { };
        while (head != null)
        {
            nodes.Add(head);
            head = head.next;
        }

        var maxValue = nodes[nodes.Count - 1].data;
        Node relink = null;
        for (var i = nodes.Count - 1; i >= 0; i--)
        {
            if (nodes[i].data < maxValue)
            {
                if (relink == null) relink = nodes[i].next;
            }
            else
            {
                maxValue = Math.Max(nodes[i].data, maxValue);
                if (relink != null)
                {
                    nodes[i].next = relink;
                    relink = null;
                }
            }
        }

        if (relink == null) return nodes[0].data < maxValue ? nodes[1] : nodes[0];
        else return relink;
    }

    /// <summary>
    /// IS RELATED TO THE METHOD ABOVE ↑↑↑
    /// </summary>
    public class Node
    {
        public int data;
        public Node next;
        private static Node _previous;

        public Node(int d)
        {
            data = d;
            next = null;

            if (_previous != null) _previous.next = this;
            _previous = this;
        }
    }

    // first attempt (is slower (time is 0.15, new version takes 0.11)) 
    //
    // private static Node compute(Node head) {
    //     while (head.next != null && !CheckNode(head)) {
    //         head = head.next;
    //     }
    //     if (head.next == null) return head;
    //     
    //     Node previous = head;
    //     Node current = head;
    //     while (current.next != null)
    //     {
    //         current = current.next;
    //         if (!CheckNode(current)){
    //             Console.WriteLine("NOT " + current.data);
    //             previous.next = current.next;
    //         } else previous = current;
    //     }
    //     return head;
    //     
    //     bool CheckNode(Node value){
    //         int check = value.data;
    //         while (value != null && check >= value.data) {
    //             value = value.next;
    //         }
    //         return value == null;
    //     }
    // }
}