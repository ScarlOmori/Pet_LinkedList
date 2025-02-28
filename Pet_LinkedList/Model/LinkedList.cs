﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_LinkedList.Model
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<T> Head { get; private set; }
        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T> Tail { get; private set; }
        /// <summary>
        /// Кол-во элементов в списке
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Пустой список
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// Спискок с начальным элементом
        /// </summary>
        /// <param name="data"></param>
        public LinkedList(T data)
        {
            SetHeadAndTail(data);
        }

        /// <summary>
        /// Добавить данные в конец списка
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data) 
        {
            if (Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else 
            {
                SetHeadAndTail(data);
            }

        }
        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data) 
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                var current = Head.Next;
                var previous = Head;
                while (current.Next != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else 
            {
                SetHeadAndTail(data);
            }
        }
        /// <summary>
        /// Добавить данные в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data) 
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
        }

        public void InsertAfter(T target, T data) 
        {
            if (Head != null)
            {
                var item = new Item<T>(data);
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }
        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear() 
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        private void SetHeadAndTail(T data) 
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count=1;
        }
        /// <summary>
        /// Получить перечесление всех элементов списка
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null) 
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public override string ToString()
        {
            return "LinkedList" + Count + "элементов";
        }

        
    }
}
