namespace NoConditionals.MultipleEnums
{
    internal class DeviceToControllerAdapter
    {
        private readonly Adapter device;

        public DeviceToControllerAdapter(DeviceFamily device)
        {
            this.device = SelectAdapter(device);
        }

         internal Adapter SelectAdapter(DeviceFamily family)
        {
            switch (family)
            {
                case DeviceFamily.Hq300:
                    return new Hq300();
                case DeviceFamily.Sa700:
                    return new Sa700();
                default:
                    return new defaultAdapter();
            }
        }


        public string GetDeviceFamilyName()
        {
            return this.device.FamilyName;
        }

        public int CalculateDeviceMultiplier(int currentSensorValue)
        {
            return this.device.CalculateDeviceMultiplier(currentSensorValue);
        }
    }

    internal interface Adapter
    {
        string FamilyName { get; set; }
        int CalculateDeviceMultiplier(int currentSensorValue);

    }

    internal class Hq300 : Adapter
    {
        public readonly DeviceFamily DeviceFamily = DeviceFamily.Hq300;

        public string FamilyName { get; set; } = "Hq v2";

        public int CalculateDeviceMultiplier(int currentSensorValue) => 1;

    }

    internal class Sa700 : Adapter
    {
        public readonly DeviceFamily DeviceFamily = DeviceFamily.Sa700;
        public string FamilyName { get; set; } = "Sa v1.1";

        public int CalculateDeviceMultiplier(int currentSensorValue) => 2 * currentSensorValue;

    }

    internal class defaultAdapter : Adapter
    {
        public string FamilyName { get; set; } = null;
        public readonly DeviceFamily DeviceFamily = DeviceFamily.Unknown;

        public int CalculateDeviceMultiplier(int currentSensorValue) => 1;
    }

}
