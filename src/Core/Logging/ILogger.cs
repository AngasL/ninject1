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
#endregion

namespace Ninject.Core.Logging
{
	/// <summary>
	/// Logs messages to a customizable sink.
	/// </summary>
	public interface ILogger
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets the type associated with the logger.
		/// </summary>
		Type Type { get; }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Debug severity should be logged.
		/// </summary>
		bool IsDebugEnabled { get; }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Info severity should be logged.
		/// </summary>
		bool IsInfoEnabled { get; }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Warn severity should be logged.
		/// </summary>
		bool IsWarnEnabled { get; }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Error severity should be logged.
		/// </summary>
		bool IsErrorEnabled { get; }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Fatal severity should be logged.
		/// </summary>
		bool IsFatalEnabled { get; }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Debug severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Debug(string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Debug severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Debug(Exception exception, string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Info severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Info(string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Info severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Info(Exception exception, string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Warn severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Warn(string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Warn severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Warn(Exception exception, string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Error severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Error(string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Error severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Error(Exception exception, string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Fatal severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Fatal(string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Fatal severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		void Fatal(Exception exception, string format, params object[] args);
		/*----------------------------------------------------------------------------------------*/
	}
}