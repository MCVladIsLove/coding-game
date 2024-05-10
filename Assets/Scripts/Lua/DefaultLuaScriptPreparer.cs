using System.Text;
using System.Text.RegularExpressions;
using Assets.Scripts.StringConstants;

namespace Assets.Scripts.LuaIntegration
{
    public class DefaultLuaScriptPreparer : ILuaScriptPreparer
    {
        public string PrepareScript(string script, InjectableInLua injectedObject)
        {
            StringBuilder scriptBuilder = new StringBuilder();

            scriptBuilder.Append(LuaScriptReservedMemberNames.IS_SCRIPT_RUNNING).AppendLine(" = true")
                .AppendLine(script)
                .Append(LuaScriptReservedMemberNames.IS_SCRIPT_RUNNING).AppendLine(" = false");
            
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
            Regex loopsRegex = new Regex(@"(while|for|repeat)");
            Regex loopStartRegex = new Regex(@"(while\s.*?do|for\s.*?do|repeat)", RegexOptions.Singleline);

            if (asyncCommandsRegex.IsMatch(script) || loopsRegex.IsMatch(script))
                scriptBuilder.Insert(0, $"{LuaScriptReservedMemberNames.MAIN_COROUTINE} = {LuaScriptReservedMemberNames.COROUTINE_TABLE}.create(function() ")
                    .AppendLine($"end) assert({LuaScriptReservedMemberNames.COROUTINE_TABLE}.resume({LuaScriptReservedMemberNames.MAIN_COROUTINE}))");

            scriptBuilder.Insert(0, $"function {LuaScriptReservedMemberNames.SCRIPT_AS_FUNCTION}()")
                .AppendLine("end");

            return loopStartRegex.Replace(scriptBuilder.ToString(),
                match => match.Value + $" \n{LuaScriptReservedMemberNames.SUSPEND_COROUTINE_ONE_FRAME}({LuaScriptReservedMemberNames.MAIN_COROUTINE})\n");
        }
    }
}