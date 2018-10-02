namespace TBQ.Measurements.Temperature
{
    public class Kelvin : Temperature
    {
        public Kelvin(double initialValue = 0.0) : base(initialValue) { }
        public Kelvin(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return baseValue + 273.15;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return unitValue - 273.15;
        }

        public override Temperature Add(double temperature)
        {
            return new Kelvin(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Kelvin(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Kelvin(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Kelvin(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Kelvin(-Value);
        }

        public static Kelvin operator +(Kelvin temperature1, double temperature2)
        {
            return (Kelvin)temperature1.Add(temperature2);
        }
        public static Kelvin operator +(Kelvin temperature1, Temperature temperature2)
        {
            return (Kelvin)temperature1.Add(temperature2);
        }
        public static Kelvin operator -(Kelvin temperature1, double temperature2)
        {
            return (Kelvin)temperature1.Subtract(temperature2);
        }
        public static Kelvin operator -(Kelvin temperature1, Temperature temperature2)
        {
            return (Kelvin)temperature1.Subtract(temperature2);
        }
        public static Kelvin operator -(Kelvin temperature)
        {
            return (Kelvin)temperature.Negate();
        }
        
        public static Kelvin operator *(Kelvin temperature, double multiplier)
        {
            return new Kelvin(temperature.Value * multiplier);
        }
        public static Kelvin operator /(Kelvin temperature, double divisor)
        {
            return new Kelvin(temperature.Value / divisor);
        }
        public static Kelvin operator %(Kelvin temperature, double modulo)
        {
            return new Kelvin(temperature.Value % modulo);
        }

        public override string Name { get; } = "Kelvin";
        public override string Symbol { get; } = "K";
    }
}
