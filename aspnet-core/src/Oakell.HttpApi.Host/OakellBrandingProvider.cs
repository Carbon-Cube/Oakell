using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Oakell;

[Dependency(ReplaceServices = true)]
public class OakellBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Oakell";
}
