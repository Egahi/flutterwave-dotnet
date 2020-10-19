using System.Collections.Generic;

namespace Flutterwave.Net
{
    public class GetSubAccountsResponse : Response<List<SubAccount>>
    {
        public Meta Meta { get; set; }
    }
}