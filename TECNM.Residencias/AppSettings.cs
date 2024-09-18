using System.Collections.Generic;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias
{
    internal sealed class AppSettings
    {
        private static AppSettings? s_instance;
        private IDictionary<string, Setting> _settings;

        public static AppSettings Default
        {
            get
            {
                if (s_instance == null)
                {
                    using var context = new AppDbContext();
                    var settings = new Dictionary<string, Setting>();

                    foreach (Setting setting in context.Settings.EnumerateSettings())
                    {
                        settings[setting.Name] = setting;
                    }

                    s_instance = new AppSettings(settings);
                }

                return s_instance;
            }
        }

        private AppSettings(IDictionary<string, Setting> settings)
        {
            _settings = settings;
        }

        public int DefaultAdvisorType
        {
            get => int.Parse(GetSetting(nameof(DefaultAdvisorType), "-1").Value);
            set => SetSetting(nameof(DefaultAdvisorType), value);
        }

        public int DefaultCompanyType
        {
            get => int.Parse(GetSetting(nameof(DefaultCompanyType), "-1").Value);
            set => SetSetting(nameof(DefaultCompanyType), value);
        }

        public long DefaultStudentCareer
        {
            get => long.Parse(GetSetting(nameof(DefaultStudentCareer), "-1").Value);
            set => SetSetting(nameof(DefaultStudentCareer), value);
        }

        public void Save()
        {
            using var context = new AppDbContext();

            foreach (Setting setting in _settings.Values)
            {
                context.Settings.InsertOrUpdate(setting);
            }

            context.Commit();
        }

        private Setting GetSetting(string name, string defaultValue)
        {
            Setting? setting;
            if (!_settings.TryGetValue(name, out setting))
            {
                setting = new Setting
                {
                    Name = name,
                    Value = defaultValue,
                };

                _settings[name] = setting;
            }

            return setting;
        }

        private void SetSetting(string name, object value)
        {
            Setting setting = GetSetting(name, "");
            setting.Value = value.ToString()!;
        }
    }
}
