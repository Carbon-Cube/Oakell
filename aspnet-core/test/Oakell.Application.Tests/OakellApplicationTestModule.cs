using Volo.Abp.Modularity;

namespace Oakell;

[DependsOn(
    typeof(OakellApplicationModule),
    typeof(OakellDomainTestModule)
)]
public class OakellApplicationTestModule : AbpModule
{

}
