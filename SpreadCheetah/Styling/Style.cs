using SpreadCheetah.Helpers;

namespace SpreadCheetah.Styling;

/// <summary>
/// Represents style for one or more worksheet cells.
/// </summary>
public sealed class Style : IEquatable<Style>
{
    /// <summary>Border for the cell.</summary>
    public Border Border { get; set; } = new();

    /// <summary>Fill for the cell.</summary>
    public Fill Fill { get; set; } = new();

    /// <summary>Font for the cell's value.</summary>
    public Font Font { get; set; } = new();

    /// <summary>Format that defines how a number or <see cref="DateTime"/> cell should be displayed.</summary>
    public string? NumberFormat { get => _numberFormat; set => _numberFormat = value.WithEnsuredMaxLength(255); }
    private string? _numberFormat;

    /// <inheritdoc/>
    public bool Equals(Style? other) => other != null
        && EqualityComparer<Border>.Default.Equals(Border, other.Border)
        && EqualityComparer<Fill>.Default.Equals(Fill, other.Fill)
        && EqualityComparer<Font>.Default.Equals(Font, other.Font)
        && string.Equals(NumberFormat, other.NumberFormat, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Style other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Border, Fill, Font, NumberFormat);
}
