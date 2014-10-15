using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digital_vackarklocka
{
    class NumberDisplay
    {
        private int _maxNumber;
        private int _number;

        public int MaxNumber
        {

            get
            {
                return _maxNumber;
            }

            set
            {
                if (value > 0)
                    _maxNumber = value;
                else
                    throw new ArgumentException();
            }
        }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value >= 0 && value <= _maxNumber)
                    _number = value;
                else
                    throw new ArgumentException(String.Format("Värdet är inte i intervallet 0-{0}.", MaxNumber));
            }
        }
        public void Increment()
        {
            _number++;
            if (_number >= _maxNumber)
            {
                _number = 0;
                return;
            }
        }
        public override string ToString()
        {
            return Number.ToString();
        }
        public string ToString(string format)
        {
            if (format == "G" || format == "0")
                return String.Format("{0}", Number);
            else if (format == "00")
            {
                if (Number <= 9)
                    return String.Format("{0:00}", Number);
                else
                    return String.Format("{0}", Number);
            }
            else
                throw new FormatException();

        }
        public NumberDisplay(int maxNumber) : this(maxNumber, 0) { }
        public NumberDisplay(int maxNumber, int number)
        {

            MaxNumber = maxNumber;
            Number = number;
        }
    }
}
