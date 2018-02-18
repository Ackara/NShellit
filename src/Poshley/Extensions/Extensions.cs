using System;

namespace Acklann.Poshley.Extensions
{
	public static partial class MapExtensions
	{	
		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, T2, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, T2, T3, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, T2, T3, T4, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T6">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="cb6">The callback method to invoke when <typeparamref name="T6"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T6">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T7">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="cb6">The callback method to invoke when <typeparamref name="T6"/> is selected.</param>
		/// <param name="cb7">The callback method to invoke when <typeparamref name="T7"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T6">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T7">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T8">The type of command to add to the collection.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="cb6">The callback method to invoke when <typeparamref name="T6"/> is selected.</param>
		/// <param name="cb7">The callback method to invoke when <typeparamref name="T7"/> is selected.</param>
		/// <param name="cb8">The callback method to invoke when <typeparamref name="T8"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		/// <returns>The result of the selected command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Parser parser, string[] args, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<string, TResult> onParsingError)
		{
			return Map(parser, args, onParsingError, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o))
			});
		}

		
		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1>(this Parser parser, string[] args, Action<T1> cb1, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1, T2>(this Parser parser, string[] args, Action<T1> cb1, Action<T2> cb2, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1, T2, T3>(this Parser parser, string[] args, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1, T2, T3, T4>(this Parser parser, string[] args, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1, T2, T3, T4, T5>(this Parser parser, string[] args, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T6">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="cb6">The callback method to invoke when <typeparamref name="T6"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1, T2, T3, T4, T5, T6>(this Parser parser, string[] args, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T6">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T7">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="cb6">The callback method to invoke when <typeparamref name="T6"/> is selected.</param>
		/// <param name="cb7">The callback method to invoke when <typeparamref name="T7"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7>(this Parser parser, string[] args, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o))
			});
		}

		/// <summary>blah blah</summary>
		/// <typeparam name="T1">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T2">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T3">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T4">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T5">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T6">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T7">The type of command to add to the collection.</typeparam>
		/// <typeparam name="T8">The type of command to add to the collection.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="args">The user argument array.</param>
		/// <param name="cb1">The callback method to invoke when <typeparamref name="T1"/> is selected.</param>
		/// <param name="cb2">The callback method to invoke when <typeparamref name="T2"/> is selected.</param>
		/// <param name="cb3">The callback method to invoke when <typeparamref name="T3"/> is selected.</param>
		/// <param name="cb4">The callback method to invoke when <typeparamref name="T4"/> is selected.</param>
		/// <param name="cb5">The callback method to invoke when <typeparamref name="T5"/> is selected.</param>
		/// <param name="cb6">The callback method to invoke when <typeparamref name="T6"/> is selected.</param>
		/// <param name="cb7">The callback method to invoke when <typeparamref name="T7"/> is selected.</param>
		/// <param name="cb8">The callback method to invoke when <typeparamref name="T8"/> is selected.</param>
		/// <param name="onParsingError">The method to invoke when the user passes invalid arguments.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8>(this Parser parser, string[] args, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<string> onParsingError)
		{
			Map(parser, args, onParsingError, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o))
			});
		}

	}
}
