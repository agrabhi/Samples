using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegmentSample.Models
{
    public class Trustframework
    {
        public string Id { get; set; }

        public List<TrustframeworkPolicy> Policies { get; set; }

    }
}