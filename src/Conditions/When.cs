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
using Ninject.Core;
using Ninject.Core.Activation;
using Ninject.Conditions.Builders;
using Ninject.Core.Interception;
#endregion

namespace Ninject.Conditions
{
	/// <summary>
	/// The root type for Ninject's EDSL (embedded domain-specific language). This is most
	/// commonly used from within <see cref="StandardModule"/>s.
	/// </summary>
	/// <remarks>
	/// This type can be used as a shortcut to creating complex conditional statements that
	/// examine <see cref="IContext"/> objects. This type can also be extended to customize
	/// the EDSL.
	/// </remarks>
	public static partial class When
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Begins a conditional chain that examines an activation context.
		/// </summary>
		public static ContextConditionBuilder<IContext, IContext> Context
		{
			get { return new ContextConditionBuilder<IContext, IContext>(ctx => ctx); }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Begins a conditional chain that examines an intercepted message call.
		/// </summary>
		public static RequestConditionBuilder<IRequest, IRequest> Request
		{
			get { return new RequestConditionBuilder<IRequest, IRequest>(r => r); }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Begins a conditional chain that examines a constructor injection candidate.
		/// </summary>
		public static ConstructorConditionBuilder<ConstructorInfo, ConstructorInfo> Constructor
		{
			get { return new ConstructorConditionBuilder<ConstructorInfo, ConstructorInfo>(c => c); }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Begins a conditional chain that examines a method injection candidate.
		/// </summary>
		public static MethodConditionBuilder<MethodInfo, MethodInfo> Method
		{
			get { return new MethodConditionBuilder<MethodInfo, MethodInfo>(m => m); }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Begins a conditional chain that examines a property injection candidate.
		/// </summary>
		public static PropertyConditionBuilder<PropertyInfo, PropertyInfo> Property
		{
			get { return new PropertyConditionBuilder<PropertyInfo, PropertyInfo>(p => p); }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Begins a conditional chain that examines a field injection candidate.
		/// </summary>
		public static FieldConditionBuilder<FieldInfo, FieldInfo> Field
		{
			get { return new FieldConditionBuilder<FieldInfo, FieldInfo>(f => f); }
		}
		/*----------------------------------------------------------------------------------------*/
	}
}
