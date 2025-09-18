namespace Secao13.problema_motivador.reuso.services
{
    class PrintService
    {
        private int[] _values = new int[10];
        private int _count = 0;
        public void AddValue(int value)
        {
            if (_count == 10) throw new InvalidOperationException("PrintService is full");

            _values[_count] = value;
            _count++;
        }
        public int First()
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