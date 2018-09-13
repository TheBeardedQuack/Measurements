namespace TBQ.Measurements.Temperature
{
    public class Rankine : Temperature
    {
        public Rankine(double initialValue) : base(initialValue) { }
        public Rankine(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return (baseValue + 273.15) * 1.8;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return (unitValue / 1.8) - 273.15;
        }

        public override Temperature Add(double temperature)
        {
            return new Rankine(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Rankine(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Rankine(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Rankine(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Rankine(-Value);
        }

        public static Rankine operator +(Rankine temperature1, double temperature2)
        {
            return (Rankine)temperature1.Add(temperature2);
        }
        public static Rankine operator +(Rankine temperature1, Temperature temperature2)
        {
            return (Rankine)temperature1.Add(temperature2);
        }
        public static Rankine operator -(Rankine temperature1, double temperature2)
        {
            return (Rankine)temperature1.Subtract(temperature2);
        }
        public static Rankine operator -(Rankine temperature1, Temperature temperature2)
        {
            return (Rankine)temperature1.Subtract(temperature2);
        }
        public static Rankine operator -(Rankine temperature)
        {
            return (Rankine)temperature.Negate();
        }

        public static Rankine operator *(Rankine temperature, double multiplier)
        {
            return new Rankine(temperature.Value * multiplier);
        }
        public static Rankine operator /(Rankine temperature, double divisor)
        {
            return new Rankine(temperature.Value / divisor);
        }
        public static Rankine operator %(Rankine temperature, double modulo){
            return new Rankine(temperature.Value % modulo);
        }

        public override string Name
        { get; } = "Rankine";
        public override string Symbol { get; } = "°R";
    }
}
