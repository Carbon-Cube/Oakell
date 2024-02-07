using Oakell.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Oakell.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OakellController : AbpControllerBase
{
    protected OakellController()
    {
        LocalizationResource = typeof(OakellResource);
    }
}
