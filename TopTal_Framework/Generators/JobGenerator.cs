using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace TopTal_Framework.Generators
{
    public class JobGenerator
    {
        public static Job LastGeneratedJob;
        private static List<Skill> _skills = new List<Skill>();
        private static Log log = Log.Instance;

        public static void Initialize()
        {
            LastGeneratedJob = null;

            #region Init table of skills
            //(I have used initialisation in this way because I do not know the all values. It is better to keep such data in local db or xml file. As for test problem it is enough)
            _skills.Add(new Skill() { Name = "PHP", SkillType = Skill.Type.Languages, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "C#", SkillType = Skill.Type.Languages, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Java", SkillType = Skill.Type.Languages, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "SQL", SkillType = Skill.Type.Languages, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Ruby", SkillType = Skill.Type.Languages, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Python", SkillType = Skill.Type.Languages, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Django", SkillType = Skill.Type.Frameworks, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "CakePHP", SkillType = Skill.Type.Frameworks, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Ruby on Rails", SkillType = Skill.Type.Frameworks, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Selenium", SkillType = Skill.Type.Frameworks, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Facebook API", SkillType = Skill.Type.Libraries_APIs, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Selenium WebDriver", SkillType = Skill.Type.Libraries_APIs, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "jQuery", SkillType = Skill.Type.Libraries_APIs, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "ASP", SkillType = Skill.Type.Frameworks, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Eclipse", SkillType = Skill.Type.Tools, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Visual Studio", SkillType = Skill.Type.Tools, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Watir", SkillType = Skill.Type.Tools, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "WatiN", SkillType = Skill.Type.Tools, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Agile software development", SkillType = Skill.Type.Paradigms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Concurrent Programming", SkillType = Skill.Type.Paradigms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Functional programming", SkillType = Skill.Type.Paradigms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = ".NET", SkillType = Skill.Type.Platforms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Android", SkillType = Skill.Type.Platforms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "iOS", SkillType = Skill.Type.Platforms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Solaris", SkillType = Skill.Type.Platforms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Windows", SkillType = Skill.Type.Platforms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Unix", SkillType = Skill.Type.Platforms, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "MySQL", SkillType = Skill.Type.Storage, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Microsoft SQL Server", SkillType = Skill.Type.Storage, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "MongoDB", SkillType = Skill.Type.Storage, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Cache", SkillType = Skill.Type.Storage, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Fiddler ", SkillType = Skill.Type.Tools, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "Single-page application", SkillType = Skill.Type.Misc, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "LDAP", SkillType = Skill.Type.Misc, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "singleton", SkillType = Skill.Type.Misc, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "NEW SKILL", SkillType = Skill.Type.Misc, SkillLevel = GetRandomSkillLvl() });
            _skills.Add(new Skill() { Name = "JSP", SkillType = Skill.Type.Misc, SkillLevel = GetRandomSkillLvl() });
            #endregion
        }

        public static Job Generate()
        {
            log.Debug("Generating the random Job");
            string name = "job-" + Generator.GetEpochTime();
            bool timeZonePref = GetRandomBool();
            DateTime date = DateTime.Now;
            date.AddDays(GetRandomPosition(10));

            var job = new Job
            {
                _Title = name,
                _Description = "Description of " + name,
                _WorkType = Job.WorkType.Remote,
                _TimeZonePreference = timeZonePref,
                _TimeZone = (timeZonePref) ? GetRandomTimeZone() : Job.TimeZones.Select_Time_Zone,
                _HoursOverlap = (timeZonePref) ? GetRandomHoursOverlap() : Job.HoursOverlap.NoPreference,
                _DesiredStartDate = date,
                _EstimatedLength = GetRandomEstimatedLength(),
                _SpokenLanguages = GetRandomSpokenLanguages(),
                _Skills = GetRandomSkills()
            };

            LastGeneratedJob = job;
            return job;
        }

        #region Get Randoms
        private static int GetRandomPosition(int maxValue)
        {
            Browser.ImplicitWait(200);// just to produce different results
            Random r = new Random();
            return r.Next(0, maxValue);
        }

        private static bool GetRandomBool()
        {
            Browser.ImplicitWait(200);// just to produce different results
            Random r = new Random();
            return r.NextDouble() >= 0.5;
        }

        private static Job.TimeZones GetRandomTimeZone()
        {
            int pos = GetRandomPosition(Enum.GetValues(typeof(Job.TimeZones)).Length);
            if (pos == 0)
                pos += 1;

            int i = 0;
            foreach (Job.TimeZones z in Enum.GetValues(typeof(Job.TimeZones)))
            {
                if (i == pos)
                    return z;
                else
                    i++;
            }

            return Job.TimeZones.Select_Time_Zone;
        }

        private static Job.HoursOverlap GetRandomHoursOverlap()
        {
            int pos = GetRandomPosition(Enum.GetValues(typeof(Job.HoursOverlap)).Length);

            int i = 0;
            foreach (Job.HoursOverlap h in Enum.GetValues(typeof(Job.HoursOverlap)))
            {
                if (i == pos)
                    return h;
                else
                    i++;
            }

            return Job.HoursOverlap.NoPreference;
        }

        private static Job.EstimatedLength GetRandomEstimatedLength()
        {
            int pos = GetRandomPosition(Enum.GetValues(typeof(Job.EstimatedLength)).Length);

            int i = 0;
            foreach (Job.EstimatedLength l in Enum.GetValues(typeof(Job.EstimatedLength)))
            {
                if (i == pos)
                    return l;
                else
                    i++;
            }

            return Job.EstimatedLength.Months_2_3;
        }

        private static List<Job.SpokenLanguages> GetRandomSpokenLanguages()
        {
            List<Job.SpokenLanguages> languages = new List<Job.SpokenLanguages>();

            int pos = GetRandomPosition(Enum.GetValues(typeof(Job.SpokenLanguages)).Length);

            int i = 0;
            foreach (Job.SpokenLanguages l in Enum.GetValues(typeof(Job.SpokenLanguages)))
            {
                languages.Add(l);
                if (i == pos)
                    break;
                else
                    i++;
            }

            return languages;
        }

        private static Skill.Level GetRandomSkillLvl()
        {
            int pos = GetRandomPosition(Enum.GetValues(typeof(Skill.Level)).Length);

            int i = 0;
            foreach (Skill.Level l in Enum.GetValues(typeof(Skill.Level)))
            {
                if (i == pos)
                    return l;
                else
                    i++;
            }

            return Skill.Level.Strong;
        }

        private static List<Skill> GetRandomSkills()
        {
            int pos = GetRandomPosition((int)(_skills.Count / 3));
            List<Skill> skills = new List<Skill>();
                       if (pos == 0)
                pos += 1;

            for (int i = 0; i < _skills.Count; i += pos)
                skills.Add(_skills[i]);

            return skills;
        }
        #endregion
    }

    #region Job Class
    public class Job
    {
        #region Enums
        public enum DesiredCommitment
        {
            full_time,
            part_time,
            hourly
        }

        public enum WorkType
        {
            Remote
        }

        public enum EstimatedLength
        {
            [Value("0")]
            Weeks_1_2,

            [Value("1")]
            Weeks_2_4,

            [Value("2")]
            Weeks_4_8,

            [Value("3")]
            Months_2_3,

            [Value("4")]
            Months_3_6,

            [Value("5")]
            Months_6_12,

            [Value("6")]
            Months_12_plus,

            [Value("7")]
            Unknown
        }

        // I have used just a few languages from the site, just for testing purpose
        public enum SpokenLanguages
        {
            English,
            Russian,
            Arabic,
            French,
            Italian,
            German,
            Portuguese,
            Japanese,
            Chinese,
            Spanish
        }

        public enum TimeZones
        {
            [Value("Select time zone...")]
            Select_Time_Zone,

            [Value("American Samoa")]
            American_Samoa,

            [Value("International Date Line West")]
            International_Date_Line_West,

            [Value("Midway Island")]
            Midway_Island,

            [Value("Hawaii")]
            Hawaii,

            [Value("Alaska")]
            Alaska,

            [Value("Pacific Time (US & Canada)")]
            Pacific_Time_US_And_Canada,

            [Value("Tijuana")]
            Tijuana,

            [Value("Arizona")]
            Arizona,

            [Value("Chihuahua")]
            Chihuahua,

            [Value("Mazatlan")]
            Mazatlan,

            [Value("Mountain Time (US & Canada)")]
            Mountain_Time_US_And_Canada,

            [Value("Central America")]
            Central_America,

            [Value("Central Time (US & Canada)")]
            Central_Time_US_And_Canada,

            [Value("Guadalajara")]
            Guadalajara,

            [Value("Mexico City")]
            Mexico_City,

            [Value("Monterrey")]
            Monterrey,

            [Value("Saskatchewan")]
            Saskatchewan,

            [Value("Bogota")]
            Bogota,

            [Value("Eastern Time (US & Canada)")]
            Eastern_Time_US_And_Canada,

            [Value("Indiana (East)")]
            Indiana_East,

            [Value("Lima")]
            Lima,

            [Value("Quito")]
            Quito,

            [Value("Caracas")]
            Caracas,

            [Value("Atlantic Time (Canada)")]
            Atlantic_Time_Canada,

            [Value("Georgetown")]
            Georgetown,

            [Value("La Paz")]
            La_Paz,

            [Value("Santiago")]
            Santiago
        }

        public enum HoursOverlap
        {
            [Value("No preference")]
            NoPreference,

            [Value("1")]
            H_1,

            [Value("2")]
            H_2,

            [Value("3")]
            H_3,

            [Value("4")]
            H_4,

            [Value("5")]
            H_5,

            [Value("6")]
            H_6,

            [Value("7")]
            H_7,

            [Value("8")]
            H_8,

            [Value("9")]
            H_9,

            [Value("10")]
            H_10,

            [Value("11")]
            H_11,

            [Value("12")]
            H_12,
        }
        #endregion

        public string _Title { get; set; }
        public string _Description { get; set; }
        public DesiredCommitment _DesiredCommitment { get; set; }
        public WorkType _WorkType { get; set; }
        public bool _TimeZonePreference { get; set; }
        public TimeZones _TimeZone { get; set; }
        public HoursOverlap _HoursOverlap { get; set; }
        public DateTime _DesiredStartDate { get; set; }
        public EstimatedLength _EstimatedLength { get; set; }
        public List<SpokenLanguages> _SpokenLanguages { get; set; }
        public List<Skill> _Skills { get; set; }
    }

    public class Skill
    {
        public enum Type { Languages, Frameworks, Libraries_APIs, Tools, Paradigms, Platforms, Storage, Misc }
        public enum Level { Competent, Strong, Expert }
        public string Name;
        public Type SkillType;
        public Level SkillLevel;
    }
    #endregion

    [AttributeUsage(AttributeTargets.All)]
    public class ValueAttribute : Attribute
    {
        string _value;

        public ValueAttribute(string value)
        {
            this._value = value;
        }

        public string _Value
        {
            get { return this._value; }
        }
    }
}
