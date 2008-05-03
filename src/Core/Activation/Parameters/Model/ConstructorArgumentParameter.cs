#region License
//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007-2008, Enkari, Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Parameters
{
	/// <summary>
	/// A transient parameter that will override the injection for a constructor argument during activation.
	/// </summary>
	public class ConstructorArgumentParameter : IParameter
	{
		/*----------------------------------------------------------------------------------------*/
		#region Properties
		/// <summary>
		/// Gets the name of the parameter.
		/// </summary>
		public string Name { get; private set; }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets the value to inject into the constructor argument.
		/// </summary>
		public object Value { get; private set; }
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ConstructorArgumentParameter"/> class.
		/// </summary>
		/// <param name="name">The name of the argument to override.</param>
		/// <param name="value">The value of the argument.</param>
		public ConstructorArgumentParameter(string name, object value)
		{
			Ensure.ArgumentNotNull(name, "name");

			Name = name;
			Value = value;
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}