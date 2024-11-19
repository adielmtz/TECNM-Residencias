namespace TECNM.Residencias;

using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Sets;

internal sealed class AppDbContext : DbContext
{
    public AppDbContext() : base(App.Database.CreateConnection())
    {
    }

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

    private CompanyDbSet? _companies;
    public CompanyDbSet Companies => _companies ??= new CompanyDbSet(this);

    private AdvisorDbSet? _advisors;
    public AdvisorDbSet Advisors => _advisors ??= new AdvisorDbSet(this);

    private StudentDbSet? _students;
    public StudentDbSet Students => _students ??= new StudentDbSet(this);

    private DocumentDbSet? _documents;
    public DocumentDbSet Documents => _documents ??= new DocumentDbSet(this);

    private SkillDbSet? _skills;
    public SkillDbSet Skills => _skills ??= new SkillDbSet(this);
    #endregion
}
