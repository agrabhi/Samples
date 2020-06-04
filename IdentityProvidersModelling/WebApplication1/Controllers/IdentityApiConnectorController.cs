using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ODataRoutePrefix("identity/apiconnectors")]
    public class IdentityApiConnectorController : ODataController
    {
        public static List<IdentityApiConnector> apis = new List<IdentityApiConnector>()
        {
            new IdentityApiConnector() 
            {
                Id = "4594600a-3fac-483d-9d71-fc3260f6a809",
                DisplayName = "API#1",
                TargetUrl = "https://jwt.ms",
                AuthenticationConfiguration = new BasicAuthentication()
                {
                    Username = "user",
                    Password = "pass"
                },
                RequestParameters = new List<ApiParameter>()
                {
                    new ApiParameter() { Id = "City" }
                },
                ResponseParameters = new List<ApiParameter>()
                {
                    new ApiParameter() { Id = "City" },
                    new ApiParameter() { Id = "extension_guid_shoeSize" }
                }
            }
        };

        [HttpGet]
        [ODataRoute]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Expand)]
        public IQueryable<IdentityApiConnector> List()
        {
            return apis.AsQueryable();
        }

        [HttpGet]
        [ODataRoute("({id})")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Expand)]
        public SingleResult<IdentityApiConnector> Get(string id)
        {
            var e = apis.Where(x => x.Id.Equals(id)).Single();
            return SingleResult.Create(new[] { e }.AsQueryable());
        }

        [HttpPost]
        [ODataRoute]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Expand)]
        public SingleResult<IdentityApiConnector> Create([FromBody] IdentityApiConnector ev)
        {
            if (ev == null)
            {
                throw new Exception("NULL");
            }

            if (!string.IsNullOrEmpty(ev.Id))
            {
                throw new Exception("Id should not be supplied. It is auto-generated.");
            }

            ev.Id = Guid.NewGuid().ToString();

            if (ev.AuthenticationConfiguration == null)
            {
                throw new Exception("AuthenticationConfiguration should be supplied.");
            }

            if (ev.AuthenticationConfiguration is Pkcs12Certificate)
            {
                ev.AuthenticationConfiguration = new ClientCertificateAuthentication()
                {
                    CertificateList = new List<Pkcs12CertificateInformation>()
                    {
                        new Pkcs12CertificateInformation()
                        {
                            IsActive = true,
                            NotBefore = DateTime.UtcNow.Ticks,
                            NotAfter = DateTime.UtcNow.AddYears(1).Ticks,
                            Thumbprint = "AB124FED553321EBC334AB124FED553321EBC334"
                        }
                    }
                };
            }
            else if (ev.AuthenticationConfiguration is ClientCertificateAuthentication)
            {
                throw new Exception("AuthenticationConfiguration cannot be ClientCertificateAuthentication.");
            }

            apis.Add(ev);
            return SingleResult.Create(new[] { ev }.AsQueryable());
        }

        [HttpPatch]
        [ODataRoute("({id})")]
        public void Patch(string id, [FromBody] Delta<IdentityApiConnector> delta)
        {
            if (!apis.Any(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                throw new HttpException((int) HttpStatusCode.NotFound, "Not found");
            }

            var original = apis.Where(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)).Single();

            delta.Patch(original);
        }

        [HttpDelete]
        [ODataRoute("({id})")]
        public void Delete(string id)
        {
            if (!apis.Any(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
            }

            apis.Remove(apis.First(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase)));
        }

        [HttpGet]
        public IQueryable<ApiParameter> GetAllowedApiParameters()
        {
            return new UserFlowAttributesController().GetUserProfileAttributes().Select((a) =>
            new ApiParameter()
            {
                Id = a.Id,
                DisplayName = a.DisplayName,
                Description = a.Description,
                DataType = a.DataType,
                UserFlowAttributeType = a.UserFlowAttributeType,
                IsAllowedInRequests = true,
                IsAllowedInResponses = true
            });
        }
    }
}
