﻿using System.Collections;
using System.Globalization;
using System.Text;

using log4net.Core;

using Seq.Client.Log4Net;

namespace WebApplication1.log4net
{
    public class LoggingEventFormatter
    {
        static readonly IDictionary<Type, Action<object, TextWriter>> LiteralWriters;
        const uint Log4NetEventType = 0x00010649;

        static LoggingEventFormatter()
        {
            LiteralWriters = new Dictionary<Type, Action<object, TextWriter>>
            {
                { typeof(bool), (v, w) => WriteBoolean((bool)v, w) },
                { typeof(char), (v, w) => WriteString(((char)v).ToString(CultureInfo.InvariantCulture), w) },
                { typeof(byte), WriteToString },
                { typeof(sbyte), WriteToString },
                { typeof(short), WriteToString },
                { typeof(ushort), WriteToString },
                { typeof(int), WriteToString },
                { typeof(uint), WriteToString },
                { typeof(long), WriteToString },
                { typeof(ulong), WriteToString },
                { typeof(float), WriteToString },
                { typeof(double), WriteToString },
                { typeof(decimal), WriteToString },
                { typeof(string), (v, w) => WriteString((string)v, w) },
                { typeof(DateTime), (v, w) => WriteDateTime((DateTime)v, w) },
                { typeof(DateTimeOffset), (v, w) => WriteOffset((DateTimeOffset)v, w) },
            };
        }

        public static void ToJson(LoggingEvent[] events, StringWriter payload, List<AppenderParameter> mParameters)
        {
            var delim = "";
            foreach (var loggingEvent in events)
            {
                payload.Write(delim);
                delim = "\n";
                ToJson(loggingEvent, payload, mParameters);
            }
        }

        static void ToJson(LoggingEvent loggingEvent, StringWriter payload, IEnumerable<AppenderParameter> parameters)
        {
            payload.Write("{");

            var delim = "";
            WriteJsonProperty("@t", loggingEvent.TimeStamp, ref delim, payload);
            WriteJsonProperty("@l", loggingEvent.Level.Name, ref delim, payload);
            WriteJsonProperty("@i", Log4NetEventType, ref delim, payload);
            WriteJsonProperty("@m", loggingEvent.RenderedMessage, ref delim, payload);

            if (loggingEvent.ExceptionObject != null)
                WriteJsonProperty("@x", loggingEvent.ExceptionObject, ref delim, payload);

            var seenKeys = new HashSet<string>();

            foreach (var property in parameters)
            {
                var stringValue = property.Layout.Format(loggingEvent);
                WriteJsonProperty(property.ParameterName, stringValue, ref delim, payload);
            }

            WriteJsonProperty(SanitizeKey("log4net:Logger"), loggingEvent.LoggerName, ref delim, payload);

            foreach (DictionaryEntry property in loggingEvent.GetProperties())
            {
                var sanitizedKey = SanitizeKey(property.Key.ToString());
                if (seenKeys.Contains(sanitizedKey))
                    continue;

                seenKeys.Add(sanitizedKey);
                WriteJsonProperty(sanitizedKey, property.Value, ref delim, payload);
            }
            payload.Write("}");
        }

        static string SanitizeKey(string key)
        {
            return new string(key.Replace(":", "_").Where(c => c == '_' || char.IsLetterOrDigit(c)).ToArray());
        }


        static void WriteJsonProperty(string name, object value, ref string precedingDelimiter, TextWriter output)
        {
            output.Write(precedingDelimiter);
            WritePropertyName(name, output);
            WriteLiteral(value, output);
            precedingDelimiter = ",";
        }

        static void WritePropertyName(string name, TextWriter output)
        {
            output.Write("\"");
            output.Write(name);
            output.Write("\":");
        }

        static void WriteLiteral(object value, TextWriter output)
        {
            if (value == null)
            {
                output.Write("null");
                return;
            }

            // Attempt to convert the object (if a string) to it's literal type (int/decimal/date)
            value = GetValueAsLiteral(value);

            if (LiteralWriters.TryGetValue(value.GetType(), out var writer))
            {
                writer(value, output);
                return;
            }

            WriteString(value.ToString(), output);
        }

        static void WriteToString(object number, TextWriter output)
        {
            output.Write(number.ToString());
        }

        static void WriteBoolean(bool value, TextWriter output)
        {
            output.Write(value ? "true" : "false");
        }

        static void WriteOffset(DateTimeOffset value, TextWriter output)
        {
            output.Write("\"");
            output.Write(value.ToString("o"));
            output.Write("\"");
        }

        static void WriteDateTime(DateTime value, TextWriter output)
        {
            output.Write("\"");
            output.Write(value.ToString("o"));
            output.Write("\"");
        }

        static void WriteString(string value, TextWriter output)
        {
            var content = Escape(value);
            output.Write("\"");
            output.Write(content);
            output.Write("\"");
        }

        static string Escape(string s)
        {
            if (s == null) return null;

            StringBuilder escapedResult = null;
            var cleanSegmentStart = 0;
            for (var i = 0; i < s.Length; ++i)
            {
                var c = s[i];
                if (c < (char)32 || c == '\\' || c == '"')
                {

                    if (escapedResult == null)
                        escapedResult = new StringBuilder();

                    escapedResult.Append(s.Substring(cleanSegmentStart, i - cleanSegmentStart));
                    cleanSegmentStart = i + 1;

                    switch (c)
                    {
                        case '"':
                            {
                                escapedResult.Append("\\\"");
                                break;
                            }
                        case '\\':
                            {
                                escapedResult.Append("\\\\");
                                break;
                            }
                        case '\n':
                            {
                                escapedResult.Append("\\n");
                                break;
                            }
                        case '\r':
                            {
                                escapedResult.Append("\\r");
                                break;
                            }
                        case '\f':
                            {
                                escapedResult.Append("\\f");
                                break;
                            }
                        case '\t':
                            {
                                escapedResult.Append("\\t");
                                break;
                            }
                        default:
                            {
                                escapedResult.Append("\\u");
                                escapedResult.Append(((int)c).ToString("X4"));
                                break;
                            }
                    }
                }
            }

            if (escapedResult != null)
            {
                if (cleanSegmentStart != s.Length)
                    escapedResult.Append(s.Substring(cleanSegmentStart));

                return escapedResult.ToString();
            }

            return s;
        }

        /// <summary>
        /// GetValueAsLiteral attempts to transform the (string) object into a literal type prior to json serialization.
        /// </summary>
        /// <param name="value">The value to be transformed/parsed.</param>
        /// <returns>A translated representation of the literal object type instead of a string.</returns>
        static object GetValueAsLiteral(object value)
        {
            if (value is string str)
            {
                // All number literals are serialized as a decimal so ignore other number types.
                if (decimal.TryParse(str, out var decimalBuffer))
                    return decimalBuffer;

                // Standardize on dates if/when possible.
                if (DateTime.TryParse(str, out var dateBuffer))
                    return dateBuffer;
            }

            return value;
        }
    }
}
