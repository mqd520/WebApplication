using Xunit;

using Assert = Xunit.Assert;

namespace WebApplication38.Tools.Tests
{
    public class JwtHelperTests
    {
        [Fact()]
        public void Parse_Should_NotNull()
        {
            var str = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjBENDEzODYwRjFFRDc1QUQ5QUE4QzlEODY2RDBDOTI2IiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYwMDEiLCJuYmYiOjE3NDU0MjE2NTMsImlhdCI6MTc0NTQyMTY1MywiZXhwIjoxNzQ1NDI1MjUzLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYwMDEvcmVzb3VyY2VzIiwic2NvcGUiOlsiYXBpIl0sImNsaWVudF9pZCI6ImNsaWVudCIsImp0aSI6IjhEOEU2MkVFQzY0OTM1OEZFNUY1ODVCNzczQjAzN0IxIn0.dxPm5el_9gJf_Mscwtk9RWSYEnCpDv3gt0Qj0yjGbD1qGIH8_GtqQ80GkJ9tgfTXO_hdNoLJGiqVmHEV-1wb3TJvFWO-LawoSpJbQL0cClHm5wGp4o_z9tMePqc5Ry0JDjrvkFH7JheUGA2RpJ7F78d_GA5K2_RLLTfImNpMzbAzWBm4VEnErwfGEuXU1_m6mqer7qR8ppTlykBoNDpv1w12EUID1TbwaPrBhJEAUTJuQzBcqTBhrIb_hJK6o8rYT0UByVL3M9mIhg19Vp1sS75566mH0sZcW1kgfYQVuRXT_ryBngro9JYh038Cq-NRd4fbGAjfCBr2IKLDr9s-Eg";
            var jwtInfo = JwtHelper.Parse(str);
            Assert.NotNull(jwtInfo);
        }
    }
}