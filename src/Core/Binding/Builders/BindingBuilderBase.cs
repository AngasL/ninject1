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
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Binding
{
	/// <summary>
	/// The baseline definition of a binding builder.
	/// </summary>
	public abstract class BindingBuilderBase : DisposableObject, IBindingBuilder
	{
		/*----------------------------------------------------------------------------------------*/
		#region Properties
		/// <summary>
		/// Gets the binding that the builder should manipulate.
		/// </summary>
		public IBinding Binding { get; protected set; }
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BindingBuilderBase"/> class.
		/// </summary>
		/// <param name="binding">The binding that the builder should manipulate.</param>
		protected BindingBuilderBase(IBinding binding)
		{
			Ensure.ArgumentNotNull(binding, "binding");
			Binding = binding;
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}