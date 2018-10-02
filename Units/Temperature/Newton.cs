namespace TBQ.Measurements.Temperature
{
    public class Newton : Temperature
    {
        public Newton(double initialValue) : base(initialValue) { }
        public Newton(Temperature convert) : base(convert) { }

        protected override double ConvertFromBaseValue(double baseValue)
        {
            return baseValue * 33.0 / 100.0;
        }
        protected override double ConvertToBaseValue(double unitValue)
        {
            return unitValue / 33.0 * 100.0;
        }

        public override Temperature Add(double temperature)
        {
            return new Newton(Value + temperature);
        }
        public override Temperature Add(Temperature temperature)
        {
            return new Newton(Value + ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Subtract(double temperature)
        {
            return new Newton(Value - temperature);
        }
        public override Temperature Subtract(Temperature temperature)
        {
            return new Newton(Value - ConvertFromBaseValue(temperature.BaseValue));
        }
        public override Temperature Negate()
        {
            return new Newton(-Value);
        }

        public static Newton operator +(Newton temperature1, double temperature2)
        {
            return (Newton)temperature1.Add(temperature2);
        }
        public static Newton operator +(Newton temperature1, Temperature temperature2)
        {
            return (Newton)temperature1.Add(temperature2);
        }
        public static Newton operator -(Newton temperature1, double temperature2)
        {
            return (Newton)temperature1.Subtract(temperature2);
        }
        public static Newton operator -(Newton temperature1, Temperature temperature2)
        {
            return (Newton)temperature1.Subtract(temperature2);
        }
        public static Newton operator -(Newton temperature)
        {
            return (Newton)temperature.Negate();
        }

        public static Newton operator *(Newton temperature, double multiplier)
        {
            return new Newton(temperature.Value * multiplier);
        }
        public static Newton operator /(Newton temperature, double divisor)
        {
            return new Newton(temperature.Value / divisor);
        }
        public static Newton operator %(Newton temperature, double modulo){
            return new Newton(temperature.Value % modulo);
        }

        public override string Name
        { get; } = "Newton";
        public override string Symbol { get; } = "°N";
    }
}
