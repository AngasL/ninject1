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
using Ninject.Core.Planning.Directives;
#endregion

namespace Ninject.Core.Activation
{
	/// <summary>
	/// A baseline definition of a provider that calls an injection constructor to create instances.
	/// </summary>
	public abstract class InjectionProviderBase : ProviderBase
	{
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="InjectionProviderBase"/> class.
		/// </summary>
		/// <param name="prototype">The prototype that the provider will use to create instances.</param>
		protected InjectionProviderBase(Type prototype)
			: base(prototype)
		{
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Creates instances of types by calling a constructor via a lightweight dynamic method,
		/// resolving and injecting constructor arguments as necessary.
		/// </summary>
		/// <param name="context">The context in which the activation is occurring.</param>
		/// <returns>The instance of the type.</returns>
		public override object Create(IContext context)
		{
			Ensure.ArgumentNotNull(context, "context");
			Ensure.NotDisposed(this);

			return CallInjectionConstructor(context);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Protected Methods
		/// <summary>
		/// Calls the injection constructor defined in the context's activation plan, and returns
		/// the resulting object.
		/// </summary>
		/// <param name="context">The context in which the activation is occurring.</param>
		/// <returns>The instance of the type.</returns>
		protected virtual object CallInjectionConstructor(IContext context)
		{
			ConstructorInjectionDirective directive = context.Plan.Directives.GetOne<ConstructorInjectionDirective>();

			if (directive == null)
				throw new ActivationException(ExceptionFormatter.NoConstructorsAvailable(context));

			// Resolve the dependency markers in the constructor injection directive.
			object[] arguments = ResolveConstructorArguments(context, directive);

			// Trigger the directive's injector to create the instance.
			return directive.Injector.Invoke(arguments);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Resolves the arguments for the constructor defined by the specified constructor injection
		/// directive.
		/// </summary>
		/// <param name="context">The context in which the activation is occurring.</param>
		/// <param name="directive">The directive describing the injection constructor.</param>
		/// <returns>An array of arguments that can be passed to the constructor.</returns>
		protected virtual object[] ResolveConstructorArguments(IContext context, ConstructorInjectionDirective directive)
		{
			object[] arguments = new object[directive.Arguments.Count];

			int index = 0;
			foreach (Argument argument in directive.Arguments)
			{
				if (context.Binding.InlineArguments.ContainsKey(argument.Target.Name))
				{
					// If an inline argument has been specified, it overrides any injection.
					object inlineArgument = context.Binding.InlineArguments[argument.Target.Name];

					// See if we can just inject the argument directly.
					if (!argument.Target.Type.IsAssignableFrom(inlineArgument.GetType()))
					{
						try
						{
							// Try to convert the inline argument to the expected type.
							inlineArgument = Convert.ChangeType(inlineArgument, argument.Target.Type);
						}
						catch (InvalidCastException)
						{
							// If the conversion failed, we're out of options, so throw an ActivationException.
							throw new ActivationException(ExceptionFormatter.InvalidInlineArgument(argument, inlineArgument, context));
						}
					}

					arguments[index] = inlineArgument;
				}
				else
				{
					// Create a new context in which the parameter's value will be activated.
					IContext injectionContext = context.CreateChild(directive.Member,
						argument.Target, argument.Optional);

					// Resolve the value to inject for the parameter.
					arguments[index] = argument.Resolver.Resolve(context, injectionContext);
				}

				index++;
			}

			return arguments;
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}