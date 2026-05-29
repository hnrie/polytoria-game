// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;

namespace Polytoria.Attributes;

/// <summary>
/// Specifies a custom type to use when loading a subview for this class.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class CustomSubviewAttribute : Attribute
{
	public Type TargetType { get; }

	public CustomSubviewAttribute(Type targetType)
	{
		TargetType = targetType;
	}
}
