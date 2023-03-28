using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_OOP
{
    class BaseObject
    {
        public delegate void ObjectHandler(string message);
        public event ObjectHandler? Notify;

        public List<InternetOperator> Objects = new List<InternetOperator>();

        public void Push(InternetOperator internetOperator)
        {
            Objects.Add(internetOperator);
            Notify?.Invoke("Объект добавлен!");
        }
        public void Delete(int index)
        {
            Objects.RemoveAt(index);
            Notify?.Invoke("Объект удален!");
            InternetOperator.counterObject--;
        }
    }
}
