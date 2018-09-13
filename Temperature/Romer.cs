namespace TBQ.Measurements.Temperature
{
    public class Romer : Temperature
    {
        public Romer(double initialValue) : base(initialValue) { }
        public Romer(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return (baseValue * 21.0 / 40.0) + 7.5;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return (unitValue - 7.5) / 21.0 * 40.0;
        }

        public override Temperature Add(double temperature)
        {
            return new Romer(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Romer(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Romer(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Romer(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Romer(-Value);
        }

        public static Romer operator +(Romer temperature1, double temperature2)
        {
            return (Romer)temperature1.Add(temperature2);
        }
        public static Romer operator +(Romer temperature1, Temperature temperature2)
        {
            return (Romer)temperature1.Add(temperature2);
        }
        public static Romer operator -(Romer temperature1, double temperature2)
        {
            return (Romer)temperature1.Subtract(temperature2);
        }
        public static Romer operator -(Romer temperature1, Temperature temperature2)
        {
            return (Romer)temperature1.Subtract(temperature2);
        }
        public static Romer operator -(Romer temperature)
        {
            return (Romer)temperature.Negate();
        }

        public static Romer operator *(Romer temperature, double multiplier)
        {
            return new Romer(temperature.Value * multiplier);
        }
        public static Romer operator /(Romer temperature, double divisor)
        {
            return new Romer(temperature.Value / divisor);
        }
        public static Romer operator %(Romer temperature, double modulo){
            return new Romer(temperature.Value % modulo);
        }

        public override string Name { get; } = "Rømer";
        public override string Symbol { get; } = "°Rø";
    }
}
