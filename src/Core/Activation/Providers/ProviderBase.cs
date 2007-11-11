#region License
//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007, Enkari, Ltd.
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

namespace Ninject.Core.Activation
{
	/// <summary>
	/// A baseline definition of a provider.
	/// </summary>
	public abstract class ProviderBase : DisposableObject, IProvider
	{
		/*----------------------------------------------------------------------------------------*/
		#region Fields
		private Type _prototype;
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Properties
		/// <summary>
		/// Gets the prototype of the provider. This is almost always the type that is returned,
		/// except in the case of generic argument inference.
		/// </summary>
		public Type Prototype
		{
			get { return _prototype; }
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Disposal
		/// <summary>
		/// Releases all resources currently held by the object.
		/// </summary>
		/// <param name="disposing"><see langword="True"/> if managed objects should be disposed, otherwise <see langword="false"/>.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && !IsDisposed)
				_prototype = null;

			base.Dispose(disposing);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ProviderBase"/> class.
		/// </summary>
		/// <param name="prototype">The prototype that the provider will use to create instances.</param>
		protected ProviderBase(Type prototype)
		{
			Ensure.ArgumentNotNull(prototype, "prototype");
			_prototype = prototype;
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Determines whether the provider is compatible with the specified context.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns><see langword="True"/> if the provider is compatible, otherwise <see langword="false"/>.</returns>
		public virtual bool IsCompatibleWith(IContext context)
		{
			return context.Service.IsAssignableFrom(_prototype);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets the concrete implementation type that will be instantiated for the provided context.
		/// </summary>
		/// <param name="context">The context in which the activation is occurring.</param>
		/// <returns>The concrete type that will be instantiated.</returns>
		public abstract Type GetImplementationType(IContext context);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates instances of types by calling a constructor via a lightweight dynamic method,
		/// resolving and injecting constructor arguments as necessary.
		/// </summary>
		/// <param name="context">The context in which the activation is occurring.</param>
		/// <returns>The instance of the type.</returns>
		public abstract object Create(IContext context);
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}