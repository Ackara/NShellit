using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Acklann.Poshley.Extensions
{
    public static class FluentExtensions
    {
        /* Parser */

        public static CommandInfo DefineCommand(this Parser parser, string name)
        {
            var command = new CommandInfo(name);
            parser.Add(command);
            return command;
        }

        public static CommandInfo<T> DefineCommand<T>(this Parser parser, string name)
        {
            var command = new CommandInfo<T>(name);
            parser.Add(command);
            return command;
        }

        /* CommandInfo */

        public static CommandInfo AddLinks(this CommandInfo command, params string[] links)
        {
            foreach (string uri in links) command.RelatedLinks.Add(uri);
            return command;
        }

        public static CommandInfo SetDescription(this CommandInfo command, string description)
        {
            command.Description = description;
            return command;
        }

        public static CommandInfo AddExample(this CommandInfo command, string syntax, string description)
        {
            command.Examples.Add(new Example(syntax, description));
            return command;
        }

        public static Argument WithParameter<T>(this CommandInfo command, string memberName)
        {
            return WithParameter(command, memberName, typeof(T));
        }

        public static Argument WithParameter(this CommandInfo command, string memberName, Type dataType)
        {
            var argument = new Argument(memberName, dataType) { Position = command.Count };
            command.Add(argument);
            return argument;
        }

        public static Argument WithParameter(this CommandInfo command, string memberName, Type dataType, string kind)
        {
            var argument = new Argument(memberName, dataType)
            {
                Kind = kind,
                Position = command.Count
            };
            command.Add(argument);
            return argument;
        }

        /* ***** */

        public static CommandInfo<T> SetDescription<T>(this CommandInfo<T> command, string description)
        {
            command.Description = description;
            return command;
        }

        public static Argument<T> WithParameter<T>(this CommandInfo<T> command, Expression<Func<T, object>> member)
        {
            var argument = new Argument<T>
            {
                Position = command.Count,
                Default = default(T)
            };

            if (member.Body is UnaryExpression ue)
            {
                var m = (ue.Operand as MemberExpression);
                argument.MemberName = m.Member.Name;
                argument.DataType = (m.Member.MemberType == MemberTypes.Field) ? ((FieldInfo)m.Member).FieldType : ((PropertyInfo)m.Member).PropertyType;
            }
            else if (member.Body is MemberExpression me)
            {
                argument.MemberName = me.Member.Name;
                argument.DataType = (me.Member.MemberType == MemberTypes.Field) ? ((FieldInfo)me.Member).FieldType : ((PropertyInfo)me.Member).PropertyType;
            }

            command.Add(argument);
            return argument;
        }

        public static Argument<T> WithParameter<T>(this CommandInfo<T> command, Expression<Func<T, object>> member, string kind)
        {
            var argument = WithParameter(command, member);
            argument.Kind = kind;
            return argument;
        }

        /* Argument */

        public static CommandInfo Required(this Argument argument)
        {
            argument.IsRequired = true;
            return argument.Command;
        }

        public static Argument SetDescription(this Argument argument, string text)
        {
            argument.Description = text;
            return argument;
        }

        public static CommandInfo SetDefault(this Argument argument, object value)
        {
            argument.Default = value;
            return argument.Command;
        }

        public static Argument Alias(this Argument argument, params string[] aliases)
        {
            argument.Aliases = aliases;
            return argument;
        }

        /* ----- */

        public static CommandInfo<T> Required<T>(this Argument<T> argument)
        {
            argument.IsRequired = true;
            return argument.Command;
        }

        public static CommandInfo<T> SetDefault<T>(this Argument<T> argument, object value)
        {
            argument.Default = value;
            return argument.Command;
        }

        public static Argument<T> SetDescription<T>(this Argument<T> argument, string description)
        {
            argument.Description = description;
            return argument;
        }

        public static Argument<T> Alias<T>(this Argument<T> argument, params string[] aliases)
        {
            argument.Aliases = aliases;
            return argument;
        }
    }
}