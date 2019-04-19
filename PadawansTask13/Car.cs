namespace PadawansTask13
{
    class Car
    {
        private string _brand;

        public Car()
        {
            _brand = string.Empty;
        }

        public Car(string brand)
        {
            _brand = brand;
        }

        public string GetCarBrand()
        {
            return _brand;
        }
    }
}
