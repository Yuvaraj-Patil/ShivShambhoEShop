﻿using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace ShivShambho_eShop.ClientApp.Converters;

public class FirstValidationErrorConverter : BaseConverterOneWay<IEnumerable<string>, string>
{
    public override string DefaultConvertReturnValue { get; set; } = string.Empty;

    public override string ConvertFrom(IEnumerable<string> value, CultureInfo culture)
    {
        return value?.FirstOrDefault() ?? DefaultConvertReturnValue;
    }
}
