namespace TECNM.Residencias;

using System;
using System.Collections.Generic;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

internal sealed class AppSettings
{
    private static readonly int DefaultCompanyType = -1;
    private static readonly long DefaultStudentCareer = -1;
    private static readonly string DefaultLastManualBackupDate = DateTimeOffset.Now.ToRfc3339();
    private static readonly string DefaultLastAutomaticBackupDate = DateTimeOffset.Now.ToRfc3339();
    private static readonly TimeSpan DefaultManualBackupFrequency = TimeSpan.FromDays(30);
    private static readonly TimeSpan DefaultAutomaticBackupFrequency = TimeSpan.FromDays(3);

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

                foreach (Setting setting in context.Settings.EnumerateAll())
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

    public long CompanyType
    {
        get => int.Parse(GetSetting(nameof(CompanyType), DefaultCompanyType).Value);
        set => SetSetting(nameof(CompanyType), value);
    }

    public long StudentCareer
    {
        get => long.Parse(GetSetting(nameof(StudentCareer), DefaultStudentCareer).Value);
        set => SetSetting(nameof(StudentCareer), value);
    }

    public DateTimeOffset LastManualBackupDate
    {
        get => DateTimeOffset.Parse(GetSetting(nameof(LastManualBackupDate), DefaultLastManualBackupDate).Value);
        set => SetSetting(nameof(LastManualBackupDate), value.ToRfc3339());
    }

    public TimeSpan ManualBackupFrequency
    {
        get => TimeSpan.Parse(GetSetting(nameof(ManualBackupFrequency), DefaultManualBackupFrequency).Value);
        set => SetSetting(nameof(ManualBackupFrequency), value);
    }

    public DateTimeOffset LastAutomaticBackupDate
    {
        get => DateTimeOffset.Parse(GetSetting(nameof(LastAutomaticBackupDate), DefaultLastAutomaticBackupDate).Value);
        set => SetSetting(nameof(LastAutomaticBackupDate), value.ToRfc3339());
    }

    public TimeSpan AutomaticBackupFrequency
    {
        get => TimeSpan.Parse(GetSetting(nameof(AutomaticBackupFrequency), DefaultAutomaticBackupFrequency).Value);
        set => SetSetting(nameof(AutomaticBackupFrequency), value);
    }

    public bool IsManualBackupRequired => DateTimeOffset.Now > (LastManualBackupDate + ManualBackupFrequency);

    public bool IsAutomaticBackupRequired => DateTimeOffset.Now > (LastAutomaticBackupDate + AutomaticBackupFrequency);

    public void Save()
    {
        using var context = new AppDbContext();

        foreach (Setting setting in _settings.Values)
        {
            context.Settings.AddOrUpdate(setting);
        }

        context.SaveChanges();
    }

    public void Clear()
    {
        _settings.Clear();
    }

    private Setting GetSetting(string name, object defaultValue)
    {
        Setting? setting;
        if (!_settings.TryGetValue(name, out setting))
        {
            setting = new Setting
            {
                Name = name,
                Value = defaultValue.ToString()!,
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
