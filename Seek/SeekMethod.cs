using System;
using System.Collections.Generic;

namespace Seek
{
    public class SequentionalSearch<Key,Val>
    {
        private Node first = null;

        private class Node
        {
            public Key key;
            public Val value;
            public Node next;
            public Node(Key key,Val value,Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        public Val Get(Key key)
        {
            for(Node i = first;i != null;i = i.next)
            {
                if (key.Equals(i.key))
                    return i.value;
            }
            return null;
        }

        public void Put(Key key,Val value)
        {
            for(Node i = first;i != null;i = i.next)
            {
                if (key.Equals(i.key))
                {
                    i.value = value;
                    return;
                }
            }
            this.first = new Node(key,value,first);
        }

        public int Size()
        {
            int num = 0;
            for(Node i = first;i != null;i = i.next)
            {
                num += 1;
            }
            return num;
        }

        public void Delete(Key key)
        {
            Node lastNode = null;
            for(Node i = first;i != null;i = i.next)
            {
                if (key.Equals(i.key))
                {
                    if(lastNode == null)
                        first = i.next;
                    else
                    {
                        lastNode.next = i.next;
                        i = null;
                        return;
                    }
                }
                lastNode = i;
            }
        }

        public IEnumerable<Key> Keys()
        {
            for(Node i = first;i != null;i = i.next)
            {
                yield return i.key;
            }
        }
    }
}