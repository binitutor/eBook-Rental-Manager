using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eBook_Rental_Manager.Startup))]
namespace eBook_Rental_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
