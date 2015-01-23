using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSCC.Web.Awards.Classes
{
    [Serializable]
    public class AwardSearch
    {
        private const string _wildCardOperator = "%";
        private const string _fullTime = "Full-time";

        public string Keyword { get; set; }
        public string Program { get; set; }
        public string Campus { get; set; }
        public string ProgramDelivery { get; set; }
        public string ProgramYear { get; set; }
        public List<string> SpecialCriteria { get; set; }

        public string FullTimeIdentifier
        {
            get { return _fullTime; }
        }

        public string WildCardOperator
        {
            get { return _wildCardOperator; }
        }

        public AwardSearch()
        {
            this.Keyword = _wildCardOperator;
            this.Program = _wildCardOperator;
            this.Campus = _wildCardOperator;
            this.ProgramDelivery = _wildCardOperator;
            this.ProgramYear = _wildCardOperator;

            this.SpecialCriteria = new List<string>();
        }

        public bool HasCriteria()
        {
            if (!this.Keyword.Equals(_wildCardOperator) || !this.Program.Equals(_wildCardOperator)
                || !this.Campus.Equals(_wildCardOperator) || !this.ProgramDelivery.Equals(_wildCardOperator)
                || !this.ProgramYear.Equals(_wildCardOperator) || this.SpecialCriteria.Count > 0)
            {
                return true;
            }

            return false;
        }

        public void ConvertValuesForWebForm()
        {
            if (this.Keyword.Equals("%")) { this.Keyword = string.Empty; }
            if (this.Program.Equals("%")) { this.Program = string.Empty; }
            if (this.Campus.Equals("%")) { this.Campus = string.Empty; }
            if (this.ProgramDelivery.Equals("%")) { this.ProgramDelivery = string.Empty; }
            if (this.ProgramYear.Equals("%")) { this.ProgramYear = string.Empty; }
        }

        private List<string> ToList()
        {
            List<string> terms = new List<string>();

            if (!this.Keyword.Equals("%")) { terms.Add(this.Keyword); }
            if (!this.Program.Equals("%")) { terms.Add(this.Program); }
            if (!this.Campus.Equals("%")) { terms.Add(this.Campus); }
            if (!this.ProgramDelivery.Equals("%")) { terms.Add(this.ProgramDelivery); }
            if (!this.ProgramYear.Equals("%")) { terms.Add(this.ProgramYear); }
            
            if (this.SpecialCriteria.Count > 0)
            {
                foreach (string s in this.SpecialCriteria) { terms.Add(s); }
            }

            return terms;
        }

        public IDictionary<string, string> ToDictionary(bool wrapWildcard)
        {
            IDictionary<string, string> args = new Dictionary<string, string>();

            args.Add("@Keyword", FormatField(this.Keyword, wrapWildcard));
            args.Add("@Campus", FormatField(this.Campus, wrapWildcard));
            args.Add("@ProgramDelivery", this.ProgramDelivery);
            args.Add("@ProgramYear", this.ProgramYear);

            int specialCount = 1;
            foreach (string s in this.SpecialCriteria)
            {
                args.Add("@SC" + specialCount, FormatField(s, wrapWildcard));
                specialCount++;
            }

            return args;
        }

        private string FormatField(string input, bool wrapField)
        {
            if (wrapField && !input.Equals(_wildCardOperator))
            {
                return _wildCardOperator + input + _wildCardOperator;
            }

            return input;
        }
    }
}
