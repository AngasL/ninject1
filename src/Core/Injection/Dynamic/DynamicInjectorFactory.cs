#if !NO_LCG

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
using System.Reflection.Emit;
#endregion

namespace Ninject.Core.Injection
{
	/// <summary>
	/// Creates instances of injectors that use generated <see cref="DynamicMethod"/> objects
	/// for invocation.
	/// </summary>
	public class DynamicInjectorFactory : InjectorFactoryBase
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a new constructor injector.
		/// </summary>
		/// <param name="constructor">The constructor that the injector will invoke.</param>
		/// <returns>A new injector for the constructor.</returns>
		protected override IConstructorInjector CreateInjector(ConstructorInfo constructor)
		{
			return new DynamicConstructorInjector(constructor);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a new method injector.
		/// </summary>
		/// <param name="method">The method that the injector will invoke.</param>
		/// <returns>A new injector for the method.</returns>
		protected override IMethodInjector CreateInjector(MethodInfo method)
		{
			return new DynamicMethodInjector(method);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a new property injector.
		/// </summary>
		/// <param name="property">The property that the injector will read and write.</param>
		/// <returns>A new injector for the property.</returns>
		protected override IPropertyInjector CreateInjector(PropertyInfo property)
		{
			return new DynamicPropertyInjector(property);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a new field injector.
		/// </summary>
		/// <param name="field">The field that the injector will read and write.</param>
		/// <returns>A new injector for the field.</returns>
		protected override IFieldInjector CreateInjector(FieldInfo field)
		{
			return new DynamicFieldInjector(field);
		}
		/*----------------------------------------------------------------------------------------*/
	}
}

#endif //!NO_LCG