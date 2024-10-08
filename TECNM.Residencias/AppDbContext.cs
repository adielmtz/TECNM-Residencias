namespace TECNM.Residencias;

using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Sets;
using TECNM.Residencias.Data.Sets.Location;
using TECNM.Residencias.Data.Sets.Types;

internal sealed class AppDbContext : IDbContext
{
    private readonly SqliteConnection _connection;
    private readonly SqliteTransaction _transaction;

    public AppDbContext()
    {
        _connection = App.Database.Open();
        _transaction = _connection.BeginTransaction(deferred: true);
    }

    public SqliteConnection Database => _connection;

    #region DbSets
    private CountryDbSet? _countries;
    public CountryDbSet Countries => _countries ??= new CountryDbSet(this);

    private StateDbSet? _states;
    public StateDbSet States => _states ??= new StateDbSet(this);

    private CityDbSet? _cities;
    public CityDbSet Cities => _cities ??= new CityDbSet(this);

    private SettingDbSet? _settings;
    public SettingDbSet Settings => _settings ??= new SettingDbSet(this);

    private CareerDbSet? _careers;
    public CareerDbSet Careers => _careers ??= new CareerDbSet(this);

    private SpecialtyDbSet? _specialties;
    public SpecialtyDbSet Specialties => _specialties ??= new SpecialtyDbSet(this);

    private CompanyTypeDbSet? _companyTypes;
    public CompanyTypeDbSet CompanyTypes => _companyTypes ??= new CompanyTypeDbSet(this);

    private CompanyDbSet? _companies;
    public CompanyDbSet Companies => _companies ??= new CompanyDbSet(this);

    private AdvisorDbSet? _advisors;
    public AdvisorDbSet Advisors => _advisors ??= new AdvisorDbSet(this);

    private GenderDbSet? _genders;
    public GenderDbSet Genders => _genders ??= new GenderDbSet(this);

    private StudentDbSet? _students;
    public StudentDbSet Students => _students ??= new StudentDbSet(this);

    private DocumentTypeDbSet? _documentTypes;
    public DocumentTypeDbSet DocumentTypes => _documentTypes ??= new DocumentTypeDbSet(this);

    private DocumentDbSet? _documents;
    public DocumentDbSet Documents => _documents ??= new DocumentDbSet(this);

    private ExtraTypeDbSet? _extraTypes;
    public ExtraTypeDbSet ExtraTypes => _extraTypes ??= new ExtraTypeDbSet(this);

    private ExtraDbSet? _extras;
    public ExtraDbSet Extras => _extras ??= new ExtraDbSet(this);
    #endregion

    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public void Dispose()
    {
        Optimize();
        _transaction.Dispose();
        _connection.Dispose();
    }

    private void Optimize()
    {
        using var command = _connection.CreateCommand();
        command.CommandText = "PRAGMA optimize;";
        command.ExecuteNonQuery();
    }
}
