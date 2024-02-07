using Oakell.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Oakell.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OakellEntityFrameworkCoreModule),
    typeof(OakellApplicationContractsModule)
    )]
public class OakellDbMigratorModule : AbpModule
{
}
