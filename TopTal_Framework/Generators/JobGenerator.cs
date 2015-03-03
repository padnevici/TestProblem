using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTal_Framework.Generators
{
    public class JobGenerator
    {
        public static Job LastGeneratedJob;

        public static void Initialize()
        {
            LastGeneratedJob = null;
        }

        public static Job Generate()
        {
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
                _SpokenLanguages = GetRandomSpokenLanguages()
            };

            LastGeneratedJob = job;
            return job;
        }

        #region Get Randoms
        private static int GetRandomPosition(int maxValue)
        {
            Random r = new Random();
            return r.Next(0, maxValue);
        }

        private static bool GetRandomBool()
        {
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

            [Value("0")]
            H_1,

            [Value("1")]
            H_2,

            [Value("2")]
            H_3,

            [Value("3")]
            H_4,

            [Value("4")]
            H_5,

            [Value("5")]
            H_6,

            [Value("6")]
            H_7,

            [Value("7")]
            H_8,

            [Value("8")]
            H_9,

            [Value("9")]
            H_10,

            [Value("10")]
            H_11,

            [Value("11")]
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
