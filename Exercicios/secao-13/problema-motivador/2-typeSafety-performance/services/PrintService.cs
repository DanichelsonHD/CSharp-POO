namespace Secao13.problema_motivador.performance.services
{
    class PrintService
    {
        private object[] _values = new object[10];
        private int _count = 0;
        public void AddValue(object value)
        {
            if (_count == 10) throw new InvalidOperationException("PrintService is full");

            _values[_count] = value;
            _count++;
        }
        public object First()
        {
            if (_count == 0) throw new InvalidOperationException("PrintService is empty");

            return _values[0];
        }
        public void Print()
        {
            string prompt = "[";
            for (int index = 0; index < _count; index++)
            {
                prompt += _values[index].ToString() + ", ";
            }
            prompt = prompt.Remove(prompt.Length - 2);
            prompt += "]";
            Console.WriteLine(prompt);
        }
    }
}