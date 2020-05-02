using Pets.Core.Application.Client;
using System;

namespace Pets.Core
{
    public class EnumValue
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public static EnumValue GetValue(Enum obj)
        {
            Type enumType = obj.GetType();

            if (!Enum.IsDefined(enumType, obj))
                return null;

            return new EnumValue
            {
                Name = EnumExtensions.GetEnumDescription(obj),
                Value = Convert.ToInt32(obj)
            };
        }
    }
}
