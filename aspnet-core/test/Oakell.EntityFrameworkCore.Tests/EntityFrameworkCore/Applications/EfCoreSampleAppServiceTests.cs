using Oakell.Samples;
using Xunit;

namespace Oakell.EntityFrameworkCore.Applications;

[Collection(OakellTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OakellEntityFrameworkCoreTestModule>
{

}
