using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Infrastructure.Scoping;

namespace Ummmmbraco
{
    public class ContactFormDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
    public class ContactSurfaceController : SurfaceController
    {
        private IScopeProvider _scopeProvider; 
        public ContactSurfaceController(
            IScopeProvider scopeProvider,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _scopeProvider = scopeProvider;
        }

        public IActionResult ContactSubmit(ContactFormDto form)
        {
            if (form.Name == null || form.Email == null || form.Message == null)
                return BadRequest();

            using (var scope = _scopeProvider.CreateScope())
            {
                var data = new AddCommentsTable.Contactschema();
                data.Name = form.Name;
                data.Email = form.Email;
                data.Message = form.Message;

                scope.Database.Insert(data);
                scope.Complete();
            }
                return RedirectToCurrentUmbracoPage();
        }
        //public IActionResult UpdateName()
        //{

        //}
    }
}
