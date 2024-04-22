using System.Text;
using System.Text.RegularExpressions;

namespace Assets.Scripts.LuaIntegration
{
    public class DefaultLuaScriptPreparer : ILuaScriptPreparer
    {
        public string PrepareScript(string script, InjectedInLua injectedObject)
        {
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
                script = "co = coroutine.create(function() \n" + script + "\n    end) assert(coroutine.resume(co))";

            return "function __scriptAsFunction()\n" + script + "\nend";
        }
    }
}