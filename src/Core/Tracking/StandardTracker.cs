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
using Ninject.Core.Activation;
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Tracking
{
	/// <summary>
	/// Tracks contextualized instances so they can be properly disposed of.
	/// </summary>
	public class StandardTracker : KernelComponentBase, ITracker
	{
		/*----------------------------------------------------------------------------------------*/
		#region Fields
		private readonly Dictionary<object, IContext> _contextCache = new Dictionary<object, IContext>();
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Properties
		/// <summary>
		/// Gets the number of instances currently being tracked.
		/// </summary>
		public int ReferenceCount
		{
			get { return _contextCache.Count; }
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Disposal
		/// <summary>
		/// Releases all resources held by the object.
		/// </summary>
		/// <param name="disposing"><see langword="True"/> if managed objects should be disposed, otherwise <see langword="false"/>.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && !IsDisposed)
				ReleaseAll();

			base.Dispose(disposing);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Begins tracking the specified instance.
		/// </summary>
		/// <param name="instance">The instance to track.</param>
		/// <param name="context">The context in which it was activated.</param>
		public void Track(object instance, IContext context)
		{
			lock (_contextCache)
			{
				// Make sure that we should be tracking the instance.
				if (!ShouldTrack(context))
					return;

				if (Logger.IsDebugEnabled)
					Logger.Debug("Starting to track instance resulting from {0}", Format.Context(context));

				_contextCache[instance] = context;
			}
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Releases the specified instance via the binding which was used to activate it, and
		/// stops tracking it.
		/// </summary>
		/// <param name="instance">The instance to release.</param>
		/// <returns><see langword="True"/> if the instance was being tracked, otherwise <see langword="false"/>.</returns>
		public bool Release(object instance)
		{
			lock (_contextCache)
			{
				if (!_contextCache.ContainsKey(instance))
					return false;

				IContext context = _contextCache[instance];

				DoRelease(context);
				_contextCache.Remove(instance);

				return true;
			}
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Releases the instance in the specified context via the binding which was used to activate it,
		/// and stops tracking it if it was being tracked.
		/// </summary>
		/// <param name="context">The context to release.</param>
		/// <returns><see langword="True"/> if the context was being tracked, otherwise <see langword="false"/>.</returns>
		public bool Release(IContext context)
		{
			lock (_contextCache)
			{
				DoRelease(context);

				if (!_contextCache.ContainsKey(context.Instance))
					return false;

				_contextCache.Remove(context.Instance);
				return true;
			}
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Releases all of the instances that are currently being tracked.
		/// </summary>
		public void ReleaseAll()
		{
			lock (_contextCache)
			{
				_contextCache.Values.Each(DoRelease);
				_contextCache.Clear();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Private Methods
		private void DoRelease(IContext context)
		{
			if (Logger.IsDebugEnabled)
				Logger.Debug("Releasing tracked instance resulting from {0}", Format.Context(context));

			context.Plan.Behavior.Release(context);

			if (Logger.IsDebugEnabled)
				Logger.Debug("Instance released");
		}
		/*----------------------------------------------------------------------------------------*/
		private bool ShouldTrack(IContext context)
		{
			switch (Kernel.Options.InstanceTrackingMode)
			{
				case InstanceTrackingMode.TrackEverything:
					return true;

				case InstanceTrackingMode.TrackNothing:
					return false;

				default:
					return context.Plan.Behavior.ShouldTrackInstances;
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}
