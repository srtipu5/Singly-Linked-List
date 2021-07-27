using System;
using System.Collections.Generic;

namespace SinglyLinkedList
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int value)
        {
            data = value;
            next = null;
        }
    }
    public class LinkedList
    {
        Node start;
        Node end;
        int count;
        public LinkedList()
        {
            start = null;
            end = null;
            count = 0;
        }

        public void InsertFirst(int value)
        {
            Node newNode = new Node(value);
            if (start == null)
            {
                start = newNode;
                end = newNode;
                count++;
                return;
            }
            Node temp = start;
            start = newNode;
            start.next = temp;
            count++;
            return;
        }
        public void InsertLast(int value)
        {
            Node newNode = new Node(value);
            if(start == null)
            {
                start = newNode;
                end = newNode;
                count++;
                return;
            }
            end.next = newNode;
            end = newNode;
            count++;
        }

        private Node GetSearchNodeAddressByIndex(int index)
        {
            int i = 0;
            Node s = start;
            while (s != null)
            {
                
                if (i == index)
                {
                    return s;
                }
                i++;
                s = s.next;
            }
            return null;
        }

        private int GetSearchNodeIndex(Node searchNode)
        {
            int index = 0;
            Node s = start;
            while (s != null)
            {

                if (s == searchNode)
                {
                    return index;
                }
                index++;
                s = s.next;
            }
            return -1;
        }

        private Node GetSearchNodeAddressByValue(int searchValue)
        {
            Node s = start;
            while(s != null)
            {
                if(s.data == searchValue)
                {
                    return s;
                }
                s = s.next;
            }
            return null;
        }

        public void InsertAfter(int searchValue,int addValue)
        {
            Node searchNode = GetSearchNodeAddressByValue(searchValue);

            if(searchNode == null)
            {
                return;
            }
            else if(searchNode == end)
            {
                InsertLast(addValue);
                return;
            }
            Node newNode = new Node(addValue);
            Node tempNode = searchNode.next;
            searchNode.next = newNode;
            newNode.next = tempNode;
            count++;
        }

        public void InsertBefore(int searchValue, int addValue)
        {
            Node searchNode = GetSearchNodeAddressByValue(searchValue);

            if (searchNode == null)
            {
                return;
            }
            else if (searchNode == start)
            {
                InsertFirst(addValue);
                return;
            }
            int index = GetSearchNodeIndex(searchNode);
            Node beforeNode = GetSearchNodeAddressByIndex(index - 1);
            Node newNode = new Node(addValue);
            Node tempNode = beforeNode.next;

            beforeNode.next = newNode;
            newNode.next = tempNode;
            count++;
        }
        public void InsertAtIndex(int position,int addValue)
        {

            if (position < 0 || position > count-1)
            {
                return;
            }
            else if (position == 0)
            {
                InsertFirst(addValue);
                return;
            }
            else if (position == count-1)
            {
                InsertLast(addValue);
                return;
            }

            Node newNode = new Node(addValue);
            Node beforeNode = GetSearchNodeAddressByIndex(position-1);
            Node tempNode = beforeNode.next;
            beforeNode.next = newNode;
            newNode.next = tempNode;
            count++;
        }
        public void DeleteFirst()
        {
            if (start == null) //count == 0
            {
                return;
            }

            if (count == 1)
            {
                start = null;
                end = null;
                count--;
                return;
            }

            start = start.next;
            count--;
            return;
        }
        public void DeleteLast()
        {
            if (start == null) //count == 0
            {
                return;
            }

            if(count == 1)
            {
                start = null;
                end = null;
                count--;
                return;
            }

            int index = GetSearchNodeIndex(end);
            Node beforeNode = GetSearchNodeAddressByIndex(index - 1);
            end = beforeNode;
            end.next = null;
            count--;
            return;
        }

        public void Print()
        {
            while(start != null)
            {
                Console.WriteLine(start.data);
                start = start.next;
            }
            Console.WriteLine($"Total element : {count}");
        }
        public void DeleteAtIndex(int position)
        {
            if (position < 0 || position > count-1)
            {
                return;
            }
            else if(position == 0)
            {
                DeleteFirst();
                return;
            }
            else if(position == count-1)
            {
                DeleteLast();
                return;
            }
            Node deleteNode = GetSearchNodeAddressByIndex(position);
            int index = GetSearchNodeIndex(deleteNode);
            Node prevNode = GetSearchNodeAddressByIndex(index-1);
            prevNode.next = deleteNode.next;
            count--;
        }
        public void DeleteItem(int value)
        {
            Node deleteNode = GetSearchNodeAddressByValue(value);
            
            if(deleteNode == null)
            {
                return;
            }
            int index = GetSearchNodeIndex(deleteNode);
            if(index == 0)
            {
                DeleteFirst();
                return;
            }
            else if(index == count-1)
            {
                DeleteLast();
                return;
            }
            DeleteAtIndex(index);
            return;
        }
        public void SearchItem(int value)
        {
            Node searchNode = GetSearchNodeAddressByValue(value);
            if(searchNode != null)
            {
                int index = GetSearchNodeIndex(searchNode);
                Console.WriteLine($"{value} found at {index} index.");
                return;

            }

            Console.WriteLine($"{value} not found.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertLast(8);
            list.InsertFirst(100);
            list.InsertFirst(1);
            list.InsertLast(4);
            list.InsertFirst(23);
            list.InsertAfter(4, 10300);
            list.InsertAtIndex(1, 200);
            list.InsertBefore(4, 400);
            list.DeleteFirst();
            list.DeleteLast();
            list.DeleteAtIndex(2);
            list.DeleteItem(200);
            list.InsertFirst(100);
            list.DeleteFirst();
            list.Print();
            list.SearchItem(1);
            Console.ReadKey();
           
        }
    }
}
