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
using Ninject.Core;
using Ninject.Core.Activation;
using Ninject.Core.Binding;
using Ninject.Core.Infrastructure;
using Ninject.Core.Logging;
using Ninject.Core.Planning.Targets;
#endregion

namespace Ninject.Core.Resolution
{
	/// <summary>
	/// A <see cref="IResolverFactoryPlugin"/> that creates <see cref="LoggerResolver"/>s if
	/// the target is an child of <see cref="ILogger"/>.
	/// </summary>
	public class LoggerResolverPlugin : IResolverFactoryPlugin
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Returns a value indicating whether this factory can create a resolver for the specified
		/// injection target.
		/// </summary>
		/// <param name="target">The injection target in question.</param>
		/// <returns><see langword="True"/> if the factory can create resolvers, otherwise, <see langword="false"/>.</returns>
		public bool Matches(ITarget target)
		{
			return typeof(ILogger).IsAssignableFrom(target.Type);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a dependency resolver for the specified binding and target.
		/// </summary>
		/// <param name="binding">The binding requesting the injection.</param>
		/// <param name="target">The target whose value the resolver will resolve.</param>
		/// <returns>The newly-created dependency resolver.</returns>
		public IResolver Create(IBinding binding, ITarget target)
		{
			return new LoggerResolver(target);
		}
		/*----------------------------------------------------------------------------------------*/
	}
}