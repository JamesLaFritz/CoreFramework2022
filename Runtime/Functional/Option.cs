#region Header
// Option.cs
// Author: James LaFritz
// Description:
// Represents an option type that may or may not contain a value.
// This struct is used with LINQ for functional programming purposes, providing a way to handle null values more elegantly.
// From Bit Cake Studio's BitStrap.
// https://assetstore.unity.com/publishers/4147
#endregion

using System;

namespace CoreFramework.Functional
{
	/// <summary>
	/// Represents an option type that may or may not contain a value.
	/// </summary>
	/// <typeparam name="TA">The type of the option.</typeparam>
	public readonly struct Option<TA>
	{
		/// <summary>
		/// Determines if the type TA is a value type.
		/// </summary>
		// ReSharper disable once StaticMemberInGenericType
		private static readonly bool IsValue;

		/// <summary>
		/// The value of the option.
		/// </summary>
		private readonly TA _value;

		/// <summary>
		/// Indicates whether the option contains a value.
		/// </summary>
		private readonly bool _isSome;

		/// <summary>
		/// Indicates whether the option is some (contains a value).
		/// </summary>
		private bool IsSome => _isSome && (IsValue || !ReferenceEquals(_value, null)) && !_value.Equals(null);

		/// <summary>
		/// Initializes a new instance of the "Option"
		/// </summary>
		static Option()
		{
			IsValue = typeof(TA).IsValueType;
		}

		/// <summary>
		/// Initializes a new instance of the "Option"
		/// </summary>
		/// <param name="value">The value of the option.</param>
		public Option(TA value)
		{
			_value = value;
			_isSome = true;
			_isSome = IsSome;
		}

		/// <summary>
		/// Implicitly converts a value to an Option.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <remarks>If the provided value is not null, creates an Option wrapping the value; otherwise, creates an empty Option.</remarks>
		public static implicit operator Option<TA>(TA value)
		{
			return new Option<TA>(value);
		}

		/// <summary>
		/// Matches the option, executing one of the provided functions based on whether the option is some or none.
		/// </summary>
		/// <typeparam name="TB">The type of the result.</typeparam>
		/// <param name="some">The function to execute if the option is some.</param>
		/// <param name="none">The function to execute if the option is none.</param>
		/// <returns>The result of executing one of the provided functions.</returns>
		/// <remarks>If the option contains a value, executes the 'some' function with the value; otherwise, executes the 'none' function.</remarks>
		public TB Match<TB>(Func<TA, TB> some, Func<TB> none)
		{
			return IsSome ? some(_value) : none();
		}

		/// <summary>
		/// Transforms the value of the option if it is some.
		/// </summary>
		/// <typeparam name="TB">The type of the transformed value.</typeparam>
		/// <param name="select">The function to transform the value.</param>
		/// <returns>An option containing the transformed value, or none if the original option was none.</returns>
		/// <remarks>If the option contains a value, applies the 'select' function to the value and returns an Option containing the result; otherwise, returns an empty Option.</remarks>
		public Option<TB> Select<TB>(Func<TA, TB> select)
		{
			return IsSome ? select(_value) : default(Option<TB>);
		}
	}
}
