using System;

namespace Acklann.NShellit.Extensions
{
	public static partial class MapExtensions
	{	
		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
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

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
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

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<T10, TResult> cb10, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<T10, TResult> cb10, Func<T11, TResult> cb11, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<T10, TResult> cb10, Func<T11, TResult> cb11, Func<T12, TResult> cb12, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<T10, TResult> cb10, Func<T11, TResult> cb11, Func<T12, TResult> cb12, Func<T13, TResult> cb13, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <typeparam name="T14">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="cb14">The delegate to invoke when command of type <typeparamref name="T14"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<T10, TResult> cb10, Func<T11, TResult> cb11, Func<T12, TResult> cb12, Func<T13, TResult> cb13, Func<T14, TResult> cb14, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o)),
				(typeof(T14), (o) => cb14((T14)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <typeparam name="T14">A command type.</typeparam>
		/// <typeparam name="T15">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="cb14">The delegate to invoke when command of type <typeparamref name="T14"/> is found.</param>
		/// <param name="cb15">The delegate to invoke when command of type <typeparamref name="T15"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<T10, TResult> cb10, Func<T11, TResult> cb11, Func<T12, TResult> cb12, Func<T13, TResult> cb13, Func<T14, TResult> cb14, Func<T15, TResult> cb15, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o)),
				(typeof(T14), (o) => cb14((T14)o)),
				(typeof(T15), (o) => cb15((T15)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <typeparam name="T14">A command type.</typeparam>
		/// <typeparam name="T15">A command type.</typeparam>
		/// <typeparam name="T16">A command type.</typeparam>
		/// <typeparam name="TResult">The type of object to return.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="cb14">The delegate to invoke when command of type <typeparamref name="T14"/> is found.</param>
		/// <param name="cb15">The delegate to invoke when command of type <typeparamref name="T15"/> is found.</param>
		/// <param name="cb16">The delegate to invoke when command of type <typeparamref name="T16"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		/// <returns>The result of the selected delegate/command.</returns>
		public static TResult Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Parser parser, string[] arguments, Func<T1, TResult> cb1, Func<T2, TResult> cb2, Func<T3, TResult> cb3, Func<T4, TResult> cb4, Func<T5, TResult> cb5, Func<T6, TResult> cb6, Func<T7, TResult> cb7, Func<T8, TResult> cb8, Func<T9, TResult> cb9, Func<T10, TResult> cb10, Func<T11, TResult> cb11, Func<T12, TResult> cb12, Func<T13, TResult> cb13, Func<T14, TResult> cb14, Func<T15, TResult> cb15, Func<T16, TResult> cb16, Func<string, TResult> errorHandler)
		{
			return Map(parser, arguments, errorHandler, new ValueTuple<Type, Func<object, TResult>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o)),
				(typeof(T14), (o) => cb14((T14)o)),
				(typeof(T15), (o) => cb15((T15)o)),
				(typeof(T16), (o) => cb16((T16)o))
			});
		}

		
		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1>(this Parser parser, string[] arguments, Action<T1> cb1, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
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

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
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

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<T10> cb10, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<T10> cb10, Action<T11> cb11, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<T10> cb10, Action<T11> cb11, Action<T12> cb12, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<T10> cb10, Action<T11> cb11, Action<T12> cb12, Action<T13> cb13, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <typeparam name="T14">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="cb14">The delegate to invoke when command of type <typeparamref name="T14"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<T10> cb10, Action<T11> cb11, Action<T12> cb12, Action<T13> cb13, Action<T14> cb14, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o)),
				(typeof(T14), (o) => cb14((T14)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <typeparam name="T14">A command type.</typeparam>
		/// <typeparam name="T15">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="cb14">The delegate to invoke when command of type <typeparamref name="T14"/> is found.</param>
		/// <param name="cb15">The delegate to invoke when command of type <typeparamref name="T15"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<T10> cb10, Action<T11> cb11, Action<T12> cb12, Action<T13> cb13, Action<T14> cb14, Action<T15> cb15, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o)),
				(typeof(T14), (o) => cb14((T14)o)),
				(typeof(T15), (o) => cb15((T15)o))
			});
		}

		/// <summary>Maps the specified <paramref name="arguments"/> to one of the specified delegates.</summary>
		/// <typeparam name="T1">A command type.</typeparam>
		/// <typeparam name="T2">A command type.</typeparam>
		/// <typeparam name="T3">A command type.</typeparam>
		/// <typeparam name="T4">A command type.</typeparam>
		/// <typeparam name="T5">A command type.</typeparam>
		/// <typeparam name="T6">A command type.</typeparam>
		/// <typeparam name="T7">A command type.</typeparam>
		/// <typeparam name="T8">A command type.</typeparam>
		/// <typeparam name="T9">A command type.</typeparam>
		/// <typeparam name="T10">A command type.</typeparam>
		/// <typeparam name="T11">A command type.</typeparam>
		/// <typeparam name="T12">A command type.</typeparam>
		/// <typeparam name="T13">A command type.</typeparam>
		/// <typeparam name="T14">A command type.</typeparam>
		/// <typeparam name="T15">A command type.</typeparam>
		/// <typeparam name="T16">A command type.</typeparam>
		/// <param name="parser">The parser.</param>
		/// <param name="arguments">The argument array.</param>
		/// <param name="cb1">The delegate to invoke when command of type <typeparamref name="T1"/> is found.</param>
		/// <param name="cb2">The delegate to invoke when command of type <typeparamref name="T2"/> is found.</param>
		/// <param name="cb3">The delegate to invoke when command of type <typeparamref name="T3"/> is found.</param>
		/// <param name="cb4">The delegate to invoke when command of type <typeparamref name="T4"/> is found.</param>
		/// <param name="cb5">The delegate to invoke when command of type <typeparamref name="T5"/> is found.</param>
		/// <param name="cb6">The delegate to invoke when command of type <typeparamref name="T6"/> is found.</param>
		/// <param name="cb7">The delegate to invoke when command of type <typeparamref name="T7"/> is found.</param>
		/// <param name="cb8">The delegate to invoke when command of type <typeparamref name="T8"/> is found.</param>
		/// <param name="cb9">The delegate to invoke when command of type <typeparamref name="T9"/> is found.</param>
		/// <param name="cb10">The delegate to invoke when command of type <typeparamref name="T10"/> is found.</param>
		/// <param name="cb11">The delegate to invoke when command of type <typeparamref name="T11"/> is found.</param>
		/// <param name="cb12">The delegate to invoke when command of type <typeparamref name="T12"/> is found.</param>
		/// <param name="cb13">The delegate to invoke when command of type <typeparamref name="T13"/> is found.</param>
		/// <param name="cb14">The delegate to invoke when command of type <typeparamref name="T14"/> is found.</param>
		/// <param name="cb15">The delegate to invoke when command of type <typeparamref name="T15"/> is found.</param>
		/// <param name="cb16">The delegate to invoke when command of type <typeparamref name="T16"/> is found.</param>
		/// <param name="errorHandler">The delegate to invoke when a parsing error occurs.</param>
		public static void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Parser parser, string[] arguments, Action<T1> cb1, Action<T2> cb2, Action<T3> cb3, Action<T4> cb4, Action<T5> cb5, Action<T6> cb6, Action<T7> cb7, Action<T8> cb8, Action<T9> cb9, Action<T10> cb10, Action<T11> cb11, Action<T12> cb12, Action<T13> cb13, Action<T14> cb14, Action<T15> cb15, Action<T16> cb16, Action<string> errorHandler)
		{
			Map(parser, arguments, errorHandler, new ValueTuple<Type, Action<object>>[]
			{
				(typeof(T1), (o) => cb1((T1)o)),
				(typeof(T2), (o) => cb2((T2)o)),
				(typeof(T3), (o) => cb3((T3)o)),
				(typeof(T4), (o) => cb4((T4)o)),
				(typeof(T5), (o) => cb5((T5)o)),
				(typeof(T6), (o) => cb6((T6)o)),
				(typeof(T7), (o) => cb7((T7)o)),
				(typeof(T8), (o) => cb8((T8)o)),
				(typeof(T9), (o) => cb9((T9)o)),
				(typeof(T10), (o) => cb10((T10)o)),
				(typeof(T11), (o) => cb11((T11)o)),
				(typeof(T12), (o) => cb12((T12)o)),
				(typeof(T13), (o) => cb13((T13)o)),
				(typeof(T14), (o) => cb14((T14)o)),
				(typeof(T15), (o) => cb15((T15)o)),
				(typeof(T16), (o) => cb16((T16)o))
			});
		}

	}
}
