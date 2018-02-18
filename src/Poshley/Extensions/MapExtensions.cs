using System;
using System.Collections.Generic;

namespace Acklann.Poshley.Extensions
{
    public static partial class MapExtensions
    {
        public static void Map<TCommand>(this Parser parser, string[] args, IEnumerable<Type> commandList, Action<TCommand> onSuccess, Action<string> onParsingError)
        {
            foreach (Type type in commandList) parser.Add(CommandInfo.ConvertFrom(type));

            if (parser.TryMap(args, out CommandInfo command, out string error))
            {
                if (command.IsInternal) { /* DO NOTHING; ITS ALREADY HANDLED. */ }
                else if (typeof(TCommand).IsAssignableFrom(command.Target) == false) throw new ArgumentException($"{command.Target.Name} is not of type {typeof(TCommand).Name}.", nameof(commandList));
                else onSuccess((TCommand)command.ToObject());
            }
            else onParsingError?.Invoke(error);
        }

        public static TResult Map<TCommand, TResult>(this Parser parser, string[] args, IEnumerable<Type> commandList, Func<TCommand, TResult> onSuccess, Func<string, TResult> onParsingError)
        {
            foreach (Type type in commandList) parser.Add(CommandInfo.ConvertFrom(type));

            if (parser.TryMap(args, out CommandInfo command, out string error))
            {
                if (command.IsInternal) return default(TResult);
                else if (typeof(TCommand).IsAssignableFrom(command.Target) == false) throw new ArgumentException($"{command.Target.Name} is not of type {typeof(TCommand).Name}.", nameof(commandList));
                else return onSuccess((TCommand)command.ToObject());
            }
            else if (onParsingError != null) return onParsingError(error);
            else return default(TResult);
        }

        internal static void Map(this Parser parser, string[] args, Action<string> onParsingError, ValueTuple<Type, Action<object>>[] commandList)
        {
            var map = new Dictionary<string, Action<object>>(commandList.Length);
            foreach ((Type Type, Action<object> Callback) command in commandList)
            {
                map.Add(command.Type.Name, command.Callback);
                parser.Add(CommandInfo.ConvertFrom(command.Type));
            }

            if (parser.TryMap(args, out CommandInfo result, out string error))
            {
                if (map.ContainsKey(result.Target.Name ?? string.Empty)) map[result.Target.Name](result.ToObject());
            }
            else onParsingError?.Invoke(error);
        }

        internal static TResult Map<TResult>(this Parser parser, string[] args, Func<string, TResult> onParsingError, ValueTuple<Type, Func<object, TResult>>[] commandList)
        {
            var map = new Dictionary<string, Func<object, TResult>>(commandList.Length);
            foreach ((Type Type, Func<object, TResult> Callback) command in commandList)
            {
                map.Add(command.Type.Name, command.Callback);
                parser.Add(CommandInfo.ConvertFrom(command.Type));
            }

            if (parser.TryMap(args, out CommandInfo result, out string error))
            {
                string key = result.Target.Name;
                if (map.ContainsKey(key)) return map[key](result.ToObject());
                else return default(TResult);
            }
            else if (onParsingError != null) return onParsingError(error);
            else return default(TResult);
        }
    }
}