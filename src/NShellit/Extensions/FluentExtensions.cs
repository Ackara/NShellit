using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Acklann.NShellit.Extensions
{
    /// <summary>
    /// Provides extension methods for building <see cref="CommandInfo"/> objects.
    /// </summary>
    public static class FluentExtensions
    {
        /* Parser */

        /// <summary>
        /// Appends a new <see cref="CommandInfo"/> object to the parser.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="name">The name of the command.</param>
        ///
        /// <returns>The newly created <see cref="CommandInfo"/> object.</returns>
        public static CommandInfo DefineCommand(this Parser parser, string name)
        {
            var command = new CommandInfo(name);
            parser.Add(command);
            return command;
        }

        /// <summary>
        /// Appends a new <see cref="CommandInfo"/> object to the parser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="name">The name of the command.</param>
        ///
        /// <returns>The newly created <see cref="CommandInfo"/> object.</returns>
        public static CommandInfo<T> DefineCommand<T>(this Parser parser, string name)
        {
            var command = new CommandInfo<T>(name);
            parser.Add(command);
            return command;
        }

        /* CommandInfo */

        /// <summary>
        /// Sets the cmdlet.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="cmdlet">The cmdlet.</param>
        /// <returns>CommandInfo.</returns>
        public static CommandInfo SetCmdlet(this CommandInfo command, string cmdlet)
        {
            command.Cmdlet = cmdlet;
            return command;
        }

        /// <summary>
        /// Sets the cmdlet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="cmdlet">The cmdlet.</param>
        /// <returns>CommandInfo&lt;T&gt;.</returns>
        public static CommandInfo<T> SetCmdlet<T>(this CommandInfo<T> command, string cmdlet)
        {
            command.Cmdlet = cmdlet;
            return command;
        }

        /// <summary>
        /// Sets the alias.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="aliases">The aliases.</param>
        /// <returns>CommandInfo.</returns>
        public static CommandInfo SetAlias(this CommandInfo command, params string[] aliases)
        {
            command.Aliases = aliases;
            return command;
        }

        /// <summary>
        /// Sets the alias.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="aliases">The aliases.</param>
        /// <returns>CommandInfo&lt;T&gt;.</returns>
        public static CommandInfo<T> SetAlias<T>(this CommandInfo<T> command, params string[] aliases)
        {
            command.Aliases = aliases;
            return command;
        }

        /// <summary>
        /// Appends a link to the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="links">The links.</param>
        /// <returns>The <see cref="CommandInfo"/> object.</returns>
        public static CommandInfo AddLinks(this CommandInfo command, params string[] links)
        {
            foreach (string uri in links) command.RelatedLinks.Add(uri);
            return command;
        }

        /// <summary>
        /// Sets the description of the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="description">The description.</param>
        /// <returns>The <see cref="CommandInfo"/> object.</returns>
        public static CommandInfo SetDescription(this CommandInfo command, string description)
        {
            command.Description = description;
            return command;
        }

        /// <summary>
        /// Appends an <see cref="Example"/> to the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="syntax">The syntax.</param>
        /// <param name="description">The description.</param>
        /// <param name="forCmdlet"></param>
        /// <returns>The <see cref="CommandInfo"/> object.</returns>
        public static CommandInfo AddExample(this CommandInfo command, string syntax, string description, bool forCmdlet = false)
        {
            command.Examples.Add(new Example(syntax, description) { ForCmdlet = forCmdlet });
            return command;
        }

        /// <summary>
        /// Appends a <see cref="Argument"/> to the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <typeparam name="T">The data-type.</typeparam>
        /// <param name="command">The command.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <returns>The <see cref="Argument"/> object.</returns>
        public static Argument WithParameter<T>(this CommandInfo command, string memberName)
        {
            return WithParameter(command, memberName, typeof(T));
        }

        /// <summary>
        /// Appends a <see cref="Argument"/> to the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="dataType">The data-type.</param>
        /// <returns>The <see cref="Argument"/> object.</returns>
        public static Argument WithParameter(this CommandInfo command, string memberName, Type dataType)
        {
            var argument = new Argument(memberName, dataType) { Position = command.Count };
            command.Add(argument);
            return argument;
        }

        /// <summary>
        /// Appends a <see cref="Argument"/> to the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="dataType">The data-type.</param>
        /// <param name="kind">The kind.</param>
        /// <returns>The <see cref="Argument"/> object.</returns>
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

        /// <summary>
        /// Sets the description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="description">The description.</param>
        /// <returns>The <see cref="CommandInfo"/> object.</returns>
        public static CommandInfo<T> SetDescription<T>(this CommandInfo<T> command, string description)
        {
            command.Description = description;
            return command;
        }

        /// <summary>
        /// Appends a <see cref="Argument"/> to the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="member">The member name.</param>
        /// <returns>The <see cref="Argument"/> object.</returns>
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

        /// <summary>
        /// Appends a <see cref="Argument"/> to the <see cref="CommandInfo"/> object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="member">The member.</param>
        /// <param name="kind">The kind.</param>
        /// <returns>The <see cref="Argument"/> object.</returns>
        public static Argument<T> WithParameter<T>(this CommandInfo<T> command, Expression<Func<T, object>> member, string kind)
        {
            var argument = WithParameter(command, member);
            argument.Kind = kind;
            return argument;
        }

        /* Argument */

        /// <summary>
        /// Sets the <see cref="Argument.IsRequired"/> of the <see cref="Argument"/> object.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns>CommandInfo.</returns>
        public static CommandInfo Required(this Argument argument)
        {
            argument.IsRequired = true;
            return argument.Command;
        }

        /// <summary>
        /// Sets the description.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="description">The description.</param>
        /// <returns>Argument.</returns>
        public static Argument SetDescription(this Argument argument, string description)
        {
            argument.Description = description;
            return argument;
        }

        /// <summary>
        /// Sets the default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="value">The value.</param>
        /// <returns>CommandInfo.</returns>
        public static CommandInfo SetDefault(this Argument argument, object value)
        {
            argument.Default = value;
            return argument.Command;
        }

        /// <summary>
        /// Aliases the specified aliases.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="aliases">The aliases.</param>
        /// <returns>Argument.</returns>
        public static Argument SetAlias(this Argument argument, params string[] aliases)
        {
            argument.Aliases = aliases;
            return argument;
        }

        /* ----- */

        /// <summary>
        /// Sets the <see cref="Argument.IsRequired"/> of the <see cref="Argument"/> object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument">The argument.</param>
        /// <returns>CommandInfo&lt;T&gt;.</returns>
        public static CommandInfo<T> Required<T>(this Argument<T> argument)
        {
            argument.IsRequired = true;
            return argument.Command;
        }

        /// <summary>
        /// Sets the default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="value">The value.</param>
        /// <returns>CommandInfo&lt;T&gt;.</returns>
        public static CommandInfo<T> SetDefault<T>(this Argument<T> argument, object value)
        {
            argument.Default = value;
            return argument.Command;
        }

        /// <summary>
        /// Sets the description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="description">The description.</param>
        /// <returns>Argument&lt;T&gt;.</returns>
        public static Argument<T> SetDescription<T>(this Argument<T> argument, string description)
        {
            argument.Description = description;
            return argument;
        }

        /// <summary>
        /// Aliases the specified aliases.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="aliases">The aliases.</param>
        /// <returns>Argument&lt;T&gt;.</returns>
        public static Argument<T> SetAlias<T>(this Argument<T> argument, params string[] aliases)
        {
            argument.Aliases = aliases;
            return argument;
        }
    }
}