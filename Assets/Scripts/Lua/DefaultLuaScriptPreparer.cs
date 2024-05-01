using System.Text;
using System.Text.RegularExpressions;

namespace Assets.Scripts.LuaIntegration
{
    public class DefaultLuaScriptPreparer : ILuaScriptPreparer
    {
        public string PrepareScript(string script, InjectableInLua injectedObject)
        {
            StringBuilder scriptBuilder = new StringBuilder();

            scriptBuilder.AppendLine("__isScriptRunningRESERVEDVALUE = true")
                .AppendLine(script)
                .AppendLine("__isScriptRunningRESERVEDVALUE = false");


            StringBuilder regexBuilder = new StringBuilder(@"(");

            bool addSeparator = false;
            foreach (LuaCsCommand command in injectedObject.Commands.Values)
            {
                if (command.IsAsync)
                    if (!addSeparator)
                        regexBuilder.Append(command.CallName);
                    else
                        regexBuilder.Append("|").Append(command.CallName);
            }
            regexBuilder.Append(@")");

            Regex asyncCommandsRegex = new Regex(regexBuilder.ToString());


            if (asyncCommandsRegex.IsMatch(script))
                scriptBuilder.Insert(0, "co = coroutine.create(function() ")
                    .AppendLine("end) assert(coroutine.resume(co))");

            return scriptBuilder.Insert(0, "function __scriptAsFunction()")
                .AppendLine("end").ToString();
        }
    }
}