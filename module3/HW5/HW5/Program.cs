using System;
using System.Collections.Generic;

namespace HW5
{
    namespace Task
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
            }
            public override string ToString()
            {
                return $"{Data}";
            }
        }

        class LinkedList
        {
            Node head;
            Node tail;

            public int Count { get; set; }

            public void Add(int data)
            {
                Node node = new Node(data);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
                Count++;
            }
            public void AddFirst(int data)
            {
                Node node = new Node(data);

                node.Next = head;
                head = node;

                if (Count == 0)
                    tail = head;

                Count++;
            }
            public void Clear()
            {
                Count = 0;
                head = null;
                tail = null;
            }
            public bool Contains(int data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public void Print()
            {
                Node current = head;
                int i = 1;
                while (current != null)
                {
                    Console.WriteLine($"{i} - {current}");
                    current = current.Next;
                    i++;
                }
            }

            public Node Max()
            {
                Node current = head;
                Node max = null;
                while (current != null)
                {
                    if (max == null)
                        max = current;
                    else if (max.Data < current.Data)
                        max = current;
                    current = current.Next;
                }
                return max;
            }

            public Node Min()
            {
                Node current = head;
                Node min = null;
                while (current != null)
                {
                    if (min == null)
                        min = current;
                    else if (min.Data > current.Data)
                        min = current;
                    current = current.Next;
                }
                return min;
            }

            public Node Middle()
            {
                Node current = head;
                for (int i = 0; i < Count / 2; i++)
                    current = current.Next;
                return current;
            }

            public bool Remove(int data)
            {
                Node current = head;
                Node prev = null;

                while (current != null)
                {
                    if (current.Data == data)
                    {
                        if (prev != null)
                        {
                            prev.Next = current.Next;
                            if (current.Next == null)
                                tail = prev;
                        }
                        else
                        {
                            head = head.Next;
                        }
                        if (head == null)
                            tail = null;
                        Count--;
                        return true;
                    }
                    prev = current;
                    current = current.Next;
                }
                return false;
            }
        }

        class MainClass
        {
            public static void Main()
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.AddFirst(3);
                linkedList.Add(4);
                linkedList.Print();
            }
        }
    }
}