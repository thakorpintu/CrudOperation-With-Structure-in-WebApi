using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudOperationWith_WebApi_In_Structure.Startup))]
namespace CrudOperationWith_WebApi_In_Structure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
