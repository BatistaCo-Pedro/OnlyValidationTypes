namespace OnlyValidationTypes;

/// <summary>
/// Thin wrapper around a string that ensures it is a valid Base64 string.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringToWrapperJsonConverter<Base64String>))]
public partial record Base64String : NonEmptyString, IStringWrapper<Base64String>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentException"></exception>
    public Base64String(string value)
        : base(value)
    {
        if (!Base64.IsValid(value))
        {
            throw new ArgumentException("The value is not a valid Base64 string.");
        }
    }

    public new static Base64String Create(string value) => new(value);
}