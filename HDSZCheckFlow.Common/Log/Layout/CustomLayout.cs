using System;
using System.Collections;

namespace HDSZCheckFlow.Common.Log.Layout
{
	/// <summary>
	/// Summary description for CustomLayout.
	/// </summary>
	public sealed class CustomLayout : log4net.Layout.PatternLayout
	{
		private static Hashtable s_globalRulesRegistry = new Hashtable(15);

		static CustomLayout()
		{
			s_globalRulesRegistry.Add("userid", typeof(HDSZCheckFlow.Common.Log.Layout.Pattern.UseridPatternConverter));
		}

		protected override log4net.Util.PatternParser CreatePatternParser(string pattern)
		{
			log4net.Util.PatternParser parser = base.CreatePatternParser (pattern);
			foreach (DictionaryEntry entry in s_globalRulesRegistry)
			{
				parser.PatternConverters[entry.Key] = entry.Value;
			}
			//base.AddConverter("userid",typeof(UseridPatternConverter));

			return parser;

		}

	}
}
