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
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Injection
{
	/// <summary>
	/// A field injector that uses dynamically-generated <see cref="Getter"/> and <see cref="Setter"/>
	/// methods for invocation.
	/// </summary>
	[Serializable]
	public class DynamicFieldInjector : InjectorBase<FieldInfo>, IFieldInjector
	{
		/*----------------------------------------------------------------------------------------*/
		#region Fields
		[NonSerialized] private Getter _getter;
		[NonSerialized] private Setter _setter;
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Creates a new DynamicFieldInjector.
		/// </summary>
		/// <param name="member">The field that will be read and written.</param>
		public DynamicFieldInjector(FieldInfo member)
			: base(member)
		{
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Gets the value of the field associated with the injector.
		/// </summary>
		/// <param name="target">The instance on which the field should be read.</param>
		/// <returns>The value stored in the field.</returns>
		public object Get(object target)
		{
			if (_getter == null)
				_getter = DynamicMethodFactory.CreateGetter(Member);

			return _getter(target);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Sets the value of the field associated with the injector.
		/// </summary>
		/// <param name="target">The instance on which the field should be written.</param>
		/// <param name="value">The value to store in the field.</param>
		public void Set(object target, object value)
		{
			if (_setter == null)
				_setter = DynamicMethodFactory.CreateSetter(Member);

			_setter(target, value);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}