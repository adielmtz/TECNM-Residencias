namespace TECNM.Residencias;

using System;
using System.Collections.Generic;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

internal sealed class AppSettings
{
    private static readonly string DefaultLastStorageBackupDate = DateTimeOffset.Now.ToRfc3339();
    private static readonly string DefaultLastDatabaseBackupDate = DateTimeOffset.Now.ToRfc3339();
    private static readonly string DefaultLastAppUpdateCheckDate = DateTimeOffset.Now.ToRfc3339();
    private static readonly TimeSpan DefaultStorageBackupFrequency = TimeSpan.FromDays(30);
    private static readonly TimeSpan DefaultDatabaseBackupFrequency = TimeSpan.FromDays(3);
    private static readonly TimeSpan DefaultAppUpdateCheckFrequency = TimeSpan.FromDays(30);

    private static AppSettings? s_instance;
    private IDictionary<string, Setting> _settings;

    public static AppSettings Default
    {
        get
        {
            if (s_instance is null)
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
        => _settings = settings;

    public CompanyType DefaultCompanyType
    {
        get => Enum.Parse<CompanyType>(GetSetting(nameof(DefaultCompanyType), -1).Value);
        set => SetSetting(nameof(DefaultCompanyType), value.ToString());
    }

    public bool MustOpenReportsDirectory
    {
        get => bool.Parse(GetSetting(nameof(MustOpenReportsDirectory), true).Value);
        set => SetSetting(nameof(MustOpenReportsDirectory), value);
    }

    public bool EnableStudentEmailAutocomplete
    {
        get => bool.Parse(GetSetting(nameof(EnableStudentEmailAutocomplete), true).Value);
        set => SetSetting(nameof(EnableStudentEmailAutocomplete), value);
    }

    public long DefaultStudentCareer
    {
        get => long.Parse(GetSetting(nameof(DefaultStudentCareer), -1).Value);
        set => SetSetting(nameof(DefaultStudentCareer), value);
    }

    public int DefaultSemesterFilter
    {
        get => int.Parse(GetSetting(nameof(DefaultSemesterFilter), -1).Value);
        set => SetSetting(nameof(DefaultSemesterFilter), value);
    }

    public DateTimeOffset LastStorageBackupDate
    {
        get => DateTimeOffset.Parse(GetSetting(nameof(LastStorageBackupDate), DefaultLastStorageBackupDate).Value);
        set => SetSetting(nameof(LastStorageBackupDate), value.ToRfc3339());
    }

    public TimeSpan StorageBackupFrequency
    {
        get => TimeSpan.Parse(GetSetting(nameof(StorageBackupFrequency), DefaultStorageBackupFrequency).Value);
        set => SetSetting(nameof(StorageBackupFrequency), value);
    }

    public DateTimeOffset LastDatabaseBackupDate
    {
        get => DateTimeOffset.Parse(GetSetting(nameof(LastDatabaseBackupDate), DefaultLastDatabaseBackupDate).Value);
        set => SetSetting(nameof(LastDatabaseBackupDate), value.ToRfc3339());
    }

    public TimeSpan DatabaseBackupFrequency
    {
        get => TimeSpan.Parse(GetSetting(nameof(DatabaseBackupFrequency), DefaultDatabaseBackupFrequency).Value);
        set => SetSetting(nameof(DatabaseBackupFrequency), value);
    }

    public TimeSpan AppUpdateCheckFrequency
    {
        get => TimeSpan.Parse(GetSetting(nameof(AppUpdateCheckFrequency), DefaultAppUpdateCheckFrequency).Value);
        set => SetSetting(nameof(AppUpdateCheckFrequency), value);
    }

    public DateTimeOffset LastAppUpdateCheckDate
    {
        get => DateTimeOffset.Parse(GetSetting(nameof(LastAppUpdateCheckDate), DefaultLastAppUpdateCheckDate).Value);
        set => SetSetting(nameof(LastAppUpdateCheckDate), value.ToRfc3339());
    }

    public bool IsStorageBackupRequired
        => DateTimeOffset.Now > (LastStorageBackupDate + StorageBackupFrequency);

    public bool IsDatabaseBackupRequired
        => DateTimeOffset.Now > (LastDatabaseBackupDate + DatabaseBackupFrequency);

    public bool ShouldCheckForAppUpdates
        => DateTimeOffset.Now > (LastAppUpdateCheckDate + AppUpdateCheckFrequency);

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
        => _settings.Clear();

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
