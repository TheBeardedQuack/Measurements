namespace TBQ.Measurements.Temperature
{
    public class Fahrenheit : Temperature
    {
        public Fahrenheit(double initialValue = 0.0) : base(initialValue) { }
        public Fahrenheit(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return (baseValue * 1.8) + 32.0;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return (unitValue - 32.0) / 1.8;
        }

        public override Temperature Add(double temperature)
        {
            return new Fahrenheit(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Fahrenheit(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Fahrenheit(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Fahrenheit(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Fahrenheit(-Value);
        }

        public static Fahrenheit operator +(Fahrenheit temperature1, double temperature2)
        {
            return (Fahrenheit)temperature1.Add(temperature2);
        }
        public static Fahrenheit operator +(Fahrenheit temperature1, Temperature temperature2)
        {
            return (Fahrenheit)temperature1.Add(temperature2);
        }
        public static Fahrenheit operator -(Fahrenheit temperature1, double temperature2)
        {
            return (Fahrenheit)temperature1.Subtract(temperature2);
        }
        public static Fahrenheit operator -(Fahrenheit temperature1, Temperature temperature2)
        {
            return (Fahrenheit)temperature1.Subtract(temperature2);
        }
        public static Fahrenheit operator -(Fahrenheit temperature)
        {
            return (Fahrenheit)temperature.Negate();
        }

        public static Fahrenheit operator *(Fahrenheit temperature, double multiplier)
        {
            return new Fahrenheit(temperature.Value * multiplier);
        }
        public static Fahrenheit operator /(Fahrenheit temperature, double divisor)
        {
            return new Fahrenheit(temperature.Value / divisor);
        }
        public static Fahrenheit operator %(Fahrenheit temperature, double modulo)
        {
            return new Fahrenheit(temperature.Value % modulo);
        }

        public override string Name { get; } = "Fahrenheit";
        public override string Symbol { get; } = "°F";
    }
}
