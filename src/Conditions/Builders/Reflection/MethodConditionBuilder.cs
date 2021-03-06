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
using System.Reflection;
#endregion

namespace Ninject.Conditions.Builders
{
	/// <summary>
	/// A condition builder that deals with <see cref="MethodInfo"/> objects. This class
	/// supports Ninject's EDSL and should generally not be used directly.
	/// </summary>
	/// <typeparam name="TRoot">The root type of the conversion chain.</typeparam>
	/// <typeparam name="TPrevious">The subject type of that the previous link in the condition chain.</typeparam>
	public class MethodConditionBuilder<TRoot, TPrevious> : MethodBaseConditionBuilder<TRoot, TPrevious, MethodInfo>
	{
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Creates a new MethodConditionBuilder.
		/// </summary>
		/// <param name="converter">A converter delegate that directly translates from the root of the condition chain to this builder's subject.</param>
		public MethodConditionBuilder(Func<TRoot, MethodInfo> converter)
			: base(converter)
		{
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a new MethodConditionBuilder.
		/// </summary>
		/// <param name="last">The previous builder in the conditional chain.</param>
		/// <param name="converter">A step converter delegate that translates from the previous step's output to this builder's subject.</param>
		public MethodConditionBuilder(IConditionBuilder<TRoot, TPrevious> last, Func<TPrevious, MethodInfo> converter)
			: base(last, converter)
		{
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region EDSL Members
		/// <summary>
		/// Continues the conditional chain, examining the return type of the method.
		/// </summary>
		public TypeConditionBuilder<TRoot, MethodInfo> ReturnType
		{
			get { return new TypeConditionBuilder<TRoot, MethodInfo>(this, s => s.ReturnType); }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Continues the conditional chain, examining the method's generic type definition.
		/// </summary>
		public MethodConditionBuilder<TRoot, MethodInfo> GenericTypeDefinition
		{
			get { return new MethodConditionBuilder<TRoot, MethodInfo>(this, s => s.GetGenericMethodDefinition()); }
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}