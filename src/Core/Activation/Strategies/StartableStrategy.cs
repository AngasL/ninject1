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

namespace Ninject.Core.Activation.Strategies
{
	/// <summary>
	/// An activation strategy that calls <c>Start</c> and <c>Stop</c> on instances that implement
	/// <see cref="IStartable"/>.
	/// </summary>
	public class StartableStrategy : ActivationStrategyBase
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Executed after the instance is initialized.
		/// </summary>
		/// <param name="context">The activation context.</param>
		/// <returns>A value indicating whether to proceed or stop the execution of the strategy chain.</returns>
		public override StrategyResult AfterInitialize(IContext context)
		{
			var startable = context.Instance as IStartable;

			if (startable != null)
			{
				startable.Start();
				context.ShouldTrackInstance = true;
			}

			return StrategyResult.Proceed;
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Executed before the instance is destroyed.
		/// </summary>
		/// <param name="context">The activation context.</param>
		/// <returns>A value indicating whether to proceed or stop the execution of the strategy chain.</returns>
		public override StrategyResult BeforeDestroy(IContext context)
		{
			var startable = context.Instance as IStartable;

			if (startable != null)
				startable.Stop();

			return StrategyResult.Proceed;
		}
		/*----------------------------------------------------------------------------------------*/
	}
}