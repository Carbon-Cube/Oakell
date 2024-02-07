using Volo.Abp.Modularity;

namespace Oakell;

[DependsOn(
    typeof(OakellDomainModule),
    typeof(OakellTestBaseModule)
)]
public class OakellDomainTestModule : AbpModule
{

}
