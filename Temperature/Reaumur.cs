namespace TBQ.Measurements.Temperature
{
    public class Reaumur : Temperature
    {
        public Reaumur(double initialValue) : base(initialValue) { }
        public Reaumur(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return baseValue * 0.8;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return unitValue / 0.8;
        }

        public override Temperature Add(double temperature)
        {
            return new Reaumur(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Reaumur(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Reaumur(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Reaumur(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Reaumur(-Value);
        }

        public static Reaumur operator +(Reaumur temperature1, double temperature2)
        {
            return (Reaumur)temperature1.Add(temperature2);
        }
        public static Reaumur operator +(Reaumur temperature1, Temperature temperature2)
        {
            return (Reaumur)temperature1.Add(temperature2);
        }
        public static Reaumur operator -(Reaumur temperature1, double temperature2)
        {
            return (Reaumur)temperature1.Subtract(temperature2);
        }
        public static Reaumur operator -(Reaumur temperature1, Temperature temperature2)
        {
            return (Reaumur)temperature1.Subtract(temperature2);
        }
        public static Reaumur operator -(Reaumur temperature)
        {
            return (Reaumur)temperature.Negate();
        }

        public static Reaumur operator *(Reaumur temperature, double multiplier)
        {
            return new Reaumur(temperature.Value * multiplier);
        }
        public static Reaumur operator /(Reaumur temperature, double divisor)
        {
            return new Reaumur(temperature.Value / divisor);
        }
        public static Reaumur operator %(Reaumur temperature, double modulo){
            return new Reaumur(temperature.Value % modulo);
        }

        public override string Name { get; } = "Réaumur";
        public override string Symbol { get; } = "°Ré";
    }
}
