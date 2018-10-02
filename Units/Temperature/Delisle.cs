namespace TBQ.Measurements.Temperature
{
    public class Delisle : Temperature
    {
        public Delisle(double initialValue) : base(initialValue) { }
        public Delisle(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return (100 - baseValue) * 1.5;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return 100 - (unitValue / 1.5);
        }

        public override Temperature Add(double temperature)
        {
            return new Delisle(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Delisle(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Delisle(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Delisle(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Delisle(-Value);
        }

        public static Delisle operator +(Delisle temperature1, double temperature2)
        {
            return (Delisle)temperature1.Add(temperature2);
        }
        public static Delisle operator +(Delisle temperature1, Temperature temperature2)
        {
            return (Delisle)temperature1.Add(temperature2);
        }
        public static Delisle operator -(Delisle temperature1, double temperature2)
        {
            return (Delisle)temperature1.Subtract(temperature2);
        }
        public static Delisle operator -(Delisle temperature1, Temperature temperature2)
        {
            return (Delisle)temperature1.Subtract(temperature2);
        }
        public static Delisle operator -(Delisle temperature)
        {
            return (Delisle)temperature.Negate();
        }

        public static Delisle operator *(Delisle temperature, double multiplier)
        {
            return new Delisle(temperature.Value * multiplier);
        }
        public static Delisle operator /(Delisle temperature, double divisor)
        {
            return new Delisle(temperature.Value / divisor);
        }
        public static Delisle operator %(Delisle temperature, double modulo){
            return new Delisle(temperature.Value % modulo);
        }

        public override string Name
        { get; } = "Delisle";
        public override string Symbol { get; } = "°De";
    }
}
