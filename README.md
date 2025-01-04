# Only Validations Type

Contains small, easy to use types, which cover the most common use cases for validations.

The main goal with these types is to assure that the data is valid, 
and that the data is in the correct format.
They might also include some other functionality for improved ease of use.

## Current Types

- [`NonEmptyString`](#nonemptystring)
- [`Base64String`](#base64string)
- [`HtmlString`](#htmlstring)
- [`CultureCode`](#culturecode)


## NonEmptyString

This type ensures that a string is not empty, whitespace or null.

```csharp
// Constructor
var validString = new NonEmptyString("Hello World");
var invalidString = new NonEmptyString(" "); // Throws

// Factory method
var validString = NonEmptyString.Create("Hello World");
var invalidString = NonEmptyString.Create(" "); // Throws

// Implicit conversion
NonEmtpyString validString = "Hello World";
NonEmptyString invalidString = " "; // Throws
```

## Base64String

```csharp
// Constructor
var validBase64 = new Base64String("SGVsbG8gV29ybGQ=");
var invalidBase64 = new Base64String(" "); // Throws
var alsoInvalidBase64 = new Base64String("Hello World"); // Throws

// Factory method
var validBase64 = Base64String.Create("SGVsbG8gV29ybGQ=");
var invalidBase64 = Base64String.Create(" "); // Throws
var alsoInvalidBase64 = Base64String.Create("Hello World"); // Throws

// Implicit conversion
Base64String validBase64 = "SGVsbG8gV29ybGQ=";
Base64String invalidBase64 = " "; // Throws
Base64String alsoInvalidBase64 = "Hello World"; // Throws
```

## HtmlString

```csharp
// Constructor
var validHtml = new HtmlString("<p>Hello World</p>");
var invalidHtml = new HtmlString(" "); // Throws

... you get the idea
    
// HtmlString contains a method to strip all the html
var plainText = validHtml.StripHtml(); // "Hello World"

// HtmlString contains a property for SanitizationInfo
var info = validHtml.SanitizationInfo;
```

```csharp
public readonly partial record struct SanitizationInfo(
    ImmutableArray<RemovedElementInfo> RemovedElements
);

public readonly partial record struct RemovedElementInfo(
    string TagName,
    string? ElementName,
    string Reason,
    string? Position
);
```

## CultureCode

```csharp
// Constructor
var validCultureCode = new CultureCode("en-US");
var invalidCultureCode = new CultureCode(" "); // Throws
var alsoInvalidCultureCode = new CultureCode("Hello World"); // Throws

...
    
// CultureCode contains a property for CultureInfo
var cultureInfo = validCultureCode.CultureInfo; // en-Us CultureInfo
```