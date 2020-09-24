using System;
using System.Collections.Generic;

namespace Seek
{

    public abstract class Search<Key, Val>
    {
        public abstract Val Get(Key key);
        public abstract void Put(Key key, Val value);
        public abstract int Size();
        public abstract void Delete(Key key);
        public abstract IEnumerable<Key> Keys();
        public bool Contains(Key key)
        {
            return Get(key) != null;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }
    }
    public class SequentionalSearch<Key,Val>: Search<Key,Val>
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

        override public Val Get(Key key)
        {
            for(Node i = first;i != null;i = i.next)
            {
                if (key.Equals(i.key))
                    return i.value;
            }
            return default(Val);
        }

        override public void Put(Key key,Val value)
        {
            if(value == null)
            {
                Delete(key);
                return;
            }
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

        override public int Size()
        {
            int num = 0;
            for(Node i = first;i != null;i = i.next)
            {
                num += 1;
            }
            return num;
        }

        override public void Delete(Key key)
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

        override public IEnumerable<Key> Keys()
        {
            for(Node i = first;i != null;i = i.next)
            {
                yield return i.key;
            }
        }
    }
}