namespace TBQ.Measurements.Temperature
{
    public class Celsius : Temperature
    {
        public Celsius(double initialValue) : base(initialValue) { }
        public Celsius(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return baseValue;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return unitValue;
        }

        public override Temperature Add(double temperature)
        {
            return new Celsius(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Celsius(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Celsius(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Celsius(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Celsius(-Value);
        }
        
        public static Celsius operator +(Celsius temperature1, double temperature2)
        {
            return (Celsius)temperature1.Add(temperature2);
        }
        public static Celsius operator +(Celsius temperature1, Temperature temperature2)
        {
            return (Celsius)temperature1.Add(temperature2);
        }
        public static Celsius operator -(Celsius temperature1, double temperature2)
        {
            return (Celsius)temperature1.Subtract(temperature2);
        }
        public static Celsius operator -(Celsius temperature1, Temperature temperature2)
        {
            return (Celsius)temperature1.Subtract(temperature2);
        }
        public static Celsius operator -(Celsius temperature)
        {
            return (Celsius)temperature.Negate();
        }

        public static Celsius operator *(Celsius temperature, double multiplier)
        {
            return new Celsius(temperature.Value * multiplier);
        }
        public static Celsius operator /(Celsius temperature, double divisor)
        {
            return new Celsius(temperature.Value / divisor);
        }
        public static Celsius operator %(Celsius temperature, double modulo){
            return new Celsius(temperature.Value % modulo);
        }

        public override string Name { get; } = "Celsius";
        public override string Symbol { get; } = "°C";
    }
}
