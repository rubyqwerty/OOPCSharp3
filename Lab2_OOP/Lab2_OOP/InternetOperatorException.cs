using System;

namespace Lab2_OOP
{
    class InternetOperatorException : DivideByZeroException
    {
        private string errorPole;

        public InternetOperatorException(string _message) : base(_message) { }
        public InternetOperatorException(string _message, string _val) : base(_message)
        {
            errorPole = _val;
        }

        public string ErrorPole { get => errorPole; private set => errorPole = value; }
    }
}
